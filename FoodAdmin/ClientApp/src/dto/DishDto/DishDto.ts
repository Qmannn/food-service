import { DishType } from "./Enum/DishType";

export class DishDto {
  public dishName: string;
  public dishPrice: number;
  public dishWeight: number;
  public dishType: DishType;
}
