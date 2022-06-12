import React, { useEffect, useState } from "react";
import { Form, Input, Button, Checkbox } from 'antd';
import { Link, useNavigate } from "react-router-dom";
import { useLazyLoginQuery } from "../../../sevices/AuthService";
import { ILoginRequest } from "../../../types/AuthTypes";
import classes from "../AuthPage.module.css";

const Login = () => {
  const [login] = useLazyLoginQuery();
  const navigate = useNavigate();

  const handleFinish = async (values: any) => {
    const request: ILoginRequest = {
      email: values.email,
      password: values.password,
      rememberMe: !!values.remember
    }

    try {
      await login(request);
    } catch {
    }
  }

  return (
    <Form
      name="login"
      initialValues={{ remember: true }}
      autoComplete='off'
      onFinish={handleFinish}
      size='large'
    >
      <Form.Item
        name="email"
        rules={[{ required: true, message: 'Пожалуйста, введите email!' }]}
      >
        <Input type='email' placeholder="Email" autoComplete='off' />
      </Form.Item>

      <Form.Item
        name="password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
      >
        <Input.Password placeholder='Пароль' autoComplete='off' />
      </Form.Item>

      <Form.Item name="remember" valuePropName="checked">
        <Checkbox>Запомнить меня</Checkbox>
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" className={classes.submitBtn}>
          Войти
        </Button>
        <Form.Item>
        Или <Link to="/account/registration">Зарегистрироваться</Link>
      </Form.Item>
      </Form.Item>
    </Form>
  );
};

export default Login;
