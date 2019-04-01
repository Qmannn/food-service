import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuDataService } from '../../../HttpServices/MenuDataService';
import { MenuDto } from '../../../dto/Menu/MenuDto';
import { AppComponent } from '../../app/app.component';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu.component.html',
  providers: [MenuDataService]
})


export class MenuComponent {
  private readonly _menuDataService: MenuDataService;
  public menus: MenuDto[];

  public constructor(menuDataService: MenuDataService) {
    this._menuDataService = menuDataService;

    this._menuDataService.getMenus().subscribe(values => {
      this.menus = values;
    });
  }

  public getDate(date: Date) {
    return new Date(date).toLocaleDateString();
  }

  public deleteMenu(menuId: number): void {
    this._menuDataService.deleteMenu(menuId).subscribe(() => {
      this.reloadMenus();
    });
  }

  private reloadMenus(): void {
    this._menuDataService.getMenus().subscribe(values => {
      this.menus = values;
    });
  }
}
