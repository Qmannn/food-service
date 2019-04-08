import { Component, OnInit, Input } from '@angular/core';
import { CommandDto } from '../../../../dto/Command/CommandDto';

@Component({
  selector: 'app-edit-command-card',
  templateUrl: './EditCommandCard.Component.html',
  styleUrls: ['./EditCommandCard.Component.css']
})
export class EditCommandCardComponent implements OnInit {

  @Input()
  public commandToEdit: CommandDto;

  constructor() { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
  }

}
