
import { Injectable } from "@angular/core";
import * as moment from "moment";
import { AppUser } from "../models/app-user";

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {

    constructor(private http: HttpClient) {

    }

    login(username:string, password:string ) {
        return this.http.post<AppUser>('/api/login', {username, password})
            .do(res => this.setSession)
            .shareReplay();
    }

    private setSession(authResult) {
        const expiresAt = moment().add(authResult.expiresIn,'second');

        localStorage.setItem('id_token', authResult.idToken);
        localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()) );
    }

    logout() {
        localStorage.removeItem("id_token");
        localStorage.removeItem("expires_at");
    }

    public isLoggedIn() {
        return moment().isBefore(this.getExpiration());
    }

    isLoggedOut() {
        return !this.isLoggedIn();
    }

    getExpiration() {
        const expiration = localStorage.getItem("expires_at") + '';
        const expiresAt = JSON.parse(expiration);
        return moment(expiresAt);
    }
}
