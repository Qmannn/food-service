import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { DishListComponent } from './components/pages/DishList/DishList.Component';
import { EditDishComponent } from './components/pages/Dish/EditDish/EditDish.Component';
import { HttpService } from './HttpServices/HttpService';
import { SampleComponent } from './components/pages/Sample/Sample.Component';
import { MenuComponent } from './components/pages/menu/menu.component';
import { UserListComponent } from './components/pages/UserList/UserList.Component';
import { EditUserComponent } from './components/pages/EditUser/EditUser.Component';
import { EditSampleComponent } from './components/pages/Sample/EditSample/EditSample.Component';
import { CommandsComponent } from './components/pages/Commands/Commands.Component';
import { EditSampleCardComponent } from './components/controls/sample/EditSampleCard/EditSampleCard.Component';
import { EditMenuComponent } from './components/pages/EditMenu/EditMenu.Component';
import { ContainerListComponent } from './components/pages/ContainerList/ContainerList.Component';
import { EditContainerComponent } from './components/pages/ContainerList/EditContainer/EditContainer.Component';

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
    CommandsComponent,
    EditDishComponent,
    EditSampleCardComponent,
    EditMenuComponent,
    ContainerListComponent,
    EditContainerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DishListComponent, pathMatch: 'full' },
      { path: 'sample', component: SampleComponent },
      { path: 'sample', component: SampleComponent },
      { path: 'menu', component: MenuComponent },
      { path: 'menu/:menuId/edit', component: EditMenuComponent },
      { path: 'menu/create', component: EditMenuComponent },
      { path: 'sample/:sampleId/edit', component: EditSampleComponent },
      { path: 'sample/create', component: EditSampleComponent },
      { path: 'edit-user', component: EditUserComponent },
      { path: 'edit-user/:userId', component: EditUserComponent },
      { path: 'user-list', component: UserListComponent },
      { path: 'commands', component: CommandsComponent },
      { path: 'dish/:dishId/edit', component: EditDishComponent },
      { path: 'dish/create', component: EditDishComponent },
      { path: 'menu/edit', component: EditMenuComponent },
      { path: 'containers', component: ContainerListComponent},
      { path: 'containers/create', component: EditContainerComponent},
      { path: 'containers/:containerId/edit', component: EditContainerComponent}
    ])
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
