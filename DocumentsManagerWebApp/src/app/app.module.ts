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
import { GoHomeComponent } from './go-home/go-home.component';
import { NewAdminComponent } from './new-admin/new-admin.component';
import { ModifyAdminComponent } from './modify-admin/modify-admin.component';
import { ListEditorsComponent } from './list-editor/list-editor.component';
import { EditorService } from './list-editor/editor.service';
import { NewEditorComponent } from './new-editor/new-editor.component';
import { ModifyEditorComponent } from './modify-editor/modify-editor.component';
import { ListStylesComponent } from './list-styles/list-styles.component';
import { StyleService } from './list-styles/style.service';
import { NewStyleComponent } from './new-style/new-style.component';
import { ModifyStyleComponent } from './modify-style/modify-style.component';
import { ListFormatComponent } from './list-format/list-format.component';
import { FormatService } from './list-format/format.service';
import { NewFormatComponent } from './new-format/new-format.component';
import { ModifyFormatComponent } from './modify-format/modify-format.component';
import { ListDocumentComponent } from './list-document/list-document.component';
import { DocumentService } from './list-document/document.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MainMenuComponent,
    LogoutComponent,
    ListAdminsComponent,
    GoHomeComponent,
    NewAdminComponent,
    ModifyAdminComponent,
    ListEditorsComponent,
    NewEditorComponent,
    ModifyEditorComponent,
    ListStylesComponent,
    NewStyleComponent,
    ModifyStyleComponent,
    ListFormatComponent,
    NewFormatComponent,
    ModifyFormatComponent,
    ListDocumentComponent
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
    StyleService,
    AdminService, 
    DocumentService,
    FormatService, 
    EditorService, 
    ManageToken
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
