import { DishCategory } from '../../enums/enum';

export class DishDto {
  public dishId: number;
  public name: string;
  public description: string;
  public price: number;
  public category: DishCategory;
  public containerId: number;
}

