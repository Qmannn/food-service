import { DishDto } from '../Dish/DishDto';

export class OrderDto {
  public userId: number;
  public menuId: number;
  public orderDishes: DishDto[];
}
