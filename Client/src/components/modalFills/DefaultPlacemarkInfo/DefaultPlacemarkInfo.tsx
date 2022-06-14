import React from 'react';
import {useAppSelector} from "../../../hooks/redux";
import {getCurrentPlacemarkInfo} from "../../../store/reducers/placemarks";
import {ICurrentPlacemarkInfo, useGetCurrentPlacemarkQuery} from "../../../sevices/PlacemarkService";
import styles from './DefaulPlacemarkInfo.module.css'

export const DefaultPlacemarkInfo: React.FC = () => {
    const currentInfo = useAppSelector(getCurrentPlacemarkInfo);
    const req: ICurrentPlacemarkInfo = {
        id: currentInfo.currentPlacemarkId,
        layer: currentInfo.currentLayer
    }
    const {data: info} = useGetCurrentPlacemarkQuery(req);

    return (
        <div style={{display: 'flex', flexDirection: 'column', gap: '5px'}}>
            <h2 className={styles.noMargin}>{info && info.title}</h2>
            <h3 className={styles.noMargin}>Адрес</h3>
            <div>{info && info.address}</div>
            <h3 className={styles.noMargin}>Описание</h3>
            <div>{info && info.description}</div>
        </div>
    );
};

