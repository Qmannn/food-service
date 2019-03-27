import { DishCategory } from '../dto/DishDto/Enum/DishCategory';

export class DishTypeNameResolver {
    public getDishCategory(Category: DishCategory): string {
        switch (Category) {
          case DishCategory.Salad: {
            return 'Салат';
          }
          case DishCategory.FirstDish: {
            return 'Суп';
          }
          case DishCategory.SecondDish: {
            return 'Второе блюдо';
          }
          case DishCategory.Garnish: {
            return 'Гарнир';
          }
          default: {
            return '';
          }
        }
      }
}
