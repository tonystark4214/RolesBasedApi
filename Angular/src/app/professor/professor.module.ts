import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfessorRoutingModule } from './professor-routing.module';
import { ProfessorComponent } from './professor.component';
import { ResearcherListComponent } from './resercherList/researcher-list/researcher-list.component';
import { LandingPageComponent } from './landingPage/landing-page/landing-page.component';
import { AddProfComponent } from './addProf/add-prof/add-prof.component';
import { AddResComponent } from './addRes/add-res/add-res.component';
import { HostDirectiveDirective } from '../host-directive.directive';


@NgModule({
  declarations: [
    ProfessorComponent,
    ResearcherListComponent,
    LandingPageComponent,
    AddProfComponent,
    AddResComponent,HostDirectiveDirective
  ],
  imports: [
    CommonModule,
    ProfessorRoutingModule,ReactiveFormsModule
  ]
})
export class ProfessorModule { }
