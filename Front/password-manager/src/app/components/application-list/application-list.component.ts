import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpProviderService } from '../../services/http-provider.service';

@Component({
  selector: 'app-application-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './application-list.component.html',
  styleUrl: './application-list.component.scss'
})
export class ApplicationListComponent implements OnInit {
  applications: any[] = [];
  errorMessage: string | null = null;

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
}
