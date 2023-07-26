import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ResearcherRoutingModule } from './researcher-routing.module';
import { ResearcherComponent } from './researcher.component';
import { ResearcherListComponent } from './researcherList/researcher-list/researcher-list.component';


@NgModule({
  declarations: [
    ResearcherComponent,
    ResearcherListComponent
  ],
  imports: [
    CommonModule,
    ResearcherRoutingModule,ReactiveFormsModule
  ]
})
export class ResearcherModule { }
