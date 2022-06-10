import {TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../store/store";
import { bindActionCreators } from 'redux';
import {placemarkSlice} from '../store/reducers/placemarks';
import {modalSlice} from '../store/reducers/modal';

const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
export const useAppAction = () => {
    const dispatch = useAppDispatch();

    return bindActionCreators({
        ...placemarkSlice.actions
    }, dispatch);
}