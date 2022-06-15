import React from 'react';
import {Placemark} from 'react-yandex-maps';
import {useGetUserPlacemarksQuery} from "../../sevices/PlacemarkService";

export const UserPlacemarks: React.FC = () => {
    const {data: placemarks} = useGetUserPlacemarksQuery();

    return (
        <>
            {placemarks && placemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: 'grey', preset: 'islands#circleIcon'}}
                />
            )}
        </>
    );
};