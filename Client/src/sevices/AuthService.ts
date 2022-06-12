import { createApi } from '@reduxjs/toolkit/query/react';
import { axiosBaseQuery } from './PlacemarkService';
import { IRegisterRequest, ILoginRequest } from '../types/AuthTypes';

const accountApi = createApi({
    reducerPath: 'accountApi',
    baseQuery: axiosBaseQuery({ baseUrl: 'http://localhost:4683/api/account/' }),
    endpoints: (build) => ({
        register: build.query<void, IRegisterRequest>({
            query: (body) => ({
                data: body,
                url: 'register',
                method: 'POST',
            })
        }),
        login: build.query<void, ILoginRequest>({
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