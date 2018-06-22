import { Component, OnInit } from '@angular/core';
import { FullUserData } from 'src/app/list-admin/FullUserData';
import { AdminService } from '../list-admin/admin.service';
import { ManageToken } from 'src/app/manage-token';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { User } from '../User';

@Component({
  selector: 'app-modify-admin',
  templateUrl: './modify-admin.component.html',
  styleUrls: ['./modify-admin.component.css']
})
export class ModifyAdminComponent implements OnInit {
  user:FullUserData;
  tokenManagment:ManageToken;
  adminService : AdminService;
  router: Router;
  userId:string;
  token:string;
  constructor(
    private activatedRoute: ActivatedRoute,
    router: Router,
    adminService : AdminService
  ) { 
    this.tokenManagment=new ManageToken;
    this.router=router;
    this.adminService=adminService;
    this.user = new FullUserData("","","","","","");
  }

  ngOnInit() {
    this.activatedRoute.queryParams
    .filter(params => params.userToModify)
    .subscribe(params => {
      this.userId = params.userToModify;
    });  
    let token=this.tokenManagment.getToken();
    this.adminService.getAdmin(token,this.userId).subscribe(response => this.user=response), 
    error => this.showErrorMessage(error);
  }

  showErrorMessage(error:any){
    alert(error);
  }

  userModifyOk(){
    alert("Usuario modificado correctamente");
    this.router.navigate((['/admins']));
  }

  modifyAdmin(){
    let token=this.tokenManagment.getToken();
    this.adminService.modifyAdmin(token, this.user).subscribe(response => this.userModifyOk(), 
    error => this.showErrorMessage(error));
  }
}
