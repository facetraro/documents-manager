import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { LoginComponent }   from './login/login.component';
import { ListAdminsComponent } from './list-admin/list-admins.component';
import { NewAdminComponent } from 'src/app/new-admin/new-admin.component';
import { ModifyAdminComponent } from 'src/app/modify-admin/modify-admin.component';
import { ListEditorsComponent } from './list-editor/list-editor.component';
import { NewEditorComponent } from './new-editor/new-editor.component';
import { ModifyEditorComponent } from './modify-editor/modify-editor.component';


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: MainMenuComponent },
  { path: 'admins', component: ListAdminsComponent },
  { path: 'newAdmin', component: NewAdminComponent },
  { path: 'modifyAdmin', component: ModifyAdminComponent },
  { path: 'editors', component: ListEditorsComponent },
  { path: 'newEditor', component: NewEditorComponent },
  { path: 'modifyEditor', component: ModifyEditorComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}


