import React, { useContext } from 'react';
import {useAppSelector} from "../../../hooks/redux";
import {getCurrentPlacemarkInfo} from "../../../store/reducers/placemarks";
import {
    ICurrentPlacemarkInfo,
    useDeletePlacemarkMutation,
    useGetCurrentEventQuery
} from "../../../sevices/PlacemarkService";
import styles from '../styles.module.css';
import { Button } from 'antd';
import { ModalContext } from '../../../context/modalContext';

export const EventInfo: React.FC = () => {
    const currentInfo = useAppSelector(getCurrentPlacemarkInfo);
    const req: ICurrentPlacemarkInfo = {
        id: currentInfo.currentPlacemarkId,
        layer: currentInfo.currentLayer
    }
    const {setVisibleModal} = useContext(ModalContext);
    const {data: info} = useGetCurrentEventQuery(req);
    const [deletePlacemark, _] = useDeletePlacemarkMutation();
    
    if (!info) {
        return <div>Ошибка</div>
    }
    
    return (
        <div style={{display: 'flex', flexDirection: 'column', gap: '5px'}}>
            <h2 className={styles.noMargin}>{info.title}</h2>
            <h3 className={styles.noMargin}>Дата</h3>
            <div>{info.startDate.split('T')[0]}</div>
            <h3 className={styles.noMargin}>Адрес</h3>
            <div>{info.address}</div>
            <h3 className={styles.noMargin}>Описание</h3>
            <div>{info.description}</div>
            <Button danger onClick={async () => {
                await deletePlacemark(req);
                setVisibleModal(false);
            }}>Удалить</Button>
        </div>
    );
};

