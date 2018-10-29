import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { FoodListComponent } from '../pages/food-list/food-list.component';
import { HttpService } from '../../HttpServices/BaseHttpService';
import { MenuComponent } from '../pages/menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FoodListComponent,
    MenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: FoodListComponent, pathMatch: 'full' },
      { path: 'menu', component: MenuComponent, pathMatch: 'full' },
    ])
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
