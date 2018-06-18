import { Component, OnInit } from '@angular/core';
import { FullUserData } from 'src/app/list-admin/FullUserData';
import { ManageToken } from 'src/app/manage-token';
import { Router, ActivatedRoute } from '@angular/router';
import { StyleService } from '../list-styles/style.service';
import { StyleModel } from '../list-styles/styleModel';
import { StyleAttributes } from '../list-styles/StyleAttributes';

@Component({
  selector: 'app-modify-style',
  templateUrl: './modify-style.component.html',
  styleUrls: ['./modify-style.component.css']
})
export class ModifyStyleComponent implements OnInit {
  style:StyleModel;
  attribute:StyleAttributes;
  tokenManagment:ManageToken;
  styleId:string;
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

  loadStyleClass(response:StyleModel){
    this.style=response;
    this.style.styleAttributes.forEach(element => {
      let array=element.split("###");
      if(array.length==1){
        this.attribute.type=array[0];
        this.attribute.value="";
        this.addAttribute();
      } else {
        this.attribute.type=array[0];
        this.attribute.value=array[1];
        this.addAttribute();
      }
    });
  }

  ngOnInit() {
    this.activatedRoute.queryParams
    .filter(params => params.styleToModify)
    .subscribe(params => {
      this.styleId = params.styleToModify;
    });  
    let token=this.tokenManagment.getToken();
    this.styleService.getStyle(token,this.styleId).subscribe(response => this.loadStyleClass(response)), 
    error => this.showErrorMessage(error);
  }


  deleteAttribute(type:string){
    let indexToDelete=-1;
    for (let index = 0; index < this.attributes.length; index++) {
       if(this.attributes[index].type==type){
          indexToDelete=index;
       }
     }
    this.attributes.splice(indexToDelete, 1);
  }
  showErrorMessage(error:any){
    alert(error);
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

  styleUpdatedOk(){
    alert("Estilo modificado correctamente");
    this.router.navigate((['/styles']));
  }

  updateStyle(){
    let token=this.tokenManagment.getToken();
    this.style.styleAttributes=[];
    this.attributes.forEach(element => {
      this.style.styleAttributes.push(element.toString());
    });
    this.styleService.modifyStyle(token, this.style).subscribe(response => this.styleUpdatedOk(), 
    error => this.showErrorMessage(error));
  }
}