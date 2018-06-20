import { Component, OnInit } from '@angular/core';
import { FullUserData } from 'src/app/list-admin/FullUserData';
import { ManageToken } from 'src/app/manage-token';
import { Router } from '@angular/router';
import { StyleService } from '../list-styles/style.service';
import { StyleModel } from '../list-styles/styleModel';
import { StyleAttributes } from '../list-styles/StyleAttributes';
import { StyleFromFormat } from '../list-format/style-from-format';
import { Format } from '../list-format/format';
import { FormatService } from '../list-format/format.service';

@Component({
  selector: 'app-new-format',
  templateUrl: './new-format.component.html',
  styleUrls: ['./new-format.component.css']
})
export class NewFormatComponent implements OnInit {
  style:StyleFromFormat;
  format:Format;
  tokenManagment:ManageToken;
  private styles:StyleFromFormat[];
  private allStyles:StyleFromFormat[];
  constructor(
    private formatService : FormatService,
    private styleService : StyleService,
    private router: Router
  ) { 
    this.tokenManagment=new ManageToken;
    this.style=new StyleFromFormat("","");
    this.styles=[];
    this.allStyles=[];
    this.format= new Format;
    this.loadStyles(this.tokenManagment.getToken());
  }

 
  loadStyles(token: string ){
    this.styleService.getAllStyles(token).subscribe(response => this.loadLocalStyles(response)), 
      error => this.showErrorMessage(error);
  }

  ngOnInit() {
  }
  loadLocalStyles(stylesResponse: Array<StyleFromFormat> ){
    this.allStyles=stylesResponse;
  }

 
  deleteStyle(type:string){
    let indexToDelete=-1;
    console.log(type);
    for (let index = 0; index < this.styles.length; index++) {
       if(this.styles[index].id==type){
          indexToDelete=index;
       }
     }
    this.styles.splice(indexToDelete, 1);
  }
  showErrorMessage(error:any){
    alert(error);
  }

  isAlreadyAdded(newStyle:StyleFromFormat):boolean{
    for (let index = 0; index < this.styles.length; index++) {
      if(this.styles[index].id==newStyle.id){
        return true;
     }
    }
    return false;
  }

  addStyle(){
    let splitter = this.style.id.split("###");
    let id=splitter[0];
    let name=splitter[1];
    let newStyle=new StyleFromFormat(id,name);
    if(newStyle.id.length!=0){
      if(this.isAlreadyAdded(newStyle)==false){
        this.styles.push(newStyle);   
      }
    }
  }

  formatAddedOk(){
    alert("Formato añadido correctamente");
    this.router.navigate((['/formats']));
  }

  addNewFormat(){
    let token=this.tokenManagment.getToken();
    this.styles.forEach(element => {
      this.format.styleClasses.push(element);
    });
    this.formatService.newFormat(token, this.format).subscribe(response => this.formatAddedOk(), 
    error => this.showErrorMessage(error));
  }
}
