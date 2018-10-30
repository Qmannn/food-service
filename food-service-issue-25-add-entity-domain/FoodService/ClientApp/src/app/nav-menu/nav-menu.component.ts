import { Component } from '@angular/core';
import { NavigationItem } from './models/NavigationItem';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public navItems: NavigationItem[] = [];

  public constructor() {
    this.initNavigation();
  }

  public isExpanded: boolean = false;

  public collapse(): void {
    this.isExpanded = false;
  }

  public toggle(): void {
    this.isExpanded = !this.isExpanded;
  }

  private initNavigation(): void {
    this.navItems.push(new NavigationItem('Home', '/', 'glyphicon-home' ));
    this.navItems.push(new NavigationItem('Counter', '/counter', 'glyphicon-plus' ));
  }
}
