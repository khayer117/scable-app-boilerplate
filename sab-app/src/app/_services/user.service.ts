import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SiteConfig } from '../_models/site-config';
import { User } from '../_models';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<User[]>(`${SiteConfig.API_Url}/users`);
    }

    register(user: User) {
        return this.http.post(`${SiteConfig.API_Url}/users/register`, user);
    }

    delete(id: number) {
        return this.http.delete(`${SiteConfig.API_Url}/users/${id}`);
    }
}
