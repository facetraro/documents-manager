import { Component, OnInit } from '@angular/core';
import { Format } from './format';
import { FormatService } from './format.service';
import { Router } from '@angular/router';
import { ManageToken } from '../manage-token';

@Component({
  selector: 'app-list-format',
  templateUrl: './list-format.component.html',
  styleUrls: ['./list-format.component.css']
})
export class ListFormatComponent{
  addFriendImgPath: string;
  pageTitle: string = "Format List";
  listFilter: string = "";
  formats: Array<Format> = [];
  activeToken:string;
  tokenManagment:ManageToken;

  constructor(
    private formatService : FormatService, 
    private router: Router
  ) {
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    this.loadFormats(this.activeToken);
  }
  showErrorMessage(error:any){
    alert(error);
  }
  loadFormats(token: string ){
    this.formatService.getAllFormats(token).subscribe(response => this.formats=response), 
      error => this.showErrorMessage(error);
  }
  modifyFormat(id:string){
    this.router.navigate((['/modifyFormat']), { queryParams: { formatToModify: id} });
  }
  deleteFormat(id:string){
    this.formatService.deleteFormat(this.activeToken,id).subscribe(response => window.location.reload()), 
    error => this.showErrorMessage(error);
  }
  addFormat(){
    this.router.navigate((['/newFormat']));
  }
}

