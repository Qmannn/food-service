export class SavedDishInfo {
  public savedDishId: number;
  public savedName: string;
  public savedDescription: string;
  public savedPrice: number;
  public savedCategory: DishCategory;
  public savedContainerId: number;
}

enum DishCategory {
  Salad,
  Soup,
  SecondDish,
  Garnish
}
