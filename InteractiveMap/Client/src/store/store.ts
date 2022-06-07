import {configureStore} from '@reduxjs/toolkit';
import { placemarkApi } from '../sevices/PlacemarkService';

export const store = configureStore({
    reducer: {
        [placemarkApi.reducerPath]: placemarkApi.reducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(placemarkApi.middleware)
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;