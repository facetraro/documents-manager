import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StyleModel } from './styleModel';
import { ManageToken } from '../manage-token';
import { StyleService } from './style.service';
import { ModifyAdminComponent } from '../modify-admin/modify-admin.component';

@Component({
  selector: 'app-list-styles',
  templateUrl: './list-styles.component.html',
  styleUrls: ['./list-styles.component.css']
})
export class ListStylesComponent {
  addFriendImgPath: string;
  pageTitle: string = "Styles List";
  listFilter: string = "";
  styles: Array<StyleModel> = [];
  activeToken:string;
  tokenManagment:ManageToken;

  constructor(
    private styleService : StyleService, 
    private router: Router
  ) {
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    this.loadStyles(this.activeToken);
  }
  showErrorMessage(error:any){
    alert(error);
  }
  loadStyles(token: string ){
    this.styleService.getAllStyles(token).subscribe(response => this.loadLocalStyles(response)), 
      error => this.showErrorMessage(error);
  }
  loadLocalStyles(stylesResponse: Array<StyleModel> ){
    this.styles=stylesResponse;
    console.log(this.styles);
  }
  modifyStyle(id:string){
    //this.router.navigate((['/modifyAdmin']), { queryParams: { userToModify: id} });
  }
  deleteStyle(id:string){
    this.styleService.deleteStyle(this.activeToken,id).subscribe(response => window.location.reload()), 
    error => this.showErrorMessage(error);
  }
  addStyle(){
    this.router.navigate((['/newStyle']));
  }
}


