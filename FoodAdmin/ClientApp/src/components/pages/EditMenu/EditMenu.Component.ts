import { Component } from '@angular/core';
import { MenuDto } from '../../../dto/Menu/MenuDto';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { MenuHttpService } from '../../../HttpServices/MenuHttpService';
import { ActivatedRoute } from '@angular/router';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishDataService } from '../../../HttpServices/DishDataService';
import { DishCategory } from '../../../dto/Dish/DishCategory';

@Component({
  selector: 'app-edit-menu',
  templateUrl: './EditMenu.Component.html',
  providers: [MenuHttpService, DishDataService]
})
export class EditMenuComponent {
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  private readonly _menuHttpService: MenuHttpService;
  private readonly _dishDataService: DishDataService;

  private editingMenuId: number;
  public menuToEdit: MenuDto;

  public dishes: DishDto[] = [];
  public selectedDishes: DishDto[] = [];
  public selectedDate: Date = new Date;

  public constructor(menuHttpService: MenuHttpService, route: ActivatedRoute, dishDataService: DishDataService) {
    this._dishDataService = dishDataService;
    this._menuHttpService = menuHttpService;
    route.params.subscribe(params => {
      const paramsMenuId: number | undefined = params['menuId'] !== undefined
        ? Number(params['menuId'])
        : 0;
      this.editingMenuId = paramsMenuId;

      this.loadMenu();
      this.loadDishes();
    });
  }

  private loadDishes(): void {
    this._dishDataService.getDishes().subscribe(values => {
      this.dishes = values;
      this._menuHttpService.getMenusDishes(this.editingMenuId).subscribe(dishes => {
        this.selectedDishes = dishes;
        const tempDishes: DishDto[] = [];

        for (let i = 0; i < this.dishes.length; i++) {
          let inDishes = false;
          for (let j = 0; j < this.selectedDishes.length; j++) {
            if (this.dishes[i].dishId === this.selectedDishes[j].dishId) {
              inDishes = true;
              break;
            }
          }

          if (!inDishes) {
            tempDishes.push(this.dishes[i])
          }
        }
        this.dishes = tempDishes;
      });
    });
  }

  private loadMenu(): void {
    this._menuHttpService.getMenu(this.editingMenuId).subscribe(menu => {
      this.menuToEdit = menu;
    });
  }

  public getDate(date: Date): string {
    return new Date(date).toLocaleDateString();
  }


  public addDish(dish: DishDto): void {
    for (let i = 0; i < this.dishes.length; i++) {
      if (this.dishes[i].dishId === dish.dishId) {
        this.dishes.splice(i, 1);
        this.selectedDishes.push(dish);
        return;
      }
    }
  }

  public delDish(dish: DishDto): void {
    for (let i = 0; i < this.selectedDishes.length; i++) {
      if (this.selectedDishes[i].dishId === dish.dishId) {
        this.selectedDishes.splice(i, 1);
        this.dishes.push(dish);
      }
    }
  }

  public saveMenu(): void {
    this.menuToEdit.dishes = [];
    for (let i = 0; i < this.selectedDishes.length; i++) {
      this.menuToEdit.dishes.push(this.selectedDishes[i].dishId);
    }

    this._menuHttpService.saveMenu(this.menuToEdit).subscribe(value => {
    });
  }

  public getDishCategory(category: DishCategory): string {
    return this._resolver.getDishCategory(category);
  }
}
