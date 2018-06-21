import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { ManageToken } from './manage-token';

@Injectable({
  providedIn: 'root'
})
export class AdminGuardService implements CanActivate {
  token:ManageToken;
  constructor(private _router: Router) {
   
  }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    this.token=new ManageToken;
    let id=this.token.getToken();
    let role=this.token.getRole();
    if (id.length==0 || role!="Admin") {
        alert('No tiene permisos para acceder aqui');
        this._router.navigate(['/home']);
        return false;
    };
    return true;
  }
}
