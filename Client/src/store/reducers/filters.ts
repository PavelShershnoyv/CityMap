import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {RootState} from "../store";

export enum Filters {
    Administration = 'administration',
    Education = 'education',
    Medicine = 'medicine',
    Production = 'production',
    Security = 'security',
    Culture = 'culture',
    Sport = 'sport',
    Other = 'other'
}

interface IFilterState {
    filters: Filters[];
}

const initialState: IFilterState = {
    filters: [
        Filters.Administration,
        Filters.Culture,
        Filters.Education,
        Filters.Medicine,
        Filters.Security,
        Filters.Other,
        Filters.Production,
        Filters.Sport
    ]
}

export const filterSlice = createSlice({
    name: 'filter',
    initialState: initialState,
    reducers: {
        setFilters(state, action: PayloadAction<Filters[]>) {
            state.filters = action.payload;
        }
    }
});

export const getCurrentFilters = (state: RootState) => state.filter.filters;