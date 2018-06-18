import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { LoginComponent }   from './login/login.component';
import { ListAdminsComponent } from './list-admin/list-admins.component';
import { NewAdminComponent } from 'src/app/new-admin/new-admin.component';
import { ModifyAdminComponent } from 'src/app/modify-admin/modify-admin.component';
import { ListStylesComponent } from './list-styles/list-styles.component';
import { NewStyleComponent } from './new-style/new-style.component';
import { ModifyStyleComponent } from './modify-style/modify-style.component';


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: MainMenuComponent },
  { path: 'admins', component: ListAdminsComponent },
  { path: 'newAdmin', component: NewAdminComponent },
  { path: 'modifyAdmin', component: ModifyAdminComponent },
  { path: 'styles', component: ListStylesComponent },
  { path: 'newStyle', component: NewStyleComponent },
  { path: 'modifyStyle', component: ModifyStyleComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}


