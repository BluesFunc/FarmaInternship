import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = '/auth/Auth';

  constructor(private http: HttpClient) {}

  login(data: { mail: string; password: string }) {
    return this.http.post<{ accessToken: string; refreshToken: string }>(
      `${this.apiUrl}/Login`,
      data,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }), 
      }
    ).pipe(
      tap(res => this.setToken(res.accessToken))
    );
  }

  register(data: { name: string; mail: string; password: string }) {
    return this.http.post<{ accessToken: string; refreshToken: string }>(
      `${this.apiUrl}/Register`,
      data,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }),
      }
    ).pipe(
      tap(res => this.setToken(res.accessToken))
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  getUserFromToken() {
    const token = this.getToken();
    if (!token) return null;

    try {
      return jwtDecode(token);
    } catch {
      return null;
    }
  }
}
