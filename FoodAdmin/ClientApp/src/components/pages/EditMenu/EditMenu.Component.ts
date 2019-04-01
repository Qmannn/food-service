import { Component } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { MenuDataService } from '../../../HttpServices/MenuDataService';
import { ActivatedRoute } from '@angular/router';
import { DishCategory } from '../../../dto/Dish/DishCategory';
import { MenuDto } from '../../../dto/Menu/MenuDto';
import { DishesService } from '../../../HttpServices/DishesService/DishesService';

@Component({
  selector: 'app-edit-menu',
  templateUrl: './EditMenu.Component.html',
  providers: [DishesService, MenuDataService]
})

export class EditMenuComponent {
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  private readonly _dishesDataService: DishesService;
  private _menuDataService: MenuDataService;
  private editingMenuId: number;
  public menuToEdit: MenuDto;

  public dishes: DishDto[] = [];
  public selectedDishes: DishDto[] = [];
  public selectedDishesId: number[] = [];
  public selectedDate: Date = new Date;

  public constructor(dishesDataService: DishesService, menuDataService: MenuDataService, route: ActivatedRoute) {
    this._dishesDataService = dishesDataService;
    this._menuDataService = menuDataService;
    route.params.subscribe(params => {
        const paramsMenuId: number | undefined = params['menuId'] !== undefined
            ? Number(params['menuId'])
            : 0;
        this.editingMenuId = paramsMenuId;
      this.loadMenu();
    });


    /*
    } else {
      this._menuDataService.getDishes().subscribe(values => {
        this.dishes = values;
      });*/
    }


  public sortSelectedDishes(): void {
    for (let i = 0; i < this.dishes.length; i++) {
      for (let j = 0; j < this.selectedDishesId.length; j++) {
        if (this.dishes[i].dishId === this.selectedDishesId[j]) {
          this.selectedDishes.push(this.dishes[i]);
          this.dishes.splice(i, 1);
        }
      }
    }
  }

  private loadMenu(): void {
    this._menuDataService.getDishes(this.editingMenuId).subscribe(menu => {
      this.selectedDishesId = menu.selectedDishesId;
      this.dishes = menu.dishes;
      this.sortSelectedDishes();
    });
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

  public saveMenu(): void {
    alert('Сохранение скоро будет реализовано');
    this._menuDataService.saveMenu(this.menuToEdit).subscribe(value => {
      alert('Сохранен');
    });
  }

  public getDishCategory(category: DishCategory): string {
    return this._resolver.getDishCategory(category);
  }
}
