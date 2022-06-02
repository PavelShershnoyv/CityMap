import React, { useState } from 'react';
import { YMaps, Map, Placemark } from 'react-yandex-maps';
import styles from './map.module.css';
import { Modal } from '../modal/modal';

export const DefaultMap = () => {
    const temporary = [{ coords: [57.37164106401986, 61.37379021679686], key: 0 },
    { coords: [57.361994929471145, 61.40709252392575], key: 1 },
    { coords: [57.35986130590517, 61.33774132763672], key: 2 },
    { coords: [57.37525770810249, 61.389068079345705], key: 3 },
    { coords: [57.36709656782325, 61.42168374096681], key: 4 },
    { coords: [57.3662618030032, 61.41069741284178], key: 5 },
    { coords: [57.3680240619274, 61.35868401562501], key: 6 }];

    return (
        <>
            {temporary.map(item =>
                <Placemark
                    geometry={item.coords}
                    key={item.key}
                    options={{ iconColor: 'GreenYellow', preset: 'islands#circleIcon' }}
                />)}
        </>
    )
}