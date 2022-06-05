import React, { useState } from 'react';
import { YMaps, Map, Placemark, Button } from 'react-yandex-maps';
import styles from './map.module.css';
import { Modal } from '../modal/modal';

export const MyMap: React.FC = () => {
    const [coordinates, setCoordinates] = useState([]);
    const [modalActive, setModalActive] = useState(false);
    const [isPressed, setIsPressed] = useState(false);
    const [lastCoords, setLastCoords] = useState([0, 0]);
    const [descriptionActive, setDescriptionActive] = useState(false);
    const [isChangeable, setIsChangeable] = useState(false);
    let newCoords = [...coordinates];

    const MapHandler = (e) => {
        const updatedCoords = e.get('coords');
        if (isPressed) {
            newCoords.push({
                coords: updatedCoords,
                id: coordinates.length
            });
            setCoordinates(newCoords);
            setDescriptionActive(true);
        }
    }

    const DeleteHandler = (e) => {
        const updatedCoords = [...coordinates].filter(item => item.coords !== lastCoords);
        setCoordinates(updatedCoords);
        setModalActive(false);
    }

    const ChangeHandler = () => setIsChangeable(!isChangeable);

    return (
        <YMaps>
            <Map defaultState={{ center: [57.373774, 61.391643], zoom: 15, minZoom: 12, type: "yandex#hybrid" }}
                defaultOptions={{ suppressMapOpenBlock: true }}
                className={styles.map}
                onClick={MapHandler}>
                <Button
                    data={{ content: isPressed ? 'Сохранить метки' : 'Добавить метки' }}
                    defaultOptions={{ maxWidth: 150, float: 'left' }}
                    defaultState={{ selected: isPressed }}
                    onClick={() => setIsPressed(!isPressed)}
                />
                {coordinates.map(item =>
                    <Placemark
                        geometry={item.coords}
                        key={item.id}
                        options={{ iconColor: 'red', preset: 'islands#Icon', openEmptyHint: true }}
                        onClick={() => {
                            setModalActive(true);
                            setLastCoords(item.coords);
                        }}
                    />)}
            </Map>
            <Modal active={modalActive} setActive={setModalActive}>
                <div className={styles.container} style={{ alignItems: 'flex-start', gap: 10 }}>
                    <div>Описание</div>
                    <textarea readOnly={isChangeable ? '' : 'readonly'} placeholder="Задайте описание метки" style={{ height: 100, width: "100%", resize: 'none' }} >
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </textarea>
                    <div className={styles.options}>
                        <button onClick={ChangeHandler}>Изменить</button>
                        <button onClick={DeleteHandler}>Удалить</button>
                    </div>
                </div>
            </Modal>
            <Modal active={descriptionActive} setActive={setDescriptionActive}>
                <div className={styles.container} style={{ alignItems: 'flex-start', gap: 10 }}>
                    <div>Описание</div>
                    <textarea placeholder="Задайте описание метки" style={{ height: 100, width: "100%", resize: 'none' }} />
                    <button type="submit" onClick={() => setDescriptionActive(false)}>Сохранить</button>
                </div>
            </Modal>
        </YMaps >
    )
}