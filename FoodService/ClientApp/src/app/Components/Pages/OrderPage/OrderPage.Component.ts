import { Component } from '@angular/core';
import { UsersDataService } from '../../../../HttpServices/UsersDataService';
import { UserDto } from '../../../../dto/User/UserDto';
import { DishDto } from '../../../../dto/Dish/DishDto';
import { OrderDataService } from '../../../../HttpServices/OrderDataService';
import { DayMenuDto } from '../../../../dto/DayMenu/DayMenuDto';

@Component({
  selector: 'app-order-page-component',
  templateUrl: './OrderPage.Component.html',
  providers: [UsersDataService, OrderDataService],
  styleUrls: ['./OrderPage.Component.css']
})

export class OrderPageComponent {
  private readonly _dishDataService: OrderDataService;
  private readonly _usersDataService: UsersDataService;
  public users: UserDto[];
  public selectDishes: DishDto[] = [];
  public dayMenu: DayMenuDto;

  public constructor(usersDataService: UsersDataService, dishDataService: OrderDataService) {
    this._usersDataService = usersDataService;
    this._dishDataService = dishDataService;

    this._usersDataService.getUsers().subscribe(values => {
      this.users = values;
    });
  }

  protected getMenuDishes(dateTime: Date): void {
    this._dishDataService.getDishes(dateTime).subscribe(values => {
      this.dayMenu = values;
    });
  }

  protected selectDish(dish: DishDto): void {
    this.selectDishes.push(dish);
  }

  protected deselectDish(dish: DishDto): void {
    const index: number = this.selectDishes.findIndex((item: DishDto) => item.id === dish.id);
    this.selectDishes.splice(index, 1);
  }

  protected selectDate(menuDate: Date): void {
    this.getMenuDishes(menuDate);
    this.selectDishes = [];
  }
}
