import React, { useState } from "react";
/* import Arms from "../../images/Arms.svg"; */
import styles from "./header.module.css";
import { NavLink } from 'react-router-dom';
import { UserOutlined } from '@ant-design/icons';
import { useAuth } from "../../hooks/useAuth";
import './active.css';

export const Header: React.FC = () => {
    const authUser = useAuth();

    return (
        <div className={styles.header}>
            {/*<div className={styles.}>*/}
            {/*    <img src={Arms} alt="Logo" style={{ width: '70px' }} />*/}
            {/*</div>*/}
            <div className={styles.navigation}>
                <NavLink to="/present" className={styles.navElem}>Обычная карта</NavLink>
                <NavLink to="/past" className={styles.navElem}>Реж прошлого</NavLink>
                <NavLink to="/proposals" className={styles.navElem}>Реж будущего</NavLink>
                <NavLink to="/events" className={styles.navElem}>События</NavLink>
                {authUser.isAuthenticated && <NavLink to="/user" className={styles.navElem}>Моя карта</NavLink>}
            </div>
            <button className={styles.headerBtn}>
                <NavLink to="/account/login">
                    <UserOutlined className={styles.icon} />
                </NavLink>
            </button>
        </div>
    )
}