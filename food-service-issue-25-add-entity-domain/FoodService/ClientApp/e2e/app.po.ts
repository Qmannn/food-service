import { browser, by, element } from 'protractor';

export class AppPage {
  public navigateTo(): {} {
    return browser.get('/');
  }

  public getMainHeading(): {} {
    return element(by.css('app-root h1')).getText();
  }
}
