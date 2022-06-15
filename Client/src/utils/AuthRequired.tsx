import React from 'react';
import { Navigate, Outlet, Route } from 'react-router-dom';
import { useAuth } from '../hooks/useAuth';

export const AuthRequeired: React.FC = () => {
    const { isAuthenticated } = useAuth();

    if (!isAuthenticated) {
        return <Navigate to='/account/login' replace={true} />
    }

    return <Outlet />;
}