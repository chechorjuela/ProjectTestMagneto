import {createReducer, on} from '@ngrx/store';
import {
  deleteMeasurenmentRequest,
  getAllMeasurenmentRequest,
  getAllMeasurenmentSuccess,
  getMeasurenmentByUserRequest,
  getMeasurenmentByUserSuccess, postMeasurenmentFailure, postMeasurenmentRequest, postMeasurenmentSuccess
} from "../actions/measurenment.actions";
import {initialMeasurenmentState} from "../state/measurenment.state";

const _measurenmentReducer = createReducer(
  initialMeasurenmentState,
  on(getAllMeasurenmentRequest, state => ({
    ...state,
    loading: true
  })),
  on(getAllMeasurenmentSuccess, (state, {Measurenments}) => ({
    ...state,
    MeasurenmentsAll: Measurenments,
    loading: false,
    error: null
  })),
  on(getMeasurenmentByUserRequest, state => ({
    ...state,
    loading: true,
    error: null
  })),
  on(getMeasurenmentByUserSuccess, (state, {Measurenments}) => ({
    ...state,
    MeasurenmentsUser: Measurenments,
    loading: false,
    error: null
  })),
  on(postMeasurenmentRequest, (state, {Measurenment}) => ({
    ...state,
    loading: true,
    error: null
  })),
  on(postMeasurenmentSuccess, state => ({
    ...state,
    loading: false,
    error: null
  })),
  on(postMeasurenmentFailure, state => ({
    ...state,
    MeasurenmentsAll: state.MeasurenmentsAll,
    loading: false,
    error: null
  })),
  on(deleteMeasurenmentRequest, state => ({
    ...state,
    loading: true,
    error: null
  })),
);

export function measurenmentReducer(state: any, action: any) {
  return _measurenmentReducer(state, action);
}
