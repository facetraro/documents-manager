import { Component, OnInit } from '@angular/core';
import { FullUserData } from 'src/app/list-admin/FullUserData';
import { ManageToken } from 'src/app/manage-token';
import { Router } from '@angular/router';
import { StyleService } from '../list-styles/style.service';
import { StyleModel } from '../list-styles/styleModel';

@Component({
  selector: 'app-new-style',
  templateUrl: './new-style.component.html',
  styleUrls: ['./new-style.component.css']
})
export class NewStyleComponent implements OnInit {
  style:StyleModel;
  tokenManagment:ManageToken;
  constructor(
    private styleService : StyleService,
    private router: Router
  ) { 
    this.tokenManagment=new ManageToken;
    this.style=new StyleModel;
  }

  ngOnInit() {
  }

  showErrorMessage(error:any){
    alert(error);
  }

  styleAddedOk(){
    alert("Estilo añadido correctamente");
    this.router.navigate((['/styles']));
  }

  addNewStyle(){
    let token=this.tokenManagment.getToken();
    this.styleService.newStyle(token, this.style).subscribe(response => this.styleAddedOk(), 
    error => this.showErrorMessage(error));
  }
}
