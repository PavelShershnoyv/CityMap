import React, {useState} from "react";
/* import Arms from "../../images/Arms.svg"; */
import styles from "./header.module.css";
import { NavLink } from 'react-router-dom';
import { UserOutlined } from '@ant-design/icons';
import { Drawer, Button } from 'antd';
import './active.css';

export const Header: React.FC = () => {
    const [visible, setVisible] = useState(false);

    const showDrawer = () => {
        setVisible(true);
    };

    const onClose = () => {
        setVisible(false);
    };

    return (
        <div className={styles.header}>
            {/*<div className={styles.}>*/}
            {/*    <img src={Arms} alt="Logo" style={{ width: '70px' }} />*/}
            {/*</div>*/}
            <div className={styles.navigation}>
                <NavLink to="/" className={styles.navElem}>Обычная карта</NavLink>
                <NavLink to="/past" className={styles.navElem}>Реж прошлого</NavLink>
                <NavLink to="/future" className={styles.navElem}>Реж будущего</NavLink>
                <NavLink to="/myMap" className={styles.navElem}>Моя карта</NavLink>
            </div>
            <button className={styles.headerBtn}>
                <NavLink to="/account/login">
                    <UserOutlined className={styles.icon} />
                </NavLink>
            </button>
        </div>
    )
}