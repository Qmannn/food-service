import {DishDto} from '../Dish/DishDto';
import { MenuDto } from '../Menu/MenuDto';

export class DayMenuDto {
    public menuDishes: DishDto[];
    public menu: MenuDto;
}
