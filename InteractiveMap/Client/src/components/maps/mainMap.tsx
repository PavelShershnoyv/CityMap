import React, {useState, MouseEventHandler} from 'react';
import {YMaps, Map, Placemark, Button} from 'react-yandex-maps';
import {MapEvent} from 'yandex-maps';
import styles from './map.module.css';
import {Modal} from '../modal/modal';
import {DefaultPlacemark} from '../modalFills/DefaultPlacemark';
import {Drawer} from 'antd';
import 'antd/dist/antd.css';
import {IPlacemark} from '../../types/PlacemarkTypes';

export const MainMap: React.FC<any> = ({children}) => {
    const [placemarks, setPlacemarks] = useState<IPlacemark[]>([]);
    const [isModalActive, setIsModalActive] = useState(false);
    const [lastCoords, setLastCoords] = useState([0, 0]);
    const [visible, setVisible] = useState(false);

    const showDrawer = () => {
        setVisible(true);
    };

    const onClose = () => {
        setVisible(false);
    };

    const MapHandler = (e: MapEvent) => {
        const updatedCoords: number[] = e.get('coords');
        const newPlacemarks = [...placemarks];

        newPlacemarks.push({
            coords: updatedCoords,
            name: '',
            type: '',
            id: (updatedCoords[0] + updatedCoords[1])
        });
        setPlacemarks(newPlacemarks);
    }

    return (
        <div style={{position: 'relative', overflow: 'hidden'}}>
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
                            properties={{iconCaption: 'Текст'}}
                            key={pl.id}
                            options={{iconColor: 'red', preset: 'islands#Icon', openEmptyHint: true}}
                            onClick={() => {
                                setIsModalActive(true);
                            }}/>
                    )}
                    <Button onClick={() => setVisible(true)}>Виды мест</Button>
                </Map>
            </YMaps>
            <Drawer
                title="Выберите типы учреждений"
                placement="left"
                closable={false}
                onClose={onClose}
                visible={visible}
                getContainer={false}
                style={{position: 'absolute'}}>
                <div>Администрация</div>
                <div>Образование</div>
                <div>Медицина</div>
                <div>Безопасность</div>
                <div>Культура и отдых</div>
                <div>Спорт</div>
                <div>Другое</div>
            </Drawer>
            <Modal active={isModalActive} setActive={setIsModalActive}>
                <DefaultPlacemark/>
            </Modal>
        </div>
    )
}