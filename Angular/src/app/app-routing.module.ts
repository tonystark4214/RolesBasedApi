import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {path:'', component:LoginComponent},
  { path: 'professor', loadChildren: () => import('./professor/professor.module').then((m) => m.ProfessorModule) , canActivate:[AuthGuard]},
  { path: 'researcher', loadChildren: () => import('./researcher/researcher.module').then((m) => m.ResearcherModule) , canActivate:[AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
