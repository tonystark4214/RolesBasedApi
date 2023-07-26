import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';

@Component({
  selector: 'app-researcher-list',
  templateUrl: './researcher-list.component.html',
  styleUrls: ['./researcher-list.component.css']
})
export class ResearcherListComponent implements OnInit {

  constructor(private service:ServiceService,private router:Router) { }
  IsShow:boolean=false;
  IsTable:boolean=true;
  ResearcherList:any;
  Id:any=0;
  Researcher={resName:'',resEmail:'',password:''}
  
  ngOnInit(): void {
    this.ResearcherList=[]
    this.service.GetResearcherList().subscribe((res:any)=>{
      this.ResearcherList=res.getResearcherList;
      console.log(this.ResearcherList);   
    })
  }
  Delete(id:number){
    this.service.DeleteResearcher(id).subscribe((res:any)=>{
    console.log(res);
    this.ResearcherList=[]
    this.service.GetResearcherList().subscribe((res:any)=>{this.ResearcherList=res.getResearcherList;})
    }) 
  }
  Edit(id:any){
    this.Id=id;
    this.IsShow=true;
    this.IsTable=false;
    this.service.GetResearcherById(this.Id).subscribe((res:any)=>{
      console.log(res.getResearcher);
      this.Researcher=res.getResearcher;
    })
  }
}
