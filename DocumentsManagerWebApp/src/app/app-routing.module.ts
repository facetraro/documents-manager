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
import { ListStylesComponent } from './list-styles/list-styles.component';
import { NewStyleComponent } from './new-style/new-style.component';
import { ModifyStyleComponent } from './modify-style/modify-style.component';
import { ListFormatComponent } from './list-format/list-format.component';
import { NewFormatComponent } from './new-format/new-format.component';
import { ModifyFormatComponent } from './modify-format/modify-format.component';
import { ListDocumentComponent } from './list-document/list-document.component';
import { ViewChartComponent } from './view-chart/view-chart.component';
import { NewDocumentComponent } from './new-document/new-document.component';
import { ModifyDocumentComponent } from './modify-document/modify-document.component';
import { PrintDocumentComponent } from './print-document/print-document.component';
import { AllUsersComponent } from './all-users/all-users.component';
import { ViewRequestsComponent } from './view-requests/view-requests.component';
import { ListFriendsComponent } from './list-friends/list-friends.component';
import { ViewFriendProfileComponent } from './view-friend-profile/view-friend-profile.component';
import { ReviewDocumentComponent } from './review-document/review-document.component';
import { DocumentsManagerGuardService } from './documents-manager-guard.service';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: MainMenuComponent, canActivate: [DocumentsManagerGuardService]},
  { path: 'admins', component: ListAdminsComponent, canActivate: [DocumentsManagerGuardService]},
  { path: 'newAdmin', component: NewAdminComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'modifyAdmin', component: ModifyAdminComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'editors', component: ListEditorsComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'newEditor', component: NewEditorComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'modifyEditor', component: ModifyEditorComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'styles', component: ListStylesComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'newStyle', component: NewStyleComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'modifyStyle', component: ModifyStyleComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'formats', component: ListFormatComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'newFormat', component: NewFormatComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'modifyFormat', component: ModifyFormatComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'documents', component: ListDocumentComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'viewChart', component: ViewChartComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'newDocument', component: NewDocumentComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'modifyDocument', component: ModifyDocumentComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'printDocument', component: PrintDocumentComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'users', component: AllUsersComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'friendRequests', component: ViewRequestsComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'friends', component: ListFriendsComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'profile', component: ViewFriendProfileComponent, canActivate: [DocumentsManagerGuardService] },
  { path: 'reviewDocument', component: ReviewDocumentComponent, canActivate: [DocumentsManagerGuardService] },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}


