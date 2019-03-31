import { ContainerHttpService } from '../../../HttpServices/ContainerHttpService';
import { ContainerDto } from '../../../dto/Container/ContainerDto';
import { Component } from '@angular/core';

@Component({
  selector: 'app-container-list',
  templateUrl: './ContainerList.Component.html',
  providers: [ContainerHttpService]
})

export class ContainerListComponent {
  private readonly _containerHttpService: ContainerHttpService;
  public containers: ContainerDto[];

  public constructor(containerHttpService: ContainerHttpService) {
    this._containerHttpService = containerHttpService;
    this.reloadContainer();
  }

  public deleteContainer(id: number): void {
    this._containerHttpService.removeContainer(id).subscribe(() => {
      this.reloadContainer();
    });
  }

  private reloadContainer(): void {
    this._containerHttpService.getContainers().subscribe(values => {
      this.containers = values;
    });
  }
}
