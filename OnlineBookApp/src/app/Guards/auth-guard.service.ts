import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{
  constructor(private router :Router){}
    canActivate(route:ActivatedRouteSnapshot,state:RouterStateSnapshot):boolean{
        if(this.isLoggedIn()){
            return true;
        }
        this.router.navigate(['/home']);
        return false;
    }
    public isLoggedIn():boolean{
        let status=false;
        if(sessionStorage.getItem('isLoggedIn')=="true"){
            status=true;
        }
        else{
            status=false;
        }
        return status;
    }
}
