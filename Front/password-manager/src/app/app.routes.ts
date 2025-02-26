import { Routes } from '@angular/router';
import { PasswordListComponent } from './components/password-list/password-list.component';
import { AddPasswordComponent } from './components/add-password/add-password.component';
import { ApplicationListComponent } from './components/application-list/application-list.component';

export const routes: Routes = [
  { path: '', redirectTo: 'passwords', pathMatch: 'full' }, // Redirection par défaut
  { path: 'passwords', component: PasswordListComponent }, // Liste des mots de passe
  { path: 'passwords/add', component: AddPasswordComponent }, // Formulaire pour ajouter un mot de passe
  { path: 'applications', component: ApplicationListComponent }, // Liste des applications
  { path: '**', redirectTo: 'passwords' } // Redirection pour pages inexistantes
];
