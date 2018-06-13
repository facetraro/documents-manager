import { Component, OnInit } from '@angular/core';
import { User } from '../User';
import { Token } from '../Token';
import { LoginService } from 'src/app/login/login.service';
import { ManageToken } from '../ManageToken';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = {
    username: '',
    password: ''
  };
  token: Token = {
    token: ''
  };
 
  constructor(
    private loginService: LoginService,
    private  localStorageSession : ManageToken
  ) {}
 
  ngOnInit() {

  }

  showErrorMessage(error:any){
      alert(error);
  }

  login(response:string){
    this.localStorageSession.saveToken(response);
  }

  userLogin(user: User ){
      this.loginService.logIn(user).subscribe(response => this.login(response), 
        error => this.showErrorMessage(error));
  }
}
