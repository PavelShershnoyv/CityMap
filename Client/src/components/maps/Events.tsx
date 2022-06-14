import React from 'react';
import {Placemark} from 'react-yandex-maps';
import {useGetEventsQuery} from "../../sevices/PlacemarkService";

export const Events: React.FC = () => {
    const {data: placemarks} = useGetEventsQuery();

    return (
        <>
            {placemarks && placemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: 'orange', preset: 'dotIcon'}}
                />
            )}
        </>
    );
};