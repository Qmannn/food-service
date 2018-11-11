import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { DishListComponent } from './components/pages/DishList/DishList.Component';
import { DishComponent } from './components/pages/Dish/Dish.component';
import { HttpService } from './HttpServices/HttpService';
import { SampleComponent } from './components/pages/Sample/Sample.Component';
import { MenuComponent } from './components/pages/menu/menu.component';
import { UserListComponent } from './components/pages/UserList/UserList.Component';
import { EditUserComponent } from './components/pages/EditUser/EditUser.Component';
import { EditSampleComponent } from './components/pages/Sample/EditSample/EditSample.Component';
import { CommandsComponent } from './components/pages/Commands/Commands.Component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,

    MenuComponent,
    SampleComponent,
    DishListComponent,
    SampleComponent,
    UserListComponent,
    EditUserComponent,
    EditSampleComponent,
    CommandsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DishListComponent, pathMatch: 'full' },
      { path: 'sample', component: SampleComponent },
      { path: 'dish', component: DishComponent },
      { path: 'sample', component: SampleComponent },
      { path: 'menu', component: MenuComponent, pathMatch: 'full' },
      { path: 'sample/:sampleId/edit', component: EditSampleComponent },
      { path: 'sample/create', component: EditSampleComponent },
      { path: 'edit-user', component: EditUserComponent },
      { path: 'edit-user/:userId', component: EditUserComponent },
      { path: 'user-list', component: UserListComponent },
      { path: 'commands', component: CommandsComponent }
    ])
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule {}
