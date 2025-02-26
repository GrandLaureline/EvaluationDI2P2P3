import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpProviderService } from '../../services/http-provider.service';

@Component({
  selector: 'app-add-password',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-password.component.html',
  styleUrls: ['./add-password.component.scss']
})
export class AddPasswordComponent implements OnInit {
  applications: any[] = [];
  newPassword: passwordForm = { nomCompte: '', applicationId: 0, value: '' };
  errorMessage: string | null = null;
  successMessage: string | null = null;

  constructor(
    private httpProvider: HttpProviderService
  ) {}

  ngOnInit() {
    this.fetchApplications();
  }

  fetchApplications() {
    this.httpProvider.getApplications().subscribe(
      (data: any) => {
        this.applications = Array.isArray(data) ? data : [];
      },
      (error) => {
        console.error('Erreur lors du chargement des applications', error);
        this.errorMessage = 'Impossible de charger les applications.';
      }
    );
  }

  addPassword() {
    if (!this.newPassword.nomCompte.trim() || !this.newPassword.value.trim()) {
      this.errorMessage = 'Tous les champs sont obligatoires.';
      return;
    }
    console.log(this.applications)
    const selectedApp = this.applications.find(app => Number(app.id) === Number(this.newPassword.applicationId));

    if (!selectedApp) {
      this.errorMessage = 'Veuillez sélectionner une application valide.';
      return;
    }

    this.httpProvider.savePassword(this.newPassword, selectedApp.type).subscribe(
      () => {
        this.successMessage = 'Mot de passe ajouté avec succès !';
        this.newPassword = { nomCompte: '', applicationId: 0, value: '' };
      },
      (error) => {
        console.error('Erreur lors de l\'ajout du mot de passe', error);
        this.errorMessage = 'Impossible d\'ajouter le mot de passe.';
      }
    );
  }
}


export class passwordForm {
  value: string = "";
  nomCompte: string = "";
  applicationId: number = 0;
}