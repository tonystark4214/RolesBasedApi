import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor{

  constructor() { }
  apikey:any
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.apikey=localStorage.getItem("token")
    request = request.clone({
      setHeaders: {
        Authorization: "Bearer "+this.apikey
      }
    });
    
    return next.handle(request);
  }
}
