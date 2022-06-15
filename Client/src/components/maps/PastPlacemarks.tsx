import React, {useContext} from 'react';
import {Placemark} from 'react-yandex-maps';
import {useAppAction, useAppSelector} from "../../hooks/redux";
import {useGetDefaultPlacemarksQuery} from "../../sevices/PlacemarkService";
import {getCurrentFilters} from "../../store/reducers/filters";
import {colors} from "../../types/PlacemarkTypes";
import {ModalContext} from "../../context/modalContext";

export const PastPlacemarks: React.FC = () => {
    const {setVisibleModal, setModalVariant} = useContext(ModalContext);
    const {data: placemarks} = useGetDefaultPlacemarksQuery('past');
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
                    key={pl.position.latitude + pl.position.longitude + (pl.id || 0)}
                    options={{iconColor: colors[pl.type], preset: 'islands#circleIcon'}}
                    onClick={() => {
                        setCurrentPlacemarkInfo({
                            id: pl.id || 0,
                            layer: 'past'
                        });
                        setVisibleModal(true);
                        setModalVariant('past');
                    }}
                />
            )}
        </>
    )
}