import { Modal } from 'antd';
import React, { useState } from 'react';
import { YMaps, Map, Placemark, Button as MapButton } from 'react-yandex-maps';
import { MapEvent } from 'yandex-maps';
import { AddPlacemark } from '../modalFills/AddPlacemarkMF';
import { useGetPlacemarksQuery } from '../../sevices/PlacemarkService';
import { DrawerWrapper } from '../drawerWrapper/DrawerWrapper';
import { useAppAction } from '../../hooks/redux';
import styles from './map.module.css';

export const MainMap: React.FC<any> = ({ children }) => {
    const [coordinates, setCoordinates] = useState<number[]>([]);
    const [visibleDrawer, setVisibleDrawer] = useState(false);
    const [visibleModal, setVisibleModal] = useState(false);
    const { data: placemarks } = useGetPlacemarksQuery(1);

    const showModal = () => {
        setVisibleModal(true);
    };

    const handleCancel = () => {
        setVisibleModal(false);
    };

    const showDrawer = () => {
        setVisibleDrawer(true);
    };

    const onClose = () => {
        setVisibleDrawer(false);
    };

    const MapHandler = (e: MapEvent) => {
        const newPlacemarkCoords: number[] = e.get('coords');
        setCoordinates(newPlacemarkCoords);
        showModal();
    }

    return (
        <div style={{ position: 'relative', overflow: 'hidden' }}>
            <YMaps>
                <Map defaultState={{ center: [57.373774, 61.391643], zoom: 15, minZoom: 12, type: "yandex#hybrid" }}
                    defaultOptions={{
                        suppressMapOpenBlock: true,
                        //@ts-ignore
                        restrictMapArea: [[57.446816055717484, 61.0671083676573], [57.291374854666564, 61.724571441387724]]
                    }}
                    className={styles.map}
                    onClick={MapHandler}>
                    {placemarks && placemarks.map(pl =>
                        <Placemark
                            geometry={[pl.position.latitude, pl.position.longitude]}
                            properties={{ iconCaption: pl.title }}
                            key={pl.id}
                            options={{ iconColor: 'red', preset: 'islands#Icon', openEmptyHint: true }}
                        />
                    )}
                    <MapButton onClick={showDrawer} data={{ content: 'Фильтры' }}></MapButton>
                </Map>
            </YMaps>
            <DrawerWrapper visible={visibleDrawer} onClose={onClose} />

            <Modal
                visible={visibleModal}
                onCancel={handleCancel}
                centered={true}
                footer={null}
            >
                <AddPlacemark placemarkPosition={{
                    latitude: coordinates[0],
                    longitude: coordinates[1]
                }} 
                onCloseModal={handleCancel}/>
            </Modal>
        </div>
    )
}