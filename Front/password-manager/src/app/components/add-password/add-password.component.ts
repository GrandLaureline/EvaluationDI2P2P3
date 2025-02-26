import { Component } from '@angular/core';

@Component({
  selector: 'app-add-password',
  standalone: true,
  imports: [],
  templateUrl: './add-password.component.html',
  styleUrl: './add-password.component.scss'
})
export class AddPasswordComponent {

}

export class passwordForm {
  Name: string = "";
  Description: string = "";
  Link: string = "";
  Icon: string = "";
}