import React, {useState, MouseEventHandler} from 'react';
import {YMaps, Map, Placemark, Button} from 'react-yandex-maps';
import {MapEvent} from 'yandex-maps';
import styles from './map.module.css';
import {Modal} from '../modal/modal';
import {DefaultPlacemark} from '../ModalFills/DefaultPlacemark';

export interface IPlacemark {
    id: number;
    coords: number[];
}

export const MainMap: React.FC<any> = ({children}) => {
    const [placemarks, setPlacemarks] = useState<IPlacemark[]>([]);
    const [isModalActive, setIsModalActive] = useState(false);
    const [lastCoords, setLastCoords] = useState([0, 0]);

    const MapHandler = (e: MapEvent) => {
        const updatedCoords: number[] = e.get('coords');
        const newPlacemarks = [...placemarks];

        newPlacemarks.push({
            coords: updatedCoords,
            id: (updatedCoords[0] + updatedCoords[1])
        });
        setPlacemarks(newPlacemarks);
    }

    return (
        <>
            <YMaps>
                <Map defaultState={{center: [57.373774, 61.391643], zoom: 15, minZoom: 12, type: "yandex#hybrid"}}
                     defaultOptions={{
                         suppressMapOpenBlock: true,
                         //@ts-ignore
                         restrictMapArea: [[57.446816055717484, 61.0671083676573], [57.291374854666564, 61.724571441387724]]
                     }}
                     className={styles.map}
                     onClick={MapHandler}>
                    {placemarks.map(pl =>
                        <Placemark
                            geometry={pl.coords}
                            key={pl.id}
                            options={{iconColor: 'red', preset: 'islands#Icon', openEmptyHint: true}}
                            onClick={() => {
                                setIsModalActive(true);
                            }}/>
                    )}

                </Map>
            </YMaps>
            <Modal active={isModalActive} setActive={setIsModalActive}>
                <DefaultPlacemark />
            </Modal>
        </>
    )
}