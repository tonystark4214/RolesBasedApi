import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) { }

  Login(data:any){
    return this.http.post("http://localhost:5265/VerifyCredentials",data);
  }

  GetResearcherList(){
    return this.http.get("http://localhost:5265/GetResearcherList");
  }
  GetProfessorList(){
    return this.http.get("http://localhost:5265/GetProfessorList");
  }
  PostProfessor(data:object){
    return this.http.post("http://localhost:5265/PostProfessorData",data);
  }
  PostResearcher(data:object){
    return this.http.post("http://localhost:5265/PostResearcherData",data);
  }
  DeleteResearcher(id:number){
    return this.http.delete("http://localhost:5265/DeletingResearcher?id="+id);
  }
  DeleteProfessor(id:number){
    return this.http.delete("http://localhost:5265/DeletingProfessor?id="+id);
  }
  GetResearcherById(id:number){
    console.log("service",id);
    
    return this.http.get("http://localhost:5265/GetResearcherById?id="+id)
  }
  GetProfessorById(id:number){
    return this.http.get("http://localhost:5265/GetProfessorById?id="+id)
  }
}
