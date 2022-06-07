import React, { useEffect, useState } from "react";
import {Form, Input, Button, Checkbox} from 'antd';
import classes from "./Login.module.css";

const Login = () => {
  const [form] = Form.useForm();

  return (
    <Form
      name="login"
      initialValues={{ remember: true }}
      autoComplete="off"
    >
      <Form.Item
        name="username"
        rules={[{ required: true, message: 'Пожалуйста, введите username!' }]}
      >
        <Input type='username' placeholder="Username" />
      </Form.Item>

      <Form.Item
        name="password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
      >
        <Input.Password placeholder='Пароль'/>
      </Form.Item>

      <Form.Item name="remember" valuePropName="checked" wrapperCol={{ offset: 8, span: 16 }}>
        <Checkbox>Remember me</Checkbox>
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
  );
};

export default Login;
