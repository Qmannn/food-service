import { Component } from '@angular/core';
import { EditUserDataService } from '../../../HttpServices/EditUserDataService';
import { UserDto } from '../../../dto/User/UserDto';
import { ActivatedRoute } from '@angular/router';

@Component({
  // selector: 'app-add-user',
  templateUrl: './EditUser.Component.html',
  providers: [EditUserDataService],
})
export class EditUserComponent {
  private readonly _userDataService: EditUserDataService;
  public newUser: UserDto;

  public constructor(userDataService: EditUserDataService, route: ActivatedRoute) {
    this._userDataService = userDataService;
    route.params.subscribe(params => {
      // Если в параметрах есть sampleId -то это редактирование, иначе это создание нового экземпляра
      const userId: number | undefined = params['userId'] !== undefined
        ? Number(params['userId'])
        : 0;
      this._userDataService.getUser(userId).subscribe(value => {
        this.newUser = value;
      });
    });
  }

  public saveUser(): void {
    this._userDataService.saveUser(this.newUser).subscribe(value => {
      alert('Сохранен ' + value.userId + ' ' + value.name);
    });
  }
}
