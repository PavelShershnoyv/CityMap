import React, {useState} from 'react';
import {Drawer, Checkbox} from 'antd';
import 'antd/dist/antd.css';
import styles from './DrawerWrapper.module.css';
import {CheckboxValueType} from "antd/es/checkbox/Group";
import {useAppAction} from "../../hooks/redux";
import {Filters} from "../../store/reducers/filters";

interface IDrawerWrapperProps {
    visible: boolean;
    onClose: () => void;
}

export const DrawerWrapper: React.FC<IDrawerWrapperProps> = ({visible, onClose}) => {
    const {setFilters} = useAppAction();
    const onChange = (values: CheckboxValueType[]) => {
        const filters: Filters[] = values as unknown as Filters[];
        setFilters(filters);
    }
    return (
        <Drawer
            title="Выберите типы учреждений"
            placement="left"
            closable={true}
            visible={visible}
            mask={false}
            onClose={onClose}
            getContainer={false}
            style={{position: 'absolute'}}>
            <Checkbox.Group className={styles.container} onChange={onChange}>
                <Checkbox className={styles.item} style={{marginLeft: '8px'}}
                          value={'administration'}>Администрация</Checkbox>
                <Checkbox className={styles.item} value={'education'}>Образование</Checkbox>
                <Checkbox className={styles.item} value={'medicine'}>Медицина</Checkbox>
                <Checkbox className={styles.item} value={'production'}>Производство</Checkbox>
                <Checkbox className={styles.item} value={'security'}>Безопасность</Checkbox>
                <Checkbox className={styles.item} value={'culture'}>Культура и отдых</Checkbox>
                <Checkbox className={styles.item} value={'sport'}>Спорт</Checkbox>
                <Checkbox className={styles.item} value={'other'}>Другое</Checkbox>
            </Checkbox.Group>
        </Drawer>
    );
};
