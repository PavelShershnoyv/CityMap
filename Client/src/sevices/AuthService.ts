import { createApi } from '@reduxjs/toolkit/query/react';
import { IRegisterRequest, ILoginRequest, IUser } from '../types/AuthTypes';
import axios, {AxiosError, AxiosRequestConfig} from "axios";
import {BaseQueryFn} from "@reduxjs/toolkit/dist/query/react";
import {axiosBaseQuery} from "./PlacemarkService";

const accountApi = createApi({
    reducerPath: 'accountApi',
    baseQuery: axiosBaseQuery({ baseUrl: 'http://localhost:4683/api/account/' }),
    endpoints: (build) => ({
        register: build.query<IUser, IRegisterRequest>({
            query: (body) => ({
                data: body,
                url: 'register',
                method: 'POST',
            }),
        }),
        login: build.query<IUser, ILoginRequest>({
            query: (body) => ({
                data: body,
                url: 'login',
                method: 'POST',
            })
        })
    })
});

export const { useLazyRegisterQuery, useLazyLoginQuery } = accountApi;

export default accountApi;