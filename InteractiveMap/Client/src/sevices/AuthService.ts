import { createApi } from '@reduxjs/toolkit/query/react';
import { axiosBaseQuery } from './PlacemarkService';
import { IRegisterRequest, ILoginRequest } from '../types/AuthTypes';

const accountApi = createApi({
    reducerPath: 'accountApi',
    baseQuery: axiosBaseQuery({ baseUrl: 'http://localhost:4683/api/account' }),
    endpoints: (build) => ({
        register: build.query<void, IRegisterRequest>({
            query: (body) => ({
                url: 'register',
                method: 'POST',
            })
        }),
        login: build.query<void, ILoginRequest>({
            query: (body) => ({
                url: 'login',
                method: 'POST',
            })
        }),
        logout: build.query<void, void>({
            query: (body) => ({
                url: 'logout',
                method: 'POST',
            })
        })
    })
});

export const { useLazyRegisterQuery, useLazyLoginQuery, useLazyLogoutQuery } = accountApi;