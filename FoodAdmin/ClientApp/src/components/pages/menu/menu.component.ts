import { Component } from '@angular/core';
import { MenuDataHttpService } from '../../../HttpServices/MenuDataHttpService';
import { MenuDto } from '../../../dto/Menu/MenuDto';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  providers: [MenuDataHttpService]
})
export class MenuComponent {
  private readonly _menuDataService: MenuDataHttpService;
  public countAll = 0;
  public samples: MenuDto[];

  public constructor(menuDataService: MenuDataHttpService) {
    this._menuDataService = menuDataService;

    this._menuDataService.getSamples().subscribe(values => {
      this.countAll = values.length;
      this.samples = values;
    });
  }
}
