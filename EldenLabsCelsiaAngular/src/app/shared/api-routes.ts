import {environment} from "../../environments/environment";

const BASE_API_URL = environment.apiUrl;

export const API_ROUTES = {
  AUTH: {
    BASE: `${BASE_API_URL}/auth`,
    SIGNIN: `${BASE_API_URL}/auth/signin`,
    SIGNUP: `${BASE_API_URL}/auth/signup`,
    LOGOUT: `${BASE_API_URL}/auth/logout`,
  },
  MEASURENMENT: {
    BASE: `${BASE_API_URL}/measurenment`,
    GET_MEASURENMENTS: `${BASE_API_URL}/measurenment`,
    GET_MEASURENMENTS_BY_USER: (userId: string) => `${BASE_API_URL}/measurenment/getByUser/${userId}`,
    POST_MEASURENMENT: `${BASE_API_URL}/measurenment`,
    PUT_MEASURENMENT: (MEASURENMENTId: string) => `${BASE_API_URL}/measurenment/${MEASURENMENTId}`,
    DELETE_MEASURENMENT: (MEASURENMENTId: string) => `${BASE_API_URL}/measurenment/${MEASURENMENTId}`,
  },
};
