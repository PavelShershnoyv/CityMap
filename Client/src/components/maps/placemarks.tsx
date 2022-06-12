import React from 'react';
import {useParams} from 'react-router-dom';
import {Placemark} from 'react-yandex-maps';
import {useAppSelector} from "../../hooks/redux";
import {useGetPlacemarksQuery} from "../../sevices/PlacemarkService";
import {Filters, getCurrentFilters} from "../../store/reducers/filters";
import {colors, IPlacemark, ITypedPlacemark} from "../../types/PlacemarkTypes";

export const Placemarks: React.FC = () => {
    const {type} = useParams();
    const {data: placemarks} = useGetPlacemarksQuery(type ? type : 'present');
    const currentFilters = useAppSelector(getCurrentFilters);
    // @ts-ignore
    const filteredPlacemarks = placemarks ? placemarks.filter(placemark => currentFilters.includes(placemark.type)) : []; 

    return (
        <>
            {filteredPlacemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: 'red', preset: 'islands#Icon'}}
                />
            )}
        </>
    )
}