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

export class applicationForm {
  Name: string = "";
  Description: string = "";
  Link: string = "";
  Icon: string = "";
}

export class passwordForm {
  Name: string = "";
  Description: string = "";
  Link: string = "";
  Icon: string = "";
}