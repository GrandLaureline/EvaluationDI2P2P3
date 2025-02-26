import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpProviderService } from '../../services/http-provider.service';

@Component({
  selector: 'app-password-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.scss']
})
export class PasswordListComponent implements OnInit {
  passwords: any[] = [];
  errorMessage: string | null = null;

  constructor(private httpProvider: HttpProviderService) {}

  ngOnInit() {
    this.fetchPasswords();
  }

  fetchPasswords() {
    this.httpProvider.getPasswords().subscribe(
      (data: any) => {
        this.passwords = Array.isArray(data) ? data : [];
        this.errorMessage = null;
      },
      (error: any) => {
        if (error.status === 404) {
          this.errorMessage = 'Aucune application trouvée.';
        } else {
          this.errorMessage = 'Une erreur est survenue, veuillez réessayer.';
        }
        console.error(error);
        this.passwords = [];
      }
    )
  }

  deletePassword(id: number) {
    if (confirm('Êtes-vous sûr de vouloir supprimer ce mot de passe ?')) {
      this.httpProvider.deletePassword(id).subscribe(
        () => {
          this.fetchPasswords()
        },
        (error: any) => {
          console.error('Erreur lors de la suppression du mot de passe:', error);
          this.errorMessage = 'Une erreur est survenue lors de la suppression.';
        }
      );
    }
  }
}
