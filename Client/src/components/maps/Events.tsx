import React, { useContext } from 'react';
import {Placemark} from 'react-yandex-maps';
import { ModalContext } from '../../context/modalContext';
import { useAppAction } from '../../hooks/redux';
import { useGetEventsQuery } from '../../sevices/PlacemarkService';

export const Events: React.FC = () => {
    const {data: placemarks} = useGetEventsQuery();
    const {setVisibleModal, setModalVariant} = useContext(ModalContext);
    const {setCurrentPlacemarkInfo} = useAppAction();

    return (
        <>
            {placemarks && placemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: 'orange', preset: 'islands#circleIcon'}}
                    onClick={() => {
                        setCurrentPlacemarkInfo({
                            id: pl.id || 0,
                            layer: 'events'
                        });
                        setVisibleModal(true);
                        setModalVariant('events');
                    }}
                />
            )}
        </>
    );
};