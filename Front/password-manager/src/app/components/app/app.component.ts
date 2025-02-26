import { Component, OnInit } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-app',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    CommonModule
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponentNav {
}
