import {Modal} from 'antd';
import React, {useState, useContext} from 'react';
import {YMaps, Map, Button as MapButton} from 'react-yandex-maps';
import {MapEvent} from 'yandex-maps';
import {AddPlacemark} from '../modalFills/AddPlacemark/AddPlacemarkMF';
import {DrawerWrapper} from '../drawerWrapper/DrawerWrapper';
import styles from './map.module.css';
import {ModalContext} from "../../context/modalContext";
import {DefaultPlacemarkInfo} from "../modalFills/DefaultPlacemarkInfo";
import {ProposalInfo} from "../modalFills/ProposalInfo";
import {EventInfo} from '../modalFills/EventInfo';
import {PastInfo} from "../modalFills/PastInfo";
import { UserInfo } from '../modalFills/UserInfo';

export const MainMap: React.FC<any> = ({children}) => {
    const [coordinates, setCoordinates] = useState([]);
    const [visibleDrawer, setVisibleDrawer] = useState(false);
    const {visibleModal, setVisibleModal, modalVariant, setModalVariant} = useContext(ModalContext);


    const getModalFill = () => {
        switch (modalVariant) {
            case 'new_placemark':
                return <AddPlacemark
                    placemarkPosition={{
                        latitude: coordinates[0],
                        longitude: coordinates[1]
                    }}
                    onCloseModal={handleCancel}
                />
            case 'default':
                return <DefaultPlacemarkInfo/>
            case 'proposals':
                return <ProposalInfo/>
            case 'events':
                return <EventInfo/>
            case 'past':
                return <PastInfo/>
            case 'user':
                return <UserInfo/>
        }
    }

    const showModal = () => {
        setVisibleModal(true);
    };

    const handleCancel = () => {
        setVisibleModal(false);
    };

    const showDrawer = () => {
        setVisibleDrawer(true);
    };

    const onClose = () => {
        setVisibleDrawer(false);
    };

    const MapHandler = (e: MapEvent) => {
        const coords = e.get('coords');
        setCoordinates(coords);
        setModalVariant('new_placemark')
        showModal();
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
                     onClick={MapHandler}
                >
                    {children}
                    <MapButton
                        state={{selected: false}}
                        onClick={showDrawer}
                        data={{content: '??????????????'}}
                    />
                </Map>
            </YMaps>
            <DrawerWrapper visible={visibleDrawer} onClose={onClose}/>
            <Modal
                visible={visibleModal}
                onCancel={handleCancel}
                centered={true}
                footer={null}>
                {getModalFill()}
            </Modal>
        </div>
    )
}