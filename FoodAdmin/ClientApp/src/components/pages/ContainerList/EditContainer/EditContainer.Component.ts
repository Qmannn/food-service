import { ContainerHttpService } from '../../../../HttpServices/ContainerHttpService';
import { ContainerDto } from '../../../../dto/Container/ContainerDto';
import { Component } from '@angular/core';
import { DishDataService } from '../../../../HttpServices/DishDataService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-container-list',
  templateUrl: './EditContainer.Component.html',
  providers: [ContainerHttpService]
})

export class EditContainerComponent {
  private readonly _editContainerService: ContainerHttpService;

  public containerToEdit: ContainerDto;
  public editingContainerId: number;

  public constructor(editContainerService: ContainerHttpService, route: ActivatedRoute) {
    this._editContainerService = editContainerService;
    route.params.subscribe(params => {
      const paramsContainerId: number | undefined = params['containerId'] !== undefined ? Number(params['containerId']) : 0;
      this.editingContainerId = paramsContainerId;
      this.containerToEdit = new ContainerDto();
      this.loadContainer();
    });
  }

  public saveContainer(): void {
    this._editContainerService.saveContainer(this.containerToEdit).subscribe(value => {
      this.editingContainerId = value.id;
      this.loadContainer();
    });
  }

  private loadContainer(): void {
    this._editContainerService.getContainer(this.editingContainerId).subscribe(values => {
      this.containerToEdit = values;
    });
  }
}
