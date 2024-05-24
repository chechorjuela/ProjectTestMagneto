import {Injectable} from '@angular/core';
import {Actions, createEffect, ofType} from '@ngrx/effects';
import {of} from 'rxjs';
import {catchError, map, mergeMap, tap, switchMap} from 'rxjs/operators';
import {MeasurenmentService} from '../../services/measurenment.service';
import {
  deleteMeasurenmentRequest,
  getAllMeasurenmentFailure,
  getAllMeasurenmentRequest,
  getAllMeasurenmentSuccess,
  getMeasurenmentByUserRequest,
  getMeasurenmentByUserSuccess,
  postMeasurenmentRequest,
  postMeasurenmentSuccess,
  putMeasurenmentRequest,
  putMeasurenmentSuccess,
  deleteMeasurenmentSuccess
} from '../actions/measurenment.actions';
import {Router} from "@angular/router";
import {SnackbarService} from "../../utils/snackbar.service";

@Injectable()
export class MeasurenmentEffects {

  constructor(
    private actions$: Actions,
    private snackbarService: SnackbarService,
    private MeasurenmentService: MeasurenmentService) {
  }

  private handleError = (error: any) => {
    return of(getAllMeasurenmentFailure({error}));
  };

  getAllMeasurenmentRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getAllMeasurenmentRequest),
      mergeMap(() =>
        this.MeasurenmentService.getMeasurenments().pipe(
          tap((Measurenments) => console.info('Measurenments received from API:', Measurenments)),
          map((Measurenments) => getAllMeasurenmentSuccess({Measurenments})),
          catchError(this.handleError)
        )
      )
    )
  );

  getMeasurenmentByUserRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getMeasurenmentByUserRequest),
      mergeMap(() =>
        this.MeasurenmentService.getMeasurenmentsByUser().pipe(
          tap((Measurenments) => console.info('Measurenments received from API:', Measurenments)),
          map((Measurenments) => getMeasurenmentByUserSuccess({Measurenments})),
          catchError(this.handleError)
        )
      )
    )
  );

  postMeasurenmentRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(postMeasurenmentRequest),
      mergeMap((action) =>
        this.MeasurenmentService.postMeasurenment(action.Measurenment).pipe(
          map((Measurenment) => postMeasurenmentSuccess({Measurenment})),
          catchError((error) => {
            this.snackbarService.showError('Failed to create Measurenment');
            return of(getAllMeasurenmentFailure({error}));
          })
        )
      )
    )
  );

  putMeasurenmentRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(putMeasurenmentRequest),
      mergeMap((action) =>
        this.MeasurenmentService.putMeasurenment(action.Measurenment).pipe(
          map((Measurenment) => putMeasurenmentSuccess({Measurenment})),
          catchError((error) => {
            this.snackbarService.showError('Failed to update Measurenment');
            return of(getAllMeasurenmentFailure({error}));
          })
        )
      )
    )
  );

  deleteMeasurenmentRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteMeasurenmentRequest),
      tap((action) => console.info('Action received:', action)),
      mergeMap((action) =>
        this.MeasurenmentService.deleteMeasurenment(action.Measurenment).pipe(
          map(() => deleteMeasurenmentSuccess({Measurenment: action.Measurenment})),
          catchError((error) => {
            this.snackbarService.showError('Failed to delete Measurenment');
            return of(getAllMeasurenmentFailure({error}));
          })
        )
      )
    )
  );

  refreshMeasurenments$ = createEffect(() =>
    this.actions$.pipe(
      ofType(postMeasurenmentSuccess, putMeasurenmentSuccess, deleteMeasurenmentSuccess), // Listen for specific success actions
      switchMap(() => [
        getMeasurenmentByUserRequest(), // Dispatch action to get Measurenments by user after saving Measurenment
        getAllMeasurenmentRequest() // Refresh all Measurenments
      ])// Dispatch getAllMeasurenmentRequest action after specific success actions
    )
  );
}
