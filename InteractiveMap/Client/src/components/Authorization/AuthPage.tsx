import { Link, Outlet, Route, Routes } from "react-router-dom";
import classes from "./AuthPage.module.css";

export const AuthPage = () => {
  return (
    <div className={classes.wrapperPage}>
      <div className={classes.wrapperForm}>
          <div className={classes.title}>
            <div className={classes.enter}>
              <Link to="login" className={classes.enterText}>
                Войти
              </Link>
            </div>
            <div className={classes.register}>
              <Link to="registration" className={classes.registerText}>
                Зарегистрироваться
              </Link>
            </div>
          </div>
          <div className={classes.form}>
          <Outlet />
          </div>
      </div>
    </div>
  );
};
