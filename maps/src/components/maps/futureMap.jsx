import React, { useState } from 'react';
import { YMaps, Map, Placemark } from 'react-yandex-maps';
import styles from './map.module.css';
import { Modal } from '../modal/modal';
import { LikeOutlined, DislikeOutlined } from '@ant-design/icons';

export const FutureMap = () => {
    const [coordinates, setCoordinates] = useState([]);
    const [modalActive, setModalActive] = useState(false);
    const [likes, setLikes] = useState(0);
    const [isLiked, setIsLiked] = useState(false);
    const [dislikes, setDislike] = useState(0);
    let newCoords = [...coordinates];

    return (
        <YMaps style={{ float: 'right' }}>
            <Map defaultState={{ center: [57.373774, 61.391643], zoom: 12, type: "yandex#hybrid" }}
                defaultOptions={{ suppressMapOpenBlock: true, restrictMapArea: true }}
                className={styles.map}
                onClick={(e) => {
                    newCoords.push({
                        coords: e.get('coords'),
                        id: coordinates.length
                    });
                    setCoordinates(newCoords);
                }}>
                {coordinates.map(item =>
                    <Placemark
                        geometry={item.coords}
                        key={item.id}
                        options={{ iconColor: 'GreenYellow', preset: 'islands#circleIcon', openEmptyHint: true }}
                        onClick={() => setModalActive(true)}
                    />)}
            </Map>
            <Modal active={modalActive} setActive={setModalActive}>
                <div className={styles.container}>
                    <div className={styles.description}>
                        <p style={{ color: 'black' }}>Описание</p>
                        <p style={{ color: 'black' }}>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div className={styles.vote}>
                        <div className={styles.likesContainer}>
                            <button disabled={isLiked ? 'disabled' : ''} onClick={() => {
                                setLikes(likes + 1);
                                setIsLiked(true);
                            }}>
                                <LikeOutlined className={styles.like} />
                            </button>
                            <div className={styles.count} style={{ color: 'green' }}>+{likes}</div>
                        </div>
                        <div className={styles.likesContainer}>
                            <button disabled={isLiked ? 'disabled' : ''} onClick={() => {
                                setDislike(dislikes + 1);
                                setIsLiked(true);
                            }}>
                                <DislikeOutlined className={styles.like} />
                            </button>
                            <div className={styles.count} style={{ color: 'red' }}>-{dislikes}</div>
                        </div>
                    </div>
                </div>
            </Modal>
        </YMaps>
    )
}