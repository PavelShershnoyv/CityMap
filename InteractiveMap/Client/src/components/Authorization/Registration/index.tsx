import {Button, Checkbox, Form, Input} from "antd";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useLazyRegisterQuery } from "../../../sevices/AuthService";
import { IRegisterRequest } from "../../../types/AuthTypes";
import classes from "./Registration.module.css";

const Registration = () => {
  const [register] = useLazyRegisterQuery();
  const navigate = useNavigate();

  const handleFinish = async (values: any) => {
    const request: IRegisterRequest = {
      username: values.username,
      email: values.email,
      password: values.password,
      confirmPassword: values.confirmPassword,
    };

    try {
      await register(request);
    } catch {
      navigate('/');
    }
  }

  return (
    <Form
      name="register"
      autoComplete="off"
      onFinish={handleFinish}
    >
      <Form.Item
        name="username"
        rules={[{ required: true, message: 'Пожалуйста, введите username!' }]}
      >
        <Input placeholder='Username' autoComplete='off'/>
      </Form.Item>

      <Form.Item
        name="email"
        rules={[{ required: true, message: 'Пожалуйста, введите email!' }]}
      >
        <Input placeholder='Email' autoComplete='off'/>
      </Form.Item>

      <Form.Item
        name="password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
      >
        <Input.Password placeholder='Пароль' autoComplete='off' />
      </Form.Item>

      <Form.Item
        name="confirm-password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
      >
        <Input.Password placeholder="Подтвердите пароль" autoComplete='off'/>
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" htmlType="submit">
          Зарегистрироваться
        </Button>
      </Form.Item>
    </Form>
  );
};

export default Registration;
