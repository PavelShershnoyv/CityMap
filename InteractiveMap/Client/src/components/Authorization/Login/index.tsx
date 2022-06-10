import React, { useEffect, useState } from "react";
import { Form, Input, Button, Checkbox } from 'antd';
import { useNavigate } from "react-router-dom";
import { useLazyLoginQuery } from "../../../sevices/AuthService";
import { ILoginRequest } from "../../../types/AuthTypes";
import classes from "./Login.module.css";

const Login = () => {
  const [login] = useLazyLoginQuery();
  const navigate = useNavigate();

  const handleFinish = async (values: any) => {
    const request: ILoginRequest = {
      email: values.email,
      password: values.password,
      rememberMe: values.rememberMe
    }

    try {
      await login(request);
    } catch {
      navigate('/');
    }
  }

  return (
    <Form
      name="login"
      initialValues={{ remember: true }}
      autoComplete='off'
      onFinish={handleFinish}
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

      <Form.Item name="remember" valuePropName="checked" wrapperCol={{ offset: 8, span: 16 }}>
        <Checkbox>Запомнить меня</Checkbox>
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" htmlType="submit">
          Войти
        </Button>
      </Form.Item>
    </Form>
  );
};

export default Login;
