import React, { useEffect, useState } from "react";
import classes from "./AuthorizationComponent.module.css";

export const AuthorizationComponent = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [emailError, setEmailError] = useState("Емайл не может быть пустым");
  const [formValid, setFormValid] = useState(false);
  const [emailDirty, setEmailDirty] = useState(false);
  const [passwordError, setPasswordError] = useState(
    "Пароль не может быть пустым"
  );
  const [passwordDirty, setPasswordDirty] = useState(false);

  useEffect(() => {
    if (emailError || passwordError) {
      setFormValid(false);
    } else {
      setFormValid(true);
    }
  }, [emailError, passwordError]);

  const emailHandler = (e: any) => {
    setEmail(e.target.value);
    const regularExpression =
      /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!regularExpression.test(String(e.target.value).toLowerCase())) {
      setEmailError("Неправильно набранный email");
    } else {
      setEmailError("");
    }
  };

  const passwordHandler = (e: any) => {
    setPassword(e.target.value);
    if (!e.target.value) {
      setPasswordError("Пароль не может быть пустым");
    } else {
      setPasswordError("");
    }
  };

  const blurHandler = (e: any) => {
    switch (e.target.name) {
      case "email":
        setEmailDirty(true);
        break;
      case "password":
        setPasswordDirty(true);
        break;
    }
  };

  return (
    <div className={classes.mainWindow}>
      {emailDirty && emailError && (
        <div className={classes.error}>{emailError}</div>
      )}
      <input
        className={classes.email}
        onChange={(e) => emailHandler(e)}
        onBlur={(e) => blurHandler(e)}
        name="email"
        type="text"
        placeholder="Введите ваш email..."
      />
      {passwordDirty && passwordError && (
        <div className={classes.error}>{passwordError}</div>
      )}
      <input
        className={classes.password}
        onChange={(e) => passwordHandler(e)}
        onBlur={(e) => blurHandler(e)}
        name="password"
        type="password"
        placeholder="Введите ваш пароль..."
      />
      <button className={classes.btn} disabled={!formValid}>
        Войти
      </button>
    </div>
  );
};
