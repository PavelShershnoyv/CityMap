import { createApi, BaseQueryFn } from '@reduxjs/toolkit/query/react';
import { IPlacemark, IProposalPlacemark, ITypedPlacemark, IUnionRequestsType } from '../types/PlacemarkTypes';
import axios, { AxiosError, AxiosRequestConfig } from 'axios';

export interface ICreateRequest {
    body: IUnionRequestsType;
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
    endpoints: (build) => ({
        getPlacemarks: build.query<IPlacemark[] | IProposalPlacemark[] | ITypedPlacemark[], string>({
            query: (type) => ({
                url: `${type}-marks`,
                method: 'GET'
            })
        }),
        createPlacemark: build.mutation<number, ICreateRequest>({
            query: (req) => {
                const bodyFormData = new FormData();
                Object.keys(req.body).forEach((key) => {
                    //@ts-ignore
                    bodyFormData.append(key, req.body[key]);
                })
                
                return {
                    url: `${req.layer}-marks`,
                    method: 'POST',
                    data: bodyFormData
                }
            }
        })
    })
});

export const { useGetPlacemarksQuery, useCreatePlacemarkMutation } = placemarkApi;


