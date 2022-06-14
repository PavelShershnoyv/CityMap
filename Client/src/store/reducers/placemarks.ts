import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import {IEventPlacemark, IPlacemark, IProposalPlacemark, ITypedPlacemark} from '../../types/PlacemarkTypes';
import { RootState } from '../store';

interface IPlacemarkState {
    currentPlacemarkId: number;
    currentLayer: string;
}

const initialState: IPlacemarkState = {
    currentPlacemarkId: 0,
    currentLayer: 'present'
}

export const placemarkSlice = createSlice({
    name: 'placemark',
    initialState: initialState,
    reducers: {
        setCurrentPlacemarkInfo(state, payload: PayloadAction<{id: number, layer: string}>) {
            state.currentPlacemarkId = payload.payload.id;
            state.currentLayer = payload.payload.layer;
        }
    }
});

export const getCurrentPlacemarkInfo = (state: RootState) => state.placemark;
