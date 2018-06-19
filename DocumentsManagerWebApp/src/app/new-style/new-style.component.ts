import { Component, OnInit } from '@angular/core';
import { FullUserData } from 'src/app/list-admin/FullUserData';
import { ManageToken } from 'src/app/manage-token';
import { Router, ActivatedRoute } from '@angular/router';
import { StyleService } from '../list-styles/style.service';
import { StyleModel } from '../list-styles/styleModel';
import { StyleAttributes } from '../list-styles/StyleAttributes';

@Component({
  selector: 'app-new-style',
  templateUrl: './new-style.component.html',
  styleUrls: ['./new-style.component.css']
})
export class NewStyleComponent implements OnInit {
  style:StyleModel;
  attribute:StyleAttributes;
  tokenManagment:ManageToken;
  private attributes:StyleAttributes[];
  constructor(
    private activatedRoute: ActivatedRoute,
    private styleService : StyleService,
    private router: Router
  ) { 
    this.tokenManagment=new ManageToken;
    this.style=new StyleModel;
    this.attribute=new StyleAttributes;
    this.attributes=[];
  }

  ngOnInit() {
  }

  deleteAttribute(type:string){
    let indexToDelete=-1;
    console.log(type);
    for (let index = 0; index < this.attributes.length; index++) {
       if(this.attributes[index].type==type){
          indexToDelete=index;
       }
     }
    this.attributes.splice(indexToDelete, 1);
  }
  showErrorMessage(error:any){
    alert(error);
    this.style.styleAttributes=[];
  }

  isAlreadyAdded(newAttribute:StyleAttributes):boolean{
    for (let index = 0; index < this.attributes.length; index++) {
      if(this.attributes[index].type==newAttribute.type){
        return true;
     }
    }
    return false;
  }

  updateValue(newAttribute:StyleAttributes){
    for (let index = 0; index < this.attributes.length; index++) {
      if(this.attributes[index].type==newAttribute.type){
        this.attributes[index].value=newAttribute.value;
     }
    }
    return false;
  }

  addAttribute(){
    let newAttribute=new StyleAttributes;
    newAttribute.type=this.attribute.type;
    newAttribute.value=this.attribute.value;
    if(newAttribute.type.length!=0){
      if(this.isAlreadyAdded(newAttribute)==false){
        this.attributes.push(newAttribute);   
      } else {
        this.updateValue(newAttribute);
      }
    }
  }

  styleAddedOk(){
    alert("Estilo añadido correctamente");
    this.router.navigate((['/styles']));
  }

  addNewStyle(){
    let token=this.tokenManagment.getToken();
    this.attributes.forEach(element => {
      this.style.styleAttributes.push(element.toString());
    });
    this.styleService.newStyle(token, this.style).subscribe(response => this.styleAddedOk(), 
    error => this.showErrorMessage(error));
  }
}
