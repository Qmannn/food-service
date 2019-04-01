import { Component } from '@angular/core';
import { DishDto } from '../../../dto/DishDto/DishDto';
import { DishCategory } from '../../../dto/DishDto/Enum/DishCategory';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { DishesService } from '../../../HttpServices/DishesService/DishesService';
import { MenuHttpService } from '../../../HttpServices/MenuHttpService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-menu',
  templateUrl: './EditMenu.Component.html',
  providers: [DishesService, MenuHttpService]
})
export class EditMenuComponent {
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  private _dishesDataService: DishesService;
  private _menuHttpService: MenuHttpService;
  private editingMenuId: number;

  public dishes: DishDto[] = [];
  public selectedDishes: DishDto[] = [];
  public selectedDate: Date = new Date;

  public constructor(dishesDataService: DishesService, menuHttpService: MenuHttpService, route: ActivatedRoute) {
    this._dishesDataService = dishesDataService;
    this._menuHttpService = menuHttpService;
    route.params.subscribe(params => {
        const paramsMenuId: number | undefined = params['menuId'] !== undefined
            ? Number(params['menuId'])
            : 0;
        this.editingMenuId = paramsMenuId;
    });

    if (this.editingMenuId === 0) {
      this._dishesDataService.getDishes().subscribe(values => {
        this.dishes = values;
      });
    } else {
      this._menuHttpService.getDishes().subscribe(values => {
        this.dishes = values;
      });
    }
  }

  public addDish(dish: DishDto): void {
    for (let i = 0; i < this.dishes.length; i++) {
      if (this.dishes[i].id === dish.id) {
        this.dishes.splice(i, 1);
        this.selectedDishes.push(dish);
        return;
      }
    }
  }

  public delDish(dish: DishDto): void {
    for (let i = 0; i < this.selectedDishes.length; i++) {
      if (this.selectedDishes[i].id === dish.id) {
        this.selectedDishes.splice(i, 1);
        this.dishes.push(dish);
        return;
      }
    }
  }

  public getDishCategory(category: DishCategory): string {
    return this._resolver.getDishCategory(category);
  }
}
