import React from 'react';
import { Header } from '../header/header';
import { Outlet } from 'react-router-dom';
import { MainMap } from '../maps/mainMap';
 

export const Layout = () => {
    return (
        <>
            <Header />
            <MainMap>
                <Outlet />
            </MainMap>
        </>
    )
}