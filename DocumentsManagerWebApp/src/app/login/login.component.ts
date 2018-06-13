import { Component, OnInit } from '@angular/core';
import { User } from '../User';
import { Token } from '../Token';
import { LoginService } from 'src/app/login/login.service';

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
  errorMessage: string;
  constructor(
    private loginService: LoginService
  ) {}
 
  ngOnInit() {

  }

  showErrorMessage(error:any){
      alert(error);
  }

  userLogin(user: User ){
      this.loginService.logIn(user).subscribe(response => this.token=response, 
        error => this.showErrorMessage(error));
  }

}
