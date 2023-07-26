import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResearcherComponent } from './researcher.component';
import { ResearcherListComponent } from './researcherList/researcher-list/researcher-list.component';

const routes: Routes = [{ path: '', component: ResearcherComponent ,children: [
  {
    path: 'resList',
    component: ResearcherListComponent, // Use the InnerComponent here
  }]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResearcherRoutingModule { }
 