import { Component, OnInit, Input } from '@angular/core';
import { SampleDto } from '../../../../dto/Sample/SampleDto';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';

@Component({
  selector: 'app-edit-sample-card',
  templateUrl: './EditSampleCard.Component.html',
  styleUrls: ['./EditSampleCard.Component.css']
})
export class EditSampleCardComponent implements OnInit {

  @Input()
  public sampleToEdit: SampleDto;

  public someTypes: string[];

  constructor(private snackBar: MatSnackBar) {
    this.someTypes = [
      'First type',
      'Second type',
      'Еще одно значение в селекте'
    ];
  }

  // tslint:disable-next-line:typedef
  ngOnInit() {
  }

  protected showNotify(): void {
    const config: MatSnackBarConfig = new MatSnackBarConfig();
    config.horizontalPosition = 'right';
    config.verticalPosition = 'top';

    this.snackBar.open('Сохранено', 'X', config);
  }
}
