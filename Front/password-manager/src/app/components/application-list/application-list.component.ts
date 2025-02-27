import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpProviderService } from '../../services/http-provider.service';

@Component({
  selector: 'app-application-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './application-list.component.html',
  styleUrl: './application-list.component.scss'
})
export class ApplicationListComponent implements OnInit {
  applicationGroup: FormGroup;
  applications: any[] = [];
  errorMessage: string | null = null;

  constructor(private httpProvider: HttpProviderService, private fb: FormBuilder) {
    this.applicationGroup = this.fb.group({
      name:['', Validators.required],
      type:['GrandPublic', Validators.required],
    })
  }

  ngOnInit() {
    this.fetchApplications();
  }

  fetchApplications() {
    this.httpProvider.getApplications().subscribe(
      (data: any) => {
        this.applications = Array.isArray(data) ? data : [];
        this.errorMessage = null;
      },
      (error: any) => {
        if (error.status === 404) {
          this.errorMessage = 'Aucune application trouvée.';
        } else {
          this.errorMessage = 'Une erreur est survenue, veuillez réessayer.';
        }
        console.error(error);
        this.applications = [];
      }
    )
  }

  addApplication() {
    if (this.applicationGroup.valid){
      const name = this.applicationGroup.get("name")?.value;
      const type = this.applicationGroup.get("type")?.value;

      let newApplication = {
        name: name,
        type: type
      }

      this.httpProvider.saveApplication(newApplication).subscribe(
        (response) => {
          this.applications.push(response);
          this.errorMessage = null;
          this.applicationGroup.get("name")?.reset();
        },
        (error) => {
          this.errorMessage = 'Erreur lors de l\'ajout de l\'application.';
          console.error(error);
        }
      );
    }
  }
}

export class applicationForm {
  name: string = "";
  type: string = "";
}