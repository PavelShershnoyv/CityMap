import React from 'react';
import Arms from "../../images/Arms.svg";
import styles from "./header.module.css";
import { Button } from 'antd';
import { MenuOutlined } from '@ant-design/icons';
import { NavLink } from 'react-router-dom';
import './active.css';

export const Header = () => {
    return (
        <div className={styles.header}>
            <div className={styles.Logo}>
                <img src={Arms} alt="Logo" style={{ width: '70px' }} />
            </div>
            <div className={styles.navigation}>
                <NavLink to="/" className={styles.navElem}>Обычная карта</NavLink>
                <NavLink to="past" className={styles.navElem}>Реж прошлого</NavLink>
                <NavLink to="future" className={styles.navElem}>Реж будущего</NavLink>
            </div>
            <Button className={styles.headerBtn} icon={<MenuOutlined style={{ fontSize: "35px", margin: "0.2em" }} />} />
        </div>
    )
}