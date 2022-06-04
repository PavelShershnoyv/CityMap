import React from "react";
/* import Arms from "../../images/Arms.svg"; */
import styles from "./header.module.css";
import { Link } from "react-router-dom";
import { UserOutlined } from "@ant-design/icons";
import "./active.css";

export const Header: React.FC = () => {
  return (
    <div className={styles.header}>
      {/* <div className={styles.}>*/}
      {/*    <img src={Arms} alt="Logo" style={{ width: '70px' }} />*/}
      {/*</div> */}
      <div className={styles.navigation}>
        <Link to="/default" className={styles.navElem}>
          Обычная карта
        </Link>
        <Link to="/past" className={styles.navElem}>
          Реж прошлого
        </Link>
        <Link to="/future" className={styles.navElem}>
          Реж будущего
        </Link>
        <Link to="/myMap" className={styles.navElem}>
          Моя карта
        </Link>
      </div>
      <button className={styles.headerBtn}>
        <Link to="/account">
          <UserOutlined className={styles.icon} />
        </Link>
      </button>
    </div>
  );
};
