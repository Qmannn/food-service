import { Component } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishCategory } from '../../../dto/DishDto/Enum/DishCategory';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { MenuHttpService } from '../../../HttpServices/MenuHttpService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-menu',
  templateUrl: './EditMenu.Component.html',
  providers: [MenuHttpService]
})
export class EditMenuComponent {
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  private _menuHttpService: MenuHttpService;
  private editingMenuId: number;

  public dishes: DishDto[] = [];
  public selectedDishes: DishDto[] = [];
  public selectedDishesId: number[] = [];
  public selectedDate: Date = new Date;

  public constructor(menuHttpService: MenuHttpService, route: ActivatedRoute) {
    this._menuHttpService = menuHttpService;
    route.params.subscribe(params => {
        const paramsMenuId: number | undefined = params['menuId'] !== undefined
            ? Number(params['menuId'])
            : 0;
        this.editingMenuId = paramsMenuId;
    });

    this._menuHttpService.getDishes(this.editingMenuId).subscribe(values => {
      this.selectedDishesId = values.selectedDishesId;
      this.dishes = values.dishes;
    });

    setTimeout(() => {
      for (let i = 0; i < this.dishes.length; i++) {
        for (let j = 0; j < this.selectedDishesId.length; j++) {
          if (this.dishes[i].dishId === this.selectedDishesId[j]) {
            this.selectedDishes.push(this.dishes[i]);
            this.dishes.splice(i, 1);
          }
        }
      }
    }, 1000);
  }

  public addDish(dish: DishDto): void {
    for (let i = 0; i < this.dishes.length; i++) {
      if (this.dishes[i].dishId === dish.dishId) {
        this.dishes.splice(i, 1);
        this.selectedDishes.push(dish);
        this.selectedDishesId.push(dish.dishId);
        return;
      }
    }
  }

  public delDish(dish: DishDto): void {
    for (let i = 0; i < this.selectedDishes.length; i++) {
      if (this.selectedDishes[i].dishId === dish.dishId) {
        this.selectedDishes.splice(i, 1);
        this.selectedDishesId.splice(i, 1);
        this.dishes.push(dish);
        return;
      }
    }
  }

  public getDishCategory(category: DishCategory): string {
    return this._resolver.getDishCategory(category);
  }
}
