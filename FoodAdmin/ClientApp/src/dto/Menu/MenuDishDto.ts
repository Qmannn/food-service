import { DishDto } from '../Dish/DishDto';

export class MenuDishDto {
  public selectedDishesId: number[];
  public dishes: DishDto[];
}
