import { Component, OnInit } from '@angular/core';
import { FullUserData } from 'src/app/list-admin/FullUserData';
import { AdminService } from '../list-admin/admin.service';
import { ManageToken } from 'src/app/manage-token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-admin',
  templateUrl: './new-admin.component.html',
  styleUrls: ['./new-admin.component.css']
})
export class NewAdminComponent implements OnInit {
  user:FullUserData;
  tokenManagment:ManageToken;
  constructor(
    private adminService : AdminService,
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
    this.router.navigate((['/admins']));
  }

  addNewUser(){
    let token=this.tokenManagment.getToken();
    this.adminService.newAdmin(token, this.user).subscribe(response => this.userAddedOk(), 
    error => this.showErrorMessage(error));
  }
}
