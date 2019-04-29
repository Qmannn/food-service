import { DishDto } from '../Dish/DishDto';
import { MenuDto } from './MenuDto';

export class MenuDishDto {
  public selectedDishesId: number[];
  public dishes: DishDto[];
  public menu: MenuDto;
}
