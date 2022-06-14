import React from 'react';
import {Placemark} from 'react-yandex-maps';
import {useAppSelector} from "../../hooks/redux";
import {useGetProposalPlacemarksQuery} from "../../sevices/PlacemarkService";
import {Filters, getCurrentFilters} from "../../store/reducers/filters";

export const ProposalPlacemarks: React.FC = () => {
    const {data: placemarks} = useGetProposalPlacemarksQuery();
    const currentFilters = useAppSelector(getCurrentFilters);

    return (
        <>
            {placemarks && placemarks.map(pl =>
                <Placemark
                    geometry={[pl.position.latitude, pl.position.longitude]}
                    properties={{iconCaption: pl.title}}
                    key={pl.position.latitude + pl.position.longitude}
                    options={{iconColor: 'grey', preset: 'dotIcon'}}
                />
            )}
        </>
    );
};