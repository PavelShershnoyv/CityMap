import React, {useContext} from 'react';
import {Placemark} from 'react-yandex-maps';
import {useAppAction, useAppSelector} from "../../hooks/redux";
import {useGetProposalPlacemarksQuery} from "../../sevices/PlacemarkService";
import {Filters, getCurrentFilters} from "../../store/reducers/filters";
import {ModalContext} from "../../context/modalContext";
import {colors} from "../../types/PlacemarkTypes";

export const ProposalPlacemarks: React.FC = () => {
    const {data: placemarks} = useGetProposalPlacemarksQuery();
    const currentFilters = useAppSelector(getCurrentFilters);
    const {setCurrentPlacemarkInfo} = useAppAction();
    const {setVisibleModal, setModalVariant} = useContext(ModalContext);
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
                            layer: 'proposals'
                        });
                        setVisibleModal(true);
                        setModalVariant('proposals');
                    }}
                />
            )}
        </>
    );
};