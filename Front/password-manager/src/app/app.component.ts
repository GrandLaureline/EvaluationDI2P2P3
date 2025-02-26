import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppComponentNav } from './components/app/app.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    AppComponentNav
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {

}
