import React from 'react';
import styles from './DefaultPlacemark.module.css';
import {IPlacemark} from '../maps/mainMap';

export const DefaultPlacemark: React.FC = () => {
    return (
            <div className={styles.container} style={{alignItems: 'flex-start', gap: 10}}>
                <div>Описание</div>
                <textarea placeholder="Задайте описание метки" style={{height: 100, width: "100%", resize: 'none'}}>

                </textarea>
                <div className={styles.options}>
                    <button>Изменить</button>
                    <button>Удалить</button>
                </div>
            </div>
    );
};
