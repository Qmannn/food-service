import { Component } from '@angular/core';
import { DishDto } from '../../../dto/DishDto/DishDto';
import { MenuDto } from '../../../dto/Menu/MenuDto';
import { DishCategory } from '../../../dto/DishDto/Enum/DishCategory';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { MenuHttpService } from '../../../HttpServices/MenuHttpService';
import { ActivatedRoute } from '@angular/router';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-edit-menu',
  templateUrl: './EditMenu.Component.html',
  providers: [MenuHttpService]
})
export class EditMenuComponent {
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  private _menuHttpService: MenuHttpService;
  private editingMenuId: number;
  public menuToEdit: MenuDto;

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

    if (this.editingMenuId === 0) {
      this._dishesDataService.getDishes().subscribe(values => {
        this.dishes = values;
      });
    } else {
      this.loadMenu();

      this._menuHttpService.getDishes().subscribe(values => {
        this.dishes = values;
        this._menuHttpService.getMenusDishes(this.editingMenuId).subscribe(values => {
          this.selectedDishes = values;
          const tempDishes: DishDto[] = [];
          for (let i = 0; i < this.dishes.length; i++) {
            let inDishes = false;
            for (let j = 0; j < this.selectedDishes.length; j++) {
              if (this.dishes[i].dishId == this.selectedDishes[j].dishId) {
                inDishes = true;
                break;
              }

              //  //this.inDishes = true;
              //if ((j == this.selectedDishes.length - 1) && (this.inDishes == false))
              //  this.tempDishes.push(this.dishes[i]);
            }

            if (!inDishes) {
              tempDishes.push(this.dishes[i])
            }
          }
          this.dishes = tempDishes;
        });
      });
    }
  }

  private loadMenu(): void {
    this._menuHttpService.getMenu(this.editingMenuId).subscribe(menu => {
      this.menuToEdit = menu;
    });
  }

  public getDate(date: Date) {
    return new Date(date).toLocaleDateString();
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
