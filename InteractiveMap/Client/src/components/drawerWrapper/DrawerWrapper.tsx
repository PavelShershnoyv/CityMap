import React, { useState } from 'react';
import {Drawer} from 'antd';
import 'antd/dist/antd.css';

interface IDrawerWrapperProps {
    visible: boolean;
    onClose: () => void;
}

export const DrawerWrapper: React.FC<IDrawerWrapperProps> = ({visible, onClose}) => {
    return (
        <Drawer
            title="Выберите типы учреждений"
            placement="left"
            closable={false}
            visible={visible}
            onClose={onClose}
            getContainer={false}
            style={{position: 'absolute'}}>
            <div>Администрация</div>
            <div>Образование</div>
            <div>Медицина</div>
            <div>Безопасность</div>
            <div>Культура и отдых</div>
            <div>Спорт</div>
            <div>Другое</div>
        </Drawer>
    );
};
