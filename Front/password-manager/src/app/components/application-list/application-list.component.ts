import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpProviderService } from '../../services/http-provider.service';

@Component({
  selector: 'app-application-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './application-list.component.html',
  styleUrl: './application-list.component.scss'
})
export class ApplicationListComponent implements OnInit {
  applications: any[] = [];
  errorMessage: string | null = null;
  newApplication = { name: '', type: 'GrandPublic' };

  constructor(private httpProvider: HttpProviderService) {}

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
    if (!this.newApplication.name.trim()) {
      this.errorMessage = 'Le nom de l\'application est requis.';
      return;
    }

    this.httpProvider.saveApplication(this.newApplication).subscribe(
      (response) => {
        this.applications.push(response);
        this.newApplication = { name: '', type: 'GrandPublic' };
        this.errorMessage = null;
      },
      (error) => {
        this.errorMessage = 'Erreur lors de l\'ajout de l\'application.';
        console.error(error);
      }
    );
  }
}

export class applicationForm {
  name: string = "";
  type: string = "";
}