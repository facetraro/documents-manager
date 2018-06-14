import { Component, OnInit } from '@angular/core';
import { User } from '../User';
import { Token } from '../Token';
import { LoginService } from 'src/app/login/login.service';
import { ManageToken } from '../manage-token';
import { AppRoutingModule } from '../app-routing.module';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';


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
    private router: Router,
    private  localStorageSession : ManageToken
  ) {}
 
  ngOnInit() {

  }

  showErrorMessage(error:any){
      alert(error);
  }

  login(response:string){
    this.localStorageSession.saveToken(response);
    this.router.navigate((['/home']));
   }

  userLogin(user: User ){
      this.loginService.logIn(user).subscribe(response => this.login(response), 
        error => this.showErrorMessage(error));
  }
}
