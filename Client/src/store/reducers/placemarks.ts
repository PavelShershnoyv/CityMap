import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import { IPlacemark } from '../../types/PlacemarkTypes';
import { RootState } from '../store';

interface IPlacemarkState {
    placemarks: IPlacemark[];
    currentPlacemarkId: number;
    isLoading: boolean;
    error: string;
}

const initialState: IPlacemarkState = {
    placemarks: [],
    currentPlacemarkId: 0,
    isLoading: false,
    error: ''
}

export const placemarkSlice = createSlice({
    name: 'placemark',
    initialState: initialState,
    reducers: {
        
    }
});