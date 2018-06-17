import { Component, OnInit } from '@angular/core';
import { FullUserData } from '../list-admin/FullUserData';
import { ManageToken } from '../manage-token';
import { EditorService } from '../list-editor/editor.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-modify-editor',
  templateUrl: './modify-editor.component.html',
  styleUrls: ['./modify-editor.component.css']
})
export class ModifyEditorComponent implements OnInit {
  user:FullUserData;
  tokenManagment:ManageToken;
  editorService : EditorService;
  router: Router;
  userId:string;
  token:string;
  constructor(
    private activatedRoute: ActivatedRoute,
    router: Router,
    editorService : EditorService
  ) { 
    this.tokenManagment=new ManageToken;
    this.router=router;
    this.editorService=editorService;
    this.user = new FullUserData("","","","","","");
  }

  ngOnInit() {
    this.activatedRoute.queryParams
    .filter(params => params.userToModify)
    .subscribe(params => {
      this.userId = params.userToModify;
    });  
    let token=this.tokenManagment.getToken();
    this.editorService.getEditor(token,this.userId).subscribe(response => this.user=response), 
    error => this.showErrorMessage(error);
  }

  showErrorMessage(error:any){
    alert(error);
  }

  userModifyOk(){
    alert("Usuario modificado correctamente");
    this.router.navigate((['/editors']));
  }

  modifyEditor(){
    let token=this.tokenManagment.getToken();
    this.editorService.modifyEditor(token, this.user).subscribe(response => this.userModifyOk(), 
    error => this.showErrorMessage(error));
  }
}

