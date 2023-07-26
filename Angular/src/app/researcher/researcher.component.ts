import { Component } from '@angular/core';
import { ServiceService } from '../Service/service.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-researcher',
  templateUrl: './researcher.component.html',
  styleUrls: ['./researcher.component.css']
})
export class ResearcherComponent {
  constructor(private service: ServiceService,private router:Router) { }
  IsForm:boolean=true;
  resForm:any = FormGroup;
  ngOnInit(): void {
    this.IsForm=true;
    let builder = new FormBuilder();
    this.resForm = builder.group({
      resName: new FormControl('', [Validators.minLength(2),Validators.required,Validators.maxLength(15)]),
      resEmail: new FormControl('', [Validators.minLength(2),Validators.email,Validators.required,Validators.maxLength(15)]),
      password: new FormControl('', [Validators.minLength(2),Validators.required,Validators.maxLength(15)]),
    });
  }

  PostResearcher(data:any){
    data.resUserName=data.resName.slice(0,3)+data.resEmail.slice(0,3);
    data.roleId=2;
    console.log(data.resUserName);
    this.service.PostResearcher(data).subscribe((res:any)=>{
      console.log(res); 
      this.router.navigate(['./researcher/resList'])    
    })
  }
  logOut(){
    this.router.navigate([''])
  }
  showHide(){
    this.IsForm=false;
  }
  show(){
    this.IsForm=true;
  }
}
