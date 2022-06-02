import React from 'react';
/* import Arms from "../../images/Arms.svg"; */
import styles from "./header.module.css";
import { NavLink } from 'react-router-dom';
import { UserOutlined } from '@ant-design/icons';
import './active.css';

export const Header: React.FC = () => {
    return (
        <div className={styles.header}>
            {/*<div className={styles.}>*/}
            {/*    <img src={Arms} alt="Logo" style={{ width: '70px' }} />*/}
            {/*</div>*/}
            <div className={styles.navigation}>
                <NavLink to="/rezh" className={styles.navElem}>Обычная карта</NavLink>
                <NavLink to="/rezh?q=past" className={styles.navElem}>Реж прошлого</NavLink>
                <NavLink to="/rezh?q=future" className={styles.navElem}>Реж будущего</NavLink>
                <NavLink to="/myMap" className={styles.navElem}>Моя карта</NavLink>
            </div>
            <button className={styles.headerBtn}>
                <UserOutlined className={styles.icon} />
            </button>
        </div>
    )
}