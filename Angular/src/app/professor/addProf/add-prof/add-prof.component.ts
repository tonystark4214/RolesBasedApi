import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';

@Component({
  selector: 'app-add-prof',
  templateUrl: './add-prof.component.html',
  styleUrls: ['./add-prof.component.css']
})
export class AddProfComponent implements OnInit {
  constructor(private service: ServiceService,private router:Router) { }
  profForm:any = FormGroup;
  ngOnInit(): void {    
    let builder = new FormBuilder();
    this.profForm = builder.group({
      resName: new FormControl('', [Validators.minLength(2),Validators.required,Validators.maxLength(15)]),
      resEmail: new FormControl('', [Validators.minLength(2),Validators.email,Validators.required,Validators.maxLength(15)]),
      password: new FormControl('', [Validators.minLength(2),Validators.required,Validators.maxLength(15)]),
    });
  }

  PostProfessor(data: any) {
    data.resUserName = data.resName.slice(0, 3) + data.resEmail.slice(0, 3);
    data.roleId = 1;
    console.log(data.resUserName);
    this.service.PostProfessor(data).subscribe((res: any) => {
      console.log(res);
      this.router.navigate(['/professor'])
    })

  }
}

