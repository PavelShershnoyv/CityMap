import { configureStore } from '@reduxjs/toolkit';
import { placemarkApi } from '../sevices/PlacemarkService';
import accountApi from '../sevices/AuthService';
import { placemarkSlice } from './reducers/placemarks';
import { filterSlice } from "./reducers/filters";


export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const store = configureStore({
    reducer: {
        placemark: placemarkSlice.reducer,
        filter: filterSlice.reducer,
        [placemarkApi.reducerPath]: placemarkApi.reducer,
        [accountApi.reducerPath]: accountApi.reducer,
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(placemarkApi.middleware).concat(accountApi.middleware)
});