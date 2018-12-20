import { Component } from '@angular/core';
import { UsersDataService } from '../../../HttpServices/UsersDataService';
import { UserDto } from '../../../dto/User/UserDto';

@Component({
  selector: 'app-user-list',
  templateUrl: './UserList.Component.html',
  providers: [UsersDataService]
})
export class UserListComponent {
  private readonly _usersDataService: UsersDataService;
  public users: UserDto[];

  public constructor(usersDataService: UsersDataService) {
    this._usersDataService = usersDataService;

    this._usersDataService.getUsers().subscribe(values => {
      this.users = values;
    });
  }
};