import { createApi, BaseQueryFn } from '@reduxjs/toolkit/query/react';
import { IPlacemark, IProposalPlacemark, ITypedPlacemark, IUnionRequestsType, IEventPlacemark } from '../types/PlacemarkTypes';
import axios, { AxiosError, AxiosRequestConfig } from 'axios';

export interface ICreateRequest {
    body: IUnionRequestsType;
    layer: string;
}

export interface ICurrentPlacemarkInfo {
    id: number;
    layer: string;
}

export const instance = axios.create({
    headers: {
        "Content-type": 'application/json'
    }
});

export const axiosBaseQuery = ({ baseUrl }: { baseUrl: string } = { baseUrl: '' }): BaseQueryFn<{
    url: string
    method: AxiosRequestConfig['method']
    data?: AxiosRequestConfig['data']
    params?: AxiosRequestConfig['params']
}> => async ({ url, method, data, params }) => {
    try {
        const result = await instance.request({ url: baseUrl + url, method, data, params });
        return { data: result.data }
    } catch (axiosError) {
        let err = axiosError as AxiosError
        return {
            error: {
                status: err.response?.status,
                data: err.response?.data || err.message,
            },
        }
    }
}

export const placemarkApi = createApi({
    reducerPath: 'placemarkApi',
    baseQuery: axiosBaseQuery({ baseUrl: 'http://localhost:4683/api/' }),
    tagTypes: ['Placemark'],
    endpoints: (build) => ({
        getDefaultPlacemarks: build.query<ITypedPlacemark[], string>({
            query: (type) => ({
                url: `${type}-marks`,
                method: 'GET'
            }),
            providesTags: result => ['Placemark']
        }),
        getProposalPlacemarks: build.query<IProposalPlacemark[], void>({
            query: () => ({
                url: 'proposals-marks',
                method: 'GET'
            }),
            providesTags: result => ['Placemark']
        }),
        getEvents: build.query<IEventPlacemark[], void>({
            query: () => ({
                url: 'events-marks',
                method: 'GET'
            }),
            providesTags: result => ['Placemark']
        }),
        getUserPlacemarks: build.query<IPlacemark[], void>({
            query: () => ({
                url: 'user-marks',
                method: 'GET'
            }),
            providesTags: result => ['Placemark']
        }),
        getCurrentPlacemark: build.query<IPlacemark, ICurrentPlacemarkInfo>({
            query: (info) => ({
                url: `${info.layer}-marks/${info.id}`,
                method: 'GET'
            })
        }),
        createPlacemark: build.mutation<number, ICreateRequest>({
            query: (req) => {
                const bodyFormData = new FormData();
                Object.keys(req.body).forEach((key) => {
                    //@ts-ignore
                    bodyFormData.append(key, req.body[key]);
                });

                bodyFormData.append('position.latitude', req.body.position.latitude.toString());
                bodyFormData.append('position.longitude', req.body.position.longitude.toString());
                return {
                    url: `${req.layer}-marks`,
                    method: 'POST',
                    data: bodyFormData
                }
            },
            invalidatesTags: ['Placemark']
        })
    })
});

export const {
    useGetCurrentPlacemarkQuery,
    useGetDefaultPlacemarksQuery,
    useGetProposalPlacemarksQuery,
    useGetEventsQuery,
    useGetUserPlacemarksQuery,
    useCreatePlacemarkMutation
} = placemarkApi;


