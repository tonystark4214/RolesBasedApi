import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';

@Component({
  selector: 'app-add-res',
  templateUrl: './add-res.component.html',
  styleUrls: ['./add-res.component.css']
})
export class AddResComponent implements OnInit {
  constructor(private service: ServiceService, private router: Router, private route:ActivatedRoute) { }
  resForm: any = FormGroup;
  @Input() Researcher={resName:'',resEmail:'',password:''};
  @Input() Id:any;
  ngOnInit(): void {
    let builder = new FormBuilder();
    this.resForm = builder.group({
      resName: new FormControl('', [Validators.minLength(2), Validators.required,Validators.maxLength(15)]),
      resEmail: new FormControl('', [Validators.minLength(2), Validators.email, Validators.required,Validators.maxLength(15)]),
      password: new FormControl('', [Validators.minLength(2), Validators.required,Validators.maxLength(15)]),
    });       
  }
  PostResearcher(data: any) {
    data.resUserName = data.resName.slice(0, 3) + data.resEmail.slice(0, 3);
    data.roleId = 2;
    data.resId=this.Id;
    console.log(data.resUserName);
    this.service.PostResearcher(data).subscribe((res: any) => {
      console.log(res);
      this.router.navigate(['./professor/researcherList'])
    })
  }
}
