import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';

@Component({
  selector: 'app-researcher-list',
  templateUrl: './researcher-list.component.html',
  styleUrls: ['./researcher-list.component.css']
})
export class ResearcherListComponent {
  constructor(private service:ServiceService,private router:Router) { }
  IsForm:boolean=false;
  IsTable:boolean=true;
  ResearcherList:any;
  Id:any=0;
  Researcher={resName:'',resEmail:'',password:''}
  
  ngOnInit(): void {
    this.IsForm=false;
    console.log(this.IsForm);
    
    this.ResearcherList=[]
    this.service.GetResearcherList().subscribe((res:any)=>{
      this.ResearcherList=res.getResearcherList;
      console.log(this.ResearcherList);   
    })
  }
}
