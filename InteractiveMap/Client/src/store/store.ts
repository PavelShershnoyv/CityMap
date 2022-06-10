import {configureStore} from '@reduxjs/toolkit';
import { placemarkApi } from '../sevices/PlacemarkService';
import { modalSlice } from './reducers/modal';
import { placemarkSlice } from './reducers/placemarks';

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const store = configureStore({
    reducer: {
        placemark: placemarkSlice.reducer,
        modal: modalSlice.reducer,
        [placemarkApi.reducerPath]: placemarkApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(placemarkApi.middleware)
});