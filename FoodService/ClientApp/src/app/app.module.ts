import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ColumnForDishesComponent } from './Components/ColumnForDishes/ColumnForDishes.Component';
import { DishSimpleComponent } from './Components/DishCard/DishSimple.Component';
import { DishCardComponent } from './Components/DishCard/DishCard.Component';
import { DishColumnSampleComponent } from './Components/DishColumns/DishColumnSample.Component';
import { DishColumnsComponent } from './Components/DishColumns/DishColumns.Component';
import { DishColumnsSapmleComponent } from './Components/DishColumns/DishColumnsSample.Component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ColumnForDishesComponent,
    DishSimpleComponent,
    DishCardComponent,
    DishColumnSampleComponent,
    DishColumnsComponent,
    DishColumnsSapmleComponent
    FetchDataComponent,
    DishesColumnComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'dish-card', component: DishSimpleComponent },
      { path: 'dish-columns', component: DishColumnsSapmleComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
