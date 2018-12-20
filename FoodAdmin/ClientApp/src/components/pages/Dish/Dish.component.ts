import { Component } from '@angular/core';
import { DishDataService } from '../../../HttpServices/DishDataService';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishCategory } from '../../../enums/enum';

@Component({
  templateUrl: './Dish.Component.html',
  providers: [DishDataService]
})

export class DishCategoryNameUtil {

  public dishCategories: Array<any> = [
    { value: DishCategory.Salad, name: 'Салат' },
    { value: DishCategory.Soup, name: 'Суп' },
    { value: DishCategory.SecondDish, name: 'Второе блюдо' },
    { value: DishCategory.Garnish, name: 'Гарнир' },
  ]
}

export class DishComponent {

  private readonly _dishDataService: DishDataService;
  public dishes: DishDto[];
  public dishToEdit: DishDto = new DishDto();

  public constructor(dishDataService: DishDataService) {
    this._dishDataService = dishDataService;
    this.reloadDishes();
  }

  public saveDish(): void {
    this._dishDataService.saveDish(this.dishToEdit).subscribe(value => {
      this.reloadDishes();
    });
  }

  public editDish(dishId: number): void {
    this._dishDataService.getDish(dishId).subscribe(value => {
      this.dishToEdit = value;
      alert(`Edit ${dishId}`);
    });
  }

  private reloadDishes(): void {
    this._dishDataService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }
}
