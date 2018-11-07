import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { FoodListComponent } from './components/pages/food-list/food-list.component';
import { HttpService } from './HttpServices/HttpService';
import { SampleComponent } from './components/pages/Sample/Sample.Component';
import { UserListComponent } from './components/pages/UserList/UserList.Component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FoodListComponent,
    SampleComponent,
	  UserListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: FoodListComponent, pathMatch: 'full' },
      { path: 'sample', component: SampleComponent },
	    { path: 'user-list', component: UserListComponent }
    ])
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
