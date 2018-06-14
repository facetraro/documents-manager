import { Component, OnInit } from '@angular/core';
import { ManageToken } from 'src/app/manage-token';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {
 
private tokenManagment:ManageToken;
private activeToken:string;
  constructor() {
    this.tokenManagment=new ManageToken;
    this.activeToken=this.tokenManagment.getToken();
    }

  ngOnInit() {
  }

}
