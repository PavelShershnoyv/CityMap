import { Link, Outlet, Route, Routes } from "react-router-dom";
import classes from "./Authorization.module.css";

export const Authorization = () => {
  return (
    <div className={classes.wrapperPage}>
      <div className={classes.wrapperForm}>
        <form className={classes.form}>
          <div className={classes.title}>
            <div className={classes.enter}>
              <Link to="authorization" className={classes.enterText}>
                Войти
              </Link>
            </div>
            <div className={classes.register}>
              <Link to="registration" className={classes.registerText}>
                Зарегистрироваться
              </Link>
            </div>
          </div>
          <Outlet />
        </form>
      </div>
    </div>
  );
};
