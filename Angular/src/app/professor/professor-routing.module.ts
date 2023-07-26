import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfessorComponent } from './professor.component';
import { ResearcherComponent } from '../researcher/researcher.component';
import { LandingPageComponent } from './landingPage/landing-page/landing-page.component';
import { ResearcherListComponent } from './resercherList/researcher-list/researcher-list.component';
import { AddProfComponent } from './addProf/add-prof/add-prof.component';
import { AddResComponent } from './addRes/add-res/add-res.component';

const routes: Routes = [
  {path:'',component:ProfessorComponent,
  children: [
    {
      path: '',
      component: LandingPageComponent, // Use the InnerComponent here
    },
    {
      path:'researcherList',component:ResearcherListComponent
    },
    {
      path:'addProf',component:AddProfComponent
    },
    {
      path:'addRes',component:AddResComponent
    }
    // Other child routes if needed
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfessorRoutingModule { }
