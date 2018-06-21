import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { ManageToken } from './manage-token';

@Injectable({
  providedIn: 'root'
})
export class DocumentsManagerGuardService implements CanActivate {
  token:ManageToken;
  constructor(private _router: Router) {

    
  }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    this.token=new ManageToken;
    let validation=false;
    let id=this.token.getToken();
    let role=this.token.getRole();
    if(role!="Editor") {
      if(role!="Admin") {
        validation=true;
      }
    }
    if (id.length==0 || validation) {
        alert('No tiene permisos para acceder aqui');
        this._router.navigate(['/login']);
        return false;
    };
    return true;
  }
}
