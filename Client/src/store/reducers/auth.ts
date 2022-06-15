import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IUser } from "../../types/AuthTypes";
import { RootState } from "../store";

interface IUserTry {
    user?: IUser;
}

export const authSlice = createSlice({
    name: 'auth',
    initialState: {} as IUserTry,
    reducers: {
        setUser(state, action: PayloadAction<IUser>) {
            state.user = action.payload
        }
    }
});

export const getCurrentUser = (state: RootState) => state.auth;