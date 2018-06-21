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
  { path: 'styles', component: ListStylesComponent },
  { path: 'newStyle', component: NewStyleComponent },
  { path: 'modifyStyle', component: ModifyStyleComponent },
  { path: 'formats', component: ListFormatComponent },
  { path: 'newFormat', component: NewFormatComponent },
  { path: 'modifyFormat', component: ModifyFormatComponent },
  { path: 'documents', component: ListDocumentComponent },
  { path: 'viewChart', component: ViewChartComponent },
  { path: 'newDocument', component: NewDocumentComponent },
  { path: 'modifyDocument', component: ModifyDocumentComponent },
  { path: 'printDocument', component: PrintDocumentComponent },
  { path: 'users', component: AllUsersComponent },
  { path: 'friendRequests', component: ViewRequestsComponent },
  { path: 'friends', component: ListFriendsComponent },
  { path: 'profile', component: ViewFriendProfileComponent },
  { path: 'reviewDocument', component: ReviewDocumentComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}


