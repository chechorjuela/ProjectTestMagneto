import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, of} from 'rxjs';
import {MeasurenmentModel} from '../store/models/measurenment.model';
import {catchError, map} from "rxjs/operators";
import {LocalStorageService} from "../utils/local-storage.service";
import {HttpHelperService} from "../utils/http-helper.service";
import {API_ROUTES} from "../shared/api-routes";

@Injectable({
  providedIn: 'root'
})
export class MeasurenmentService {

  constructor(private http: HttpClient, private httpHelper: HttpHelperService, private localStorageService: LocalStorageService) {
  }

  getMeasurenments(): Observable<MeasurenmentModel[]> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.httpHelper.get<MeasurenmentModel[]>(`${API_ROUTES.MEASURENMENT.GET_MEASURENMENTS}`).pipe(
      map((response: any) => {
        return response.data;
      }),
      catchError(error => {
        return of(error);
      })
    );
  }

  getMeasurenmentsByUser(): Observable<MeasurenmentModel[]> {
    const {userId} = this.localStorageService.get('user');

    return this.httpHelper.get<any>(`${API_ROUTES.MEASURENMENT.GET_MEASURENMENTS_BY_USER(userId)}`)
      .pipe(
        map(response => {
          return response.data;
        }),
        catchError(error => {
          return of(error);
        })
      );
  }

  postMeasurenment(Measurenment: MeasurenmentModel): Observable<MeasurenmentModel> {

    return this.httpHelper.post<any>(`${API_ROUTES.MEASURENMENT.POST_MEASURENMENT}`, Measurenment)
      .pipe(
        map(response => {
          return response.data;
        }),
        catchError(error => {
          return of(error);
        })
      );
  }

  putMeasurenment(Measurenment: MeasurenmentModel): Observable<MeasurenmentModel> {

    return this.httpHelper.put<any>(`${API_ROUTES.MEASURENMENT.PUT_MEASURENMENT(Measurenment.Id ? Measurenment.Id.toString() : "")}`, Measurenment)
      .pipe(
        map(response => {
          return response.data;
        }),
        catchError(error => {
          return of(error);
        })
      );
  }

  deleteMeasurenment(Measurenment: MeasurenmentModel): Observable<MeasurenmentModel> {

    return this.httpHelper.delete<any>(`${API_ROUTES.MEASURENMENT.DELETE_MEASURENMENT(Measurenment.Id ? Measurenment.Id.toString() : "")}`)
      .pipe(
        map(response => {
          return response.data;
        }),
        catchError(error => {
          return of(error);
        })
      );
  }
}
