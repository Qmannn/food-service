import { DishCategory } from '../../../dto/Dish/DishCategory';
import { IDishCategory } from './IDishCategoryName';

export class DishCategoryNameUtil {
  private static readonly _getCategories: Array<IDishCategory> = [
    { value: DishCategory.Salad, name: 'Салат' },
    { value: DishCategory.Soup, name: 'Суп' },
    { value: DishCategory.SecondDish, name: 'Второе блюдо' },
    { value: DishCategory.Garnish, name: 'Гарнир' },
  ]

  public static getCategories(): Array<IDishCategory> {
    return this._getCategories;
  }
}
