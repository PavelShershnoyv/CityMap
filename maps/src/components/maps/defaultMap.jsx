import React, { useState } from 'react';
import { YMaps, Map, Placemark } from 'react-yandex-maps';
import styles from './map.module.css';
import { Modal } from '../modal/modal';

export const DefaultMap = () => {
    const [coordinates, setCoordinates] = useState([]);
    const [modalActive, setModalActive] = useState(false);
    let newCoords = [...coordinates];
    const temporary = [{ coords: [57.37164106401986, 61.37379021679686], key: 0 },
    { coords: [57.361994929471145, 61.40709252392575], key: 1 },
    { coords: [57.35986130590517, 61.33774132763672], key: 2 },
    { coords: [57.37525770810249, 61.389068079345705], key: 3 },
    { coords: [57.36709656782325, 61.42168374096681], key: 4 },
    { coords: [57.3662618030032, 61.41069741284178], key: 5 },
    { coords: [57.3680240619274, 61.35868401562501], key: 6 }];
    return (
        <YMaps>
            <Map defaultState={{ center: [57.373774, 61.391643], zoom: 12, type: "yandex#hybrid" }}
                defaultOptions={{ suppressMapOpenBlock: true, restrictMapArea: true }}
                className={styles.map}
                /* onClick={(e) => {
                    newCoords.push({
                        coords: e.get('coords'),
                        id: coordinates.length
                    });
                    setCoordinates(newCoords);
                }} */>
                {temporary.map(item =>
                    <Placemark
                        geometry={item.coords}
                        key={item.id}
                        options={{ iconColor: 'GreenYellow', preset: 'islands#circleIcon' }}
                        onClick={() => setModalActive(true)}
                    />)}
            </Map>
            <Modal active={modalActive} setActive={setModalActive}>
                <p style={{ color: 'black' }}>"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."</p>
            </Modal>
        </YMaps>
    )
}