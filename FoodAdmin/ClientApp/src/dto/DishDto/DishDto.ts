export class DishDto {
  public dishName: string;
  public dishPrice: number;
  public dishWeight: number;
  public dishType: DishType;
}

enum DishType {
  Salad,
  Soup,
  SecondDish,
  Garnish
}
