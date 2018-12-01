import { Component } from '@angular/core';
import { EditUserDataService } from '../../../HttpServices/EditUserDataService';
import { EditUserDto } from '../../../dto/EditUser/EditUserDto';

@Component({
  // selector: 'app-add-user',
  templateUrl: './EditUser.Component.html',
  providers: [EditUserDataService],
})
export class EditUserComponent {
  private readonly _userDataService: EditUserDataService;
  public newUser: EditUserDto;

  public constructor(userDataService: EditUserDataService) {
    this._userDataService = userDataService;
    //this.newUser = new UserDto();
    this._userDataService.getUser(0).subscribe(value => {
      this.newUser = value;
    });
  }

  public addUser(): void {
    this._userDataService.addUser(this.newUser).subscribe(value => {
      alert('Сохранен ' + value.userId + ' ' + value.name + ' ' + value.userName);
    });
  }
}
