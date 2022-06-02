import React, { useState, MouseEventHandler } from 'react';
import { YMaps, Map, Placemark, Button } from 'react-yandex-maps';
import { MapEvent } from 'yandex-maps';
import styles from './map.module.css';

export interface IPlacemark {
    id: number;
    coords: number[];
}

export const MainMap: React.FC<any> = ({children}) => {
    const [placemarks, setPlacemarks] = useState<IPlacemark[]>([]);
    
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
        <YMaps>
            <Map defaultState={{ center: [57.373774, 61.391643], zoom: 15, minZoom: 12, type: "yandex#hybrid" }}
                defaultOptions={{ suppressMapOpenBlock: true }}
                className={styles.map}
                onClick={MapHandler}>
                {children}
            </Map>
        </YMaps >
    )
}