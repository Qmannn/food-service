import { NgModule,Component } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { MenuHttpService } from '../../../HttpServices/MenuHttpService';
import { MenuDto } from '../../../dto/Menu/MenuDto';
import { AppComponent } from '../../app/app.component';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu.component.html',
  providers: [MenuHttpService]
})

export class MenuComponent {
  private readonly _menuDataService: MenuHttpService;
  public menus: MenuDto[];

  public constructor(menuDataService: MenuHttpService) {
    this._menuDataService = menuDataService;

    this._menuDataService.getMenus().subscribe(values => {
      this.menus = values;
    });
  }
}
