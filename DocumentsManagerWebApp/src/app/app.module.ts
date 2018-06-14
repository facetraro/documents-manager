import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AppRoutingModule } from './/app-routing.module';
import { FormsModule } from '@angular/forms';
import { LoginService } from 'src/app/login/login.service';
import { ManageToken } from './manage-token';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { LogoutComponent } from './logout/logout.component';
import { LogoutService } from './logout/logout.service';
import { AdminService } from './list-admin/admin.service';
import { ListAdminsComponent } from './list-admin/list-admins.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MainMenuComponent,
    LogoutComponent,
    ListAdminsComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    LoginService, 
    LogoutService,
    AdminService, 
    ManageToken
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
