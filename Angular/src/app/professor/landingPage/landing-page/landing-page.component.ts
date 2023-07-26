import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit{  
  constructor(private service:ServiceService,private router:Router){}
  ProfessorList:any;

  ngOnInit(): void {
    this.ProfessorList=[]
    this.service.GetProfessorList().subscribe((res:any)=>{
      this.ProfessorList=res.getProfessorList;
      console.log(this.ProfessorList);   
    })
  }
  Delete(id:number){
    this.service.DeleteProfessor(id).subscribe((res:any)=>{
    console.log(res);
    this.ProfessorList=[];
    this.service.GetProfessorList().subscribe((res:any)=>{this.ProfessorList=res.getProfessorList;})
    })
    
  }
}
