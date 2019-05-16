import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { JwtService } from '../services/authorisation/jwt.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(private tokenService: JwtService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        req = req.clone({
            setHeaders: {
                Authorization: `Bearer ${this.tokenService.getRawToken()}`
            }
        });

        console.log(req);

        return next.handle(req);
    }
}