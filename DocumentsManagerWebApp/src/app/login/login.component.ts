import { Component, OnInit } from '@angular/core';
import { User } from '../User';
import { LoginService } from '../login.service';

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
 
  constructor(
    private loginService: LoginService
  ) {}
 
  ngOnInit() {

  }
  
  userLogin(user: User ){
      console.log("tu vieja rica");
      this.loginService.logIn(user).subscribe();
  }

}
