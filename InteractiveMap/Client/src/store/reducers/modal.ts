import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import { RootState } from '../store';

interface IModalState {
    isActive: boolean;
    contentType: string;
}

const initialState: IModalState = {
    isActive: false,
    contentType: ''
}

export const modalSlice = createSlice({
    name: 'modal',
    initialState: initialState,
    reducers: {
        openModal: (state) => {
            state.isActive = true;
        },
        closeModal: (state) => {
            state.isActive = false;
        }
    }
});

export const {openModal, closeModal} = modalSlice.actions;
export const getModalActive = (state: RootState): boolean => state.modal.isActive;