import React from 'react';
import { YMaps, Map } from 'react-yandex-maps';
import styles from './map.module.css';

export const DefaultMap = () => {
    return (
        <YMaps>
            <Map defaultState={{ center: [55.75, 37.57], zoom: 9 }} className={styles.map} />
        </YMaps>
    )
}