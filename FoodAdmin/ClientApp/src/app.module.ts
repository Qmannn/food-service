import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { DishListComponent } from './components/pages/DishList/DishList.Component';
import { HttpService } from './HttpServices/HttpService';
import { SampleComponent } from './components/pages/Sample/Sample.Component';
import { UserListComponent } from './components/pages/UserList/UserList.Component';
import { EditUserComponent } from './components/pages/EditUser/EditUser.Component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DishListComponent,
    SampleComponent,
	  UserListComponent,
    EditUserComponent 
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DishListComponent, pathMatch: 'full' },
      { path: 'sample', component: SampleComponent },
      { path: 'add-user', component: EditUserComponent },
	  { path: 'user-list', component: UserListComponent }
    ])
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
