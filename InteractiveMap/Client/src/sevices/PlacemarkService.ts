import { createApi, BaseQueryFn } from '@reduxjs/toolkit/query/react';
import { IPlacemark, ILayer, IFullPlacemark } from '../types/PlacemarkTypes';
import axios, { AxiosError, AxiosRequestConfig } from 'axios';

interface IMarkRequest extends IFullPlacemark {
    layerId: number;
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
        getLayer: build.query<ILayer[], void>({ 
            query: () => ({ 
                url: 'layers',
                method: 'GET'
            })
        }),
        getPlacemarks: build.query<IPlacemark[], number>({
            query: (id) => ({
                url: `marks`,
                method: 'GET',
                params: {
                    layerId: id
                }
            })
        }),
        createPlacemark: build.mutation<number, IMarkRequest>({
            query: (body) => ({
                url: 'marks',
                method: 'POST',
                body
            })
        })
    })
});

export const { useGetPlacemarksQuery, useGetLayerQuery, useCreatePlacemarkMutation } = placemarkApi;


