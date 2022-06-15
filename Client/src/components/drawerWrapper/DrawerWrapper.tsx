import React, { useState } from 'react';
import { Drawer, Checkbox, Divider } from 'antd';
import 'antd/dist/antd.css';
import styles from './DrawerWrapper.module.css';
import { CheckboxValueType } from "antd/es/checkbox/Group";
import { useAppAction } from "../../hooks/redux";
import { Filters } from "../../store/reducers/filters";
import { colors } from '../../types/PlacemarkTypes';

interface IDrawerWrapperProps {
    visible: boolean;
    onClose: () => void;
}

export const DrawerWrapper: React.FC<IDrawerWrapperProps> = ({ visible, onClose }) => {
    const { setFilters } = useAppAction();
    const onChange = (values: CheckboxValueType[]) => {
        const filters: Filters[] = values as unknown as Filters[];
        setFilters(filters);
    }
    const defaultValue = [
        'administration',
        'education',
        'medicine',
        'production',
        'security',
        'culture',
        'sport',
        'other'
    ];
    return (
        <Drawer
            title="Выберите типы учреждений"
            placement="left"
            closable={true}
            visible={visible}
            mask={false}
            onClose={onClose}
            getContainer={false}
            style={{ position: 'absolute' }}>
            <Checkbox.Group className={styles.container} onChange={onChange} defaultValue={defaultValue}>
                <Checkbox className={styles.item} style={{ marginLeft: '8px' }} value={'administration'}>
                    <div className={styles.insertContainer}>
                        <div>Администрация</div>
                        <div className={styles.circle} style={{backgroundColor: colors['administration']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'education'}>
                    <div className={styles.insertContainer}>
                        <div>Образование</div>
                        <div className={styles.circle} style={{backgroundColor: colors['education']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'medicine'}>
                    <div className={styles.insertContainer}>
                        <div>Медицина</div>
                        <div className={styles.circle} style={{backgroundColor: colors['medicine']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'production'}>
                    <div className={styles.insertContainer}>
                        <div>Производство</div>
                        <div className={styles.circle} style={{backgroundColor: colors['production']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'security'}>
                    <div className={styles.insertContainer}>
                        <div>Безопасность</div>
                        <div className={styles.circle} style={{backgroundColor: colors['security']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'culture'}>
                    <div className={styles.insertContainer}>
                        <div>Культура и отдых</div>
                        <div className={styles.circle} style={{backgroundColor: colors['culture']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'sport'}>
                    <div className={styles.insertContainer}>
                        <div>Спорт</div>
                        <div className={styles.circle} style={{backgroundColor: colors['sport']}}></div>
                    </div>
                </Checkbox>
                <Checkbox className={styles.item} value={'other'}>
                    <div className={styles.insertContainer}>
                        <div>Другое</div>
                        <div className={styles.circle} style={{backgroundColor: colors['other']}}></div>
                    </div>
                </Checkbox>
            </Checkbox.Group>
        </Drawer>
    );
};
