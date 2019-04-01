import { Component } from '@angular/core';
import { UsersDataService } from '../../../../HttpServices/UsersDataService';
import { UserDto } from '../../../../dto/User/UserDto';
import { DishDto } from '../../../../dto/Dish/DishDto';
import { MockDataHelper } from '../MockDataHelper';

@Component({
  selector: 'app-order-page-component',
  templateUrl: './OrderPage.Component.html',
  providers: [UsersDataService],
  styleUrls: ['./OrderPage.Component.css']
})

export class OrderPageComponent {
  private readonly _usersDataService: UsersDataService;
  public users: UserDto[];
  public selectDishes: DishDto[] = [];
  public dishes: DishDto[] = MockDataHelper.getMock();

  public constructor(usersDataService: UsersDataService) {
    this._usersDataService = usersDataService;

    this._usersDataService.getUsers().subscribe(values => {
      this.users = values;
    });
  }

  protected selectDish(dish: DishDto): void {
    this.selectDishes.push(dish);
  }

  protected deselectDish(dish: DishDto): void {
    const index: number = this.selectDishes.findIndex((item: DishDto) => item.dishId === dish.dishId);
    this.selectDishes.splice(index, 1);
  }
}
