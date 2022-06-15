import React, { useContext } from 'react';
import {Placemark} from 'react-yandex-maps';
import { ModalContext } from '../../context/modalContext';
import {useAppAction} from '../../hooks/redux';
import {useGetUserPlacemarksQuery} from "../../sevices/PlacemarkService";

export const UserPlacemarks: React.FC = () => {
    const {data: placemarks} = useGetUserPlacemarksQuery();
    const {setCurrentPlacemarkInfo} = useAppAction();
    const {setVisibleModal, setModalVariant} = useContext(ModalContext);

    return (
        <>
            {placemarks && placemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: 'Aquamarine', preset: 'islands#circleIcon'}}
                    onClick={() => {
                        setCurrentPlacemarkInfo({
                            id: pl.id || 0,
                            layer: 'user'
                        });
                        setVisibleModal(true);
                        setModalVariant('user');
                    }}
                />
            )}
        </>
    );
};