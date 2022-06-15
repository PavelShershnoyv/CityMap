import React, { useContext } from 'react';
import {useAppSelector} from "../../../hooks/redux";
import {getCurrentPlacemarkInfo} from "../../../store/reducers/placemarks";
import {
    ICurrentPlacemarkInfo,
    useDeletePlacemarkMutation,
    useGetCurrentPlacemarkQuery,
    useGetCurrentProposalQuery
} from "../../../sevices/PlacemarkService";
import styles from '../styles.module.css';
import {Button} from 'antd';
import { ModalContext } from '../../../context/modalContext';

export const DefaultPlacemarkInfo: React.FC = () => {
    const currentInfo = useAppSelector(getCurrentPlacemarkInfo);
    const req: ICurrentPlacemarkInfo = {
        id: currentInfo.currentPlacemarkId,
        layer: currentInfo.currentLayer
    }
    const {setVisibleModal} = useContext(ModalContext);
    const {data: info} = useGetCurrentPlacemarkQuery(req);
    const [deletePlacemark, _] = useDeletePlacemarkMutation();

    return (
        <div style={{display: 'flex', flexDirection: 'column', gap: '5px'}}>
            <h2 className={styles.noMargin}>{info && info.title}</h2>
            <h3 className={styles.noMargin}>Адрес</h3>
            <div>{info && info.address}</div>
            <h3 className={styles.noMargin}>Описание</h3>
            <div>{info && info.description}</div>
            <Button danger onClick={async () => {
                await deletePlacemark(req);
                setVisibleModal(false);
            }}>Удалить</Button>
        </div>
    );
};

