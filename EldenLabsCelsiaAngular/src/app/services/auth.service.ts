import {Injectable} from '@angular/core';
import {Observable, of, throwError} from "rxjs";
import {catchError, map} from "rxjs/operators";
import {LocalStorageService} from "../utils/local-storage.service";
import {UserModel} from "../store/models/user.model";
import {HttpHelperService} from "../utils/http-helper.service";
import {MeasurenmentModel} from "../store/models/measurenment.model";
import {API_ROUTES} from "../shared/api-routes";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isAuthenticated = false;

  constructor(
    private httpHelper: HttpHelperService,
    private localStorageService: LocalStorageService,
  ) {
  }

  checkAuthenticated(): boolean {
    const user = this.localStorageService.get('user');
    if (user) {
      if (user.token)
        this.isAuthenticated = true;
    }
    return this.isAuthenticated;

  }

  logout() {
    this.isAuthenticated = false;
    return this.isAuthenticated;

  }

  login(credencials: any): Observable<UserModel> {

    return this.httpHelper.post<MeasurenmentModel[]>(`${API_ROUTES.AUTH.SIGNIN}`, credencials).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(error => {
        return throwError(error);
      })
    );
  }

  signUp(credencials: any): Observable<any> {

    return this.httpHelper.post<any>(`${API_ROUTES.AUTH.SIGNUP}`, credencials).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(error => {
        return throwError(error);
      })
    );
  }
}
