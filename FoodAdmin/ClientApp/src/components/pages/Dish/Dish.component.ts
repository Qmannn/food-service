import { Component } from '@angular/core';
import { DishDataService } from '../../../HttpServices/DishDataService';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishCategory } from '../../../dto/Dish/DishDto';

@Component({
  //selector: 'app-dish',
  templateUrl: './Dish.Component.html',
  providers: [DishDataService]
})
export class DishComponent {

  private readonly _dishDataService: DishDataService;
  public dishes: DishDto[];
  public dishToEdit: DishDto = new DishDto();

  public constructor(dishDataService: DishDataService) {
    this._dishDataService = dishDataService;
    this.reloadDishes();
    this.dishToEdit.price = 0;
    this.dishToEdit.category = DishCategory.Salad;
    this.dishToEdit.containerId = 1;
  }

  public dishCategories: Array<any> = [
    { value: DishCategory.Salad, name: 'Салат' },
    { value: DishCategory.Soup, name: 'Суп' },
    { value: DishCategory.SecondDish, name: 'Второе блюдо' },
    { value: DishCategory.Garnish, name: 'Гарнир' },
  ]

  public saveDish(): void {
    this._dishDataService.saveDish(this.dishToEdit).subscribe(value => {
      this.reloadDishes();
      this.dishToEdit = new DishDto();
      this.dishToEdit.price = 0;
      this.dishToEdit.category = DishCategory.Salad;
      this.dishToEdit.containerId = 1;
    });
  }

  private reloadDishes(): void {
    this._dishDataService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }
}
