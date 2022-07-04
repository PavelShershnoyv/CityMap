import React, {useState} from "react";
/* import Arms from "../../images/Arms.svg"; */
import styles from "./header.module.css";
import {NavLink} from "react-router-dom";
import {UserOutlined} from "@ant-design/icons";
import "./active.css";
import RezLogo from "../../Rez.svg";
import arms from "../../logo1.svg";
import {useAuth} from "../../hooks/useAuth";

export const Header: React.FC = () => {
    const {isAuthenticated, user} = useAuth();

    return (
        <div className={styles.header}>
            <div className={styles.navigation}>
                <div className={styles.nav}>
                    <NavLink to="/present" className={styles.navElem}>
                        <div className={styles.inner}>
                            Реж настоящего
                        </div>
                    </NavLink>
                    <NavLink to="/past" className={styles.navElem}>
                        <div className={styles.inner}>
                            Реж прошлого
                        </div>
                    </NavLink>
                    <NavLink to="/proposals" className={styles.navElem}>
                        <div className={styles.inner}>
                            Реж будущего
                        </div>
                    </NavLink>
                    {isAuthenticated && <NavLink to="/user" className={styles.navElem}>
                        <div className={styles.inner}>
                            Моя карта
                        </div>
                    </NavLink>}
                    <NavLink to="/events" className={styles.navElem}>
                        <div className={styles.inner}>
                            События
                        </div>
                    </NavLink>
                </div>
            </div>
            <div className={styles.button}>
                <p>{isAuthenticated ? user?.firstName : 'Войти'}</p>
                <button className={styles.headerBtn}>
                    <NavLink to="/account/login">
                        <UserOutlined className={styles.icon}/>
                    </NavLink>
                </button>
            </div>
        </div>
    );
};
