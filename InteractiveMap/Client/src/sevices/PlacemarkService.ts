import { createApi, BaseQueryFn } from '@reduxjs/toolkit/query/react';
import { IPlacemark, ILayer, IFullPlacemark } from '../types/PlacemarkTypes';
import axios, { AxiosError, AxiosRequestConfig } from 'axios';


export interface IMarkRequest extends IFullPlacemark {
    layerType: number;
}

export const instance = axios.create({
    headers: {
        "Content-type": "application/json"
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
    baseQuery: axiosBaseQuery({baseUrl: 'http://localhost:4683/api/'}),
    endpoints: (build) => ({
        getPlacemarks: build.query<IPlacemark[], number>({
            query: (id) => ({
                url: `marks`,
                method: 'GET',
                params: {
                    layerType: id
                }
            })
        }),
        createPlacemark: build.mutation<number, IMarkRequest>({
            query: (body) => ({
                url: 'marks',
                method: 'POST',
                data: body
            })
        })
    })
});

export const { useGetPlacemarksQuery, useCreatePlacemarkMutation } = placemarkApi;


