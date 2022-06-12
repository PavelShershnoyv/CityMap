import { Link, Outlet, Route, Routes } from "react-router-dom";
import { CloseOutlined } from '@ant-design/icons';
import classes from "./AuthPage.module.css";

export const AuthPage = () => {
  return (
    <div className={classes.wrapper}>
      <Link to={'/'} className={classes.closeBtn}>
        <CloseOutlined style={{fontSize: '24px'}} />
      </Link>
      <div className={classes.form}>
        <Outlet />
      </div>
    </div>
  );
};
