import React, {useContext} from 'react';
import {useParams} from 'react-router-dom';
import {Placemark} from 'react-yandex-maps';
import {useAppAction, useAppSelector} from "../../hooks/redux";
import {useGetDefaultPlacemarksQuery} from "../../sevices/PlacemarkService";
import {getCurrentFilters} from "../../store/reducers/filters";
import {colors} from "../../types/PlacemarkTypes";
import {ModalContext} from "../../context/modalContext";

export const DefaultPlacemarks: React.FC = () => {
    const {setVisibleModal, setModalVariant} = useContext(ModalContext);
    const {type} = useParams();
    const {data: placemarks} = useGetDefaultPlacemarksQuery(type ? type : 'present');
    const currentFilters = useAppSelector(getCurrentFilters);
    const {setCurrentPlacemarkInfo} = useAppAction();
    // @ts-ignore
    const filteredPlacemarks = placemarks ? placemarks.filter(placemark => currentFilters.includes(placemark.type)) : [];


    return (
        <>
            {filteredPlacemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: colors[pl.type], preset: 'islands#circleIcon'}}
                    onClick={() => {
                        setCurrentPlacemarkInfo({
                            id: pl.id || 0,
                            layer: type ? type : 'present'
                        });
                        setVisibleModal(true);
                        setModalVariant('default');
                    }}
                />
            )}
        </>
    )
}