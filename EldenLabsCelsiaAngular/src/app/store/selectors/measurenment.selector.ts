import {createFeatureSelector, createSelector} from '@ngrx/store';
import {MeasurenmentState} from "../state/measurenment.state";
import {MeasurenmentModel} from "../models/measurenment.model";

export const Measurenment = createFeatureSelector<MeasurenmentState>('Measurenments');

export const selectMeasurenmentsUser = createSelector(
  Measurenment,
  (state: MeasurenmentState) => state.MeasurenmentsUser
);

export const selectMeasurenmentsAll = createSelector(
  Measurenment,
  (state: MeasurenmentState) => state.MeasurenmentsAll
);

export const selectMeasurenmentsLoading = createSelector(
  Measurenment,
  state => state.loading
);

export const selectMeasurenmentsError = createSelector(
  Measurenment,
  state => state.error as any
);
