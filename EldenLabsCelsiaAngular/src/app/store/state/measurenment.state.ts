import {MeasurenmentModel} from "../models/measurenment.model";

export interface MeasurenmentState {
  MeasurenmentsUser: MeasurenmentModel[];
  MeasurenmentsAll: MeasurenmentModel[];
  error: string | null;
  loading: boolean;
}

export const initialMeasurenmentState: MeasurenmentState = {
  MeasurenmentsUser: [],
  MeasurenmentsAll: [],
  error: null,
  loading: false,
};
