import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  public appPages = [
    { title: 'Home', url: '/home', icon: 'home' },
    { title: 'Test', url: '/folder/Outbox', icon: 'code-working' },
    { title: 'Test', url: '/folder/Favorites', icon: 'code-working' },
    { title: 'Test', url: '/folder/Archived', icon: 'code-working' },
    { title: 'test', url: '/folder/Trash', icon: 'code-working' },
    { title: 'Exercise Wiki', url: '/exercise', icon: 'book' },
  ];
  public labels = ['Family', 'Friends', 'Notes', 'Work', 'Travel', 'Reminders'];
  constructor() {}
}
