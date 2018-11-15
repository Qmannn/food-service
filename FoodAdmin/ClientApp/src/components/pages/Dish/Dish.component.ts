import { Component } from '@angular/core';
import { DishDataService } from '../../../HttpServices/DishDataService';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
  // selector: 'app-dish', // Обязательное поле, должно начинаться с app-
  templateUrl: './Dish.Component.html',
  providers: [DishDataService]
})
export class DishComponent {
  private readonly _dishDataService: DishDataService;
  public dishes: DishDto[];

  public dishToEdit: DishDto;

  public constructor(dishDataService: DishDataService) {
    this._dishDataService = dishDataService;
    this.reloadDishes();
  }

  public addDish(): void {
    this.dishToEdit = new DishDto();
    this.dishToEdit.name = '';
    this.dishToEdit.description = '';
    this.dishToEdit.price = 0;
  }

  public editDish(dishId: number): void {
    this._dishDataService.getDish(dishId).subscribe(value => {
      this.dishToEdit = value;
      alert(`Edit ${dishId}`);
    });
  }

  public saveDish(): void {
    alert('Сохранить');
    this._dishDataService.saveDish(this.dishToEdit).subscribe(value => {
      alert('Сохранен ' + value.savedDishId + 'c описанием "' + value.savedDescription + '"');
      this.reloadDishes();
      this.dishToEdit = undefined;
    });
  }

  public deleteDish(dishId: number): void {
    alert(`Delete ${dishId}`);
    this.reloadDishes();
  }

  private reloadDishes(): void {
    this._dishDataService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }
}
