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
      let id=this.token.getToken();
      if (id.length==0) {
          alert('La id de la mascota no es valida');
          // redirigimos (a traves de una navegacion), a /pets
          this._router.navigate(['/login']);
          // abortamos la navegacion actual
          return false;
      };
      return true;
  }
}
