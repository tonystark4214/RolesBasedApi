import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ServiceService } from '../Service/service.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  constructor(private service:ServiceService,private router:Router){}
  form:any = FormGroup;
  ngOnInit(): void {
    // localStorage.removeItem('token');
    let builder = new FormBuilder();
    this.form = builder.group({
      userName: new FormControl('', [Validators.minLength(2)]),
      password: new FormControl('', [Validators.minLength(2)]),
    });
  }

  UserName:string='';
  Password:string='';
  Role:string='';
  Token:string='';

  Login(formValue:object){
    console.log(formValue);
    this.service.Login(formValue).subscribe((res:any)=>{
      this.Role=res.roles[0].roleName;
      this.Token=res.token;
      const helper = new JwtHelperService();
      const decodedToken = helper.decodeToken(this.Token);
      console.log(decodedToken);
      
      console.log(decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
      var dataArray = Object.keys(decodedToken).map(val => decodedToken[val]);
      console.log(dataArray[3]);
      
      localStorage.setItem('token',this.Token)
      if(this.Role=='Professor'){
        this.router.navigate(['/professor'])
      }
      else if(this.Role=='Researcher'){
        this.router.navigate(['/researcher'])
      }
    })

  }
}
