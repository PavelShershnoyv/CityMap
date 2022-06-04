import React, { useEffect, useState } from "react";
import classes from "./RegistrationComponent.module.css";

export const RegistrationComponent = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [nameError, setNameError] = useState("Это обязательное поле");
  const [formValid, setFormValid] = useState(false);
  const [nameDirty, setNameDirty] = useState(false);
  const [emailError, setEmailError] = useState("email не может быть пустым");
  const [emailDirty, setEmailDirty] = useState(false);

  useEffect(() => {
    if (nameError || emailError) {
      setFormValid(false);
    } else {
      setFormValid(true);
    }
  }, [nameError, emailError]);

  const nameHandler = (e: any) => {
    setName(e.target.value);
    const regularExpression = /^[а-яё]{2,15}$/;
    if (!regularExpression.test(String(e.target.value).toLowerCase())) {
      setNameError("Неправильно набранное имя");
    } else {
      setNameError("");
    }
  };

  // /^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,}$/;

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

  const blurHandler = (e: any) => {
    switch (e.target.name) {
      case "email":
        setNameDirty(true);
        break;
      case "password":
        setEmailDirty(true);
        break;
    }
  };

  return (
    <div className={classes.mainWindow}>
      <input
        className={classes.email}
        onChange={(e) => nameHandler(e)}
        onBlur={(e) => blurHandler(e)}
        name="email"
        type="text"
        maxLength={15}
        placeholder="Введите ваше имя..."
      />
      {emailDirty && emailError && (
        <div className={classes.error}>{emailError}</div>
      )}
      <input
        className={classes.password}
        onChange={(e) => emailHandler(e)}
        onBlur={(e) => blurHandler(e)}
        name="password"
        type="text"
        placeholder="Введите ваш email..."
      />
      <button className={classes.btn} disabled={!formValid}>
        Зарегистрироваться
      </button>
    </div>
  );
};
