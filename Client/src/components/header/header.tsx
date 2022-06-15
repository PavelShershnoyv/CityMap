import React, { useState } from "react";
/* import Arms from "../../images/Arms.svg"; */
import styles from "./header.module.css";
import { NavLink } from "react-router-dom";
import { UserOutlined } from "@ant-design/icons";
import "./active.css";
import RezLogo from "../../Rez.svg";
import arms from "../../logo1.svg";
import { useAuth } from "../../hooks/useAuth";

export const Header: React.FC = () => {
    const { isAuthenticated, user } = useAuth();

    return (
        <div className={styles.header}>
            {/*<div className={styles.}>*/}
            {/*    <img src={Arms} alt="Logo" style={{ width: '70px' }} />*/}
            {/*</div>*/}
            <div className={styles.navigation}>
                <div className={styles.mainLogo}>
                    <div className={styles.logo}>
                        <img src={RezLogo} alt="" />
                    </div>
                    <div className={styles.arms}>
                        <img src={arms} alt="" />
                    </div>
                </div>
                <div className={styles.nav}>
                    <NavLink to="/present" className={styles.navElem}>
                        Реж <br /> прошлого
                    </NavLink>
                    <NavLink to="/past" className={styles.navElem}>
                        Реж <br /> настоящего
                    </NavLink>
                    <NavLink to="/proposals" className={styles.navElem}>
                        Реж <br /> будущего
                    </NavLink>
                    {isAuthenticated && <NavLink to="/user" className={styles.navElem}>
                        Моя <br /> карта
                    </NavLink>}
                    <NavLink to="/events" className={styles.navElem}>
                        <div style={{ alignSelf: "center" }}>События</div>
                    </NavLink>
                    <NavLink to="/about" className={styles.navElem} >
                        <div style={{ alignSelf: "center" }}>Про Реж</div>
                    </NavLink>
                </div>
            </div>
            <div className={styles.button}>
                <p>{isAuthenticated ? user.firstName : 'Войти'}</p>
                <button className={styles.headerBtn}>
                    <NavLink to="/account/login">
                        <UserOutlined className={styles.icon} />
                    </NavLink>
                </button>
            </div>
        </div>
    );
};
