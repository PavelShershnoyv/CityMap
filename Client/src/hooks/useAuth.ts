import useCookie from 'react-use-cookie';
import { useAppSelector } from './redux';
import { getCurrentUser } from '../store/reducers/auth';
import { IUser } from '../types/AuthTypes';

export interface IAuthenticatedUser {
    isAuthenticated: boolean;
    user?: IUser;
}

export const useAuth = (): IAuthenticatedUser => {
    const [authCookie] = useCookie('Auth');
    const user = useAppSelector(getCurrentUser);

    return {
        isAuthenticated: !!authCookie,
        user: user.user
    }
}