import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../store/store";
import { bindActionCreators } from 'redux';
import { placemarkSlice } from '../store/reducers/placemarks';
import { filterSlice } from "../store/reducers/filters";
import { authSlice } from "../store/reducers/auth";

const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
export const useAppAction = () => {
    const dispatch = useAppDispatch();

    return bindActionCreators({
        ...authSlice.actions,
        ...placemarkSlice.actions,
        ...filterSlice.actions
    }, dispatch);
}