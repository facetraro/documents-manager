import { Component, OnInit } from '@angular/core';
import { FullUserData } from '../list-admin/FullUserData';
import { ManageToken } from '../manage-token';
import { EditorService } from '../list-editor/editor.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-editor',
  templateUrl: './new-editor.component.html',
  styleUrls: ['./new-editor.component.css']
})
export class NewEditorComponent implements OnInit {
  user:FullUserData;
  tokenManagment:ManageToken;
  constructor(
    private adminService : EditorService,
    private router: Router
  ) { 
    this.tokenManagment=new ManageToken;
    this.user=new FullUserData("","","","","","");
  }

  ngOnInit() {
  }

  showErrorMessage(error:any){
    alert(error);
  }

  userAddedOk(){
    alert("Usuario añadido correctamente");
    this.router.navigate((['/editors']));
  }

  addNewUser(){
    let token=this.tokenManagment.getToken();
    this.adminService.newEditor(token, this.user).subscribe(response => this.userAddedOk(), 
    error => this.showErrorMessage(error));
  }
}
