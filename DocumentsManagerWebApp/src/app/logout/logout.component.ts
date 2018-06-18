import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ManageToken } from '../manage-token';
import { LogoutService } from './logout.service';
import { Token } from '../Token';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
    
    private  localStorageSession : ManageToken;
    private token:Token;
  constructor( private logoutService : LogoutService, private router: Router) {
    this.token = new Token;
    this.localStorageSession = new ManageToken;
  }
 
  ngOnInit() {

  }

  showErrorMessage(error:any){
      alert(error);
  }

  logout(response:string){
    this.localStorageSession.saveToken("");
    alert("Se ha cerrado la sesion con éxito.");
    this.router.navigate((['/login']));
   }

  userLogout(){
      this.token.token=this.localStorageSession.getToken();
      this.logoutService.logOut(this.token).subscribe(response => this.logout(response), 
        error => this.showErrorMessage(error));
  }
}
