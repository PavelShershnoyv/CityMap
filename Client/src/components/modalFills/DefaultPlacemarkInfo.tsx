import React, {useContext} from 'react';
import {useAppSelector} from "../../hooks/redux";
import {getCurrentPlacemarkInfo} from "../../store/reducers/placemarks";
import {
    ICurrentPlacemarkInfo,
    useDeletePlacemarkMutation,
    useGetCurrentPlacemarkQuery,
} from "../../sevices/PlacemarkService";
import styles from './styles.module.css';
import {Button, Carousel} from 'antd';
import {ModalContext} from '../../context/modalContext';

export const DefaultPlacemarkInfo: React.FC = () => {
    const currentInfo = useAppSelector(getCurrentPlacemarkInfo);
    const req: ICurrentPlacemarkInfo = {
        id: currentInfo.currentPlacemarkId,
        layer: currentInfo.currentLayer
    };
    const {setVisibleModal} = useContext(ModalContext);
    const {data: info} = useGetCurrentPlacemarkQuery(req);
    const [deletePlacemark, _] = useDeletePlacemarkMutation();

    if (!info) {
        return <div>Ошибка</div>
    }

    return (
        <div style={{display: 'flex', flexDirection: 'column', gap: '8px'}}>
            <h2 className={styles.noMargin}>{info.title}</h2>
            <Carousel effect="fade">
                {info.images.map((image, index)=> (
                        <img src={image.url} key={index} className={styles.border}/>
                ))}
            </Carousel>
            <h3 className={styles.noMargin}>Адрес</h3>
            <div>{info.address}</div>
            <h3 className={styles.noMargin}>Описание</h3>
            <div style={{marginBottom: '8px'}}>{info.description}</div>
            <Button danger onClick={async () => {
                await deletePlacemark(req);
                setVisibleModal(false);
            }}>Удалить</Button>
        </div>
    );
};

