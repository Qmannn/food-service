import { Component, OnInit, Input } from '@angular/core';
import { SampleDto } from '../../../../dto/Sample/SampleDto';

@Component({
  selector: 'app-edit-sample-card',
  templateUrl: './EditSampleCard.Component.html',
  styleUrls: ['./EditSampleCard.Component.css']
})
export class EditSampleCardComponent implements OnInit {

  @Input()
  public sampleToEdit: SampleDto;

  constructor() { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
  }

}
