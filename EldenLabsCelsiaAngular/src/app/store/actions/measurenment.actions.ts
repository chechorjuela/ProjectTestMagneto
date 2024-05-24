import {createAction, props} from '@ngrx/store';
import {MeasurenmentModel} from '../models/measurenment.model';
import {
  MeasurenmentDeleteFailed,
  MeasurenmentDeleteRequest, MeasurenmentDeleteSuccess,
  MeasurenmentGetAllFailed,
  MeasurenmentGetAllRequest,
  MeasurenmentGetAllSuccess,
  MeasurenmentGetUserFailed,
  MeasurenmentGetUserRequest,
  MeasurenmentGetUserSuccess, MeasurenmentPostFailed, MeasurenmentPostRequest, MeasurenmentPostSuccess,
  MeasurenmentPutFailed,
  MeasurenmentPutRequest,
  MeasurenmentPutSuccess
} from "../consts/measurenment.const";

export const getAllMeasurenmentRequest = createAction(MeasurenmentGetAllRequest);
export const getAllMeasurenmentSuccess = createAction(MeasurenmentGetAllSuccess, props<{ Measurenments: MeasurenmentModel[] }>());
export const getAllMeasurenmentFailure = createAction(MeasurenmentGetAllFailed, props<{ error: any }>());

export const getMeasurenmentByUserRequest = createAction(MeasurenmentGetUserRequest);
export const getMeasurenmentByUserSuccess = createAction(MeasurenmentGetUserSuccess, props<{ Measurenments: MeasurenmentModel[] }>());
export const getMeasurenmentByUserFailure = createAction(MeasurenmentGetUserFailed, props<{ error: any }>());

export const postMeasurenmentRequest = createAction(MeasurenmentPostRequest, props<{ Measurenment: MeasurenmentModel }>());
export const postMeasurenmentSuccess = createAction(MeasurenmentPostSuccess, props<{ Measurenment: MeasurenmentModel }>());
export const postMeasurenmentFailure = createAction(MeasurenmentPostFailed, props<{ error: any }>());

export const putMeasurenmentRequest = createAction(MeasurenmentPutRequest, props<{ Measurenment: MeasurenmentModel }>());
export const putMeasurenmentSuccess = createAction(MeasurenmentPutSuccess, props<{ Measurenment: MeasurenmentModel }>());
export const putMeasurenmentFailure = createAction(MeasurenmentPutFailed, props<{ error: any }>());

export const deleteMeasurenmentRequest = createAction(MeasurenmentDeleteRequest, props<{ Measurenment: MeasurenmentModel }>());
export const deleteMeasurenmentSuccess = createAction(MeasurenmentDeleteSuccess, props<{ Measurenment: MeasurenmentModel }>());
export const deleteMeasurenmentFailure = createAction(MeasurenmentDeleteFailed, props<{ error: any }>());
