import { DishCategory } from '../../dto/Dish/DishCategory';

export class DishDto {
  public id: number;
  public name: string;
  public description: string;
  public price: number;
  public category: DishCategory;
  public containerId: number;
}
