import { NavLink, Outlet, Route, Routes } from "react-router-dom";
import classes from "./AuthPage.module.css";

export const AuthPage = () => {
  return (
    <div className={classes.wrapperPage}>
      <div className={classes.wrapperForm}>
        <div className={classes.title}>
          <div className={classes.enter}>
            <NavLink to="login" className={classes.enterText}>
              Войти
            </NavLink>
          </div>
          <div className={classes.register}>
            <NavLink to="registration" className={classes.registerText}>
              Зарегистрироваться
            </NavLink>
          </div>
        </div>
        <div className={classes.form}>
          <Outlet />
        </div>
      </div>
    </div>
  );
};
