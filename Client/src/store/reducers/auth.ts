import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IUser } from "../../types/AuthTypes";
import { RootState } from "../store";

export const authSlice = createSlice({
    name: 'auth',
    initialState: null as unknown as IUser,
    reducers: {
        setUser(state, action: PayloadAction<IUser>) {
            state = action.payload
        }
    }
});

export const getCurrentUser = (state: RootState) => state.auth;