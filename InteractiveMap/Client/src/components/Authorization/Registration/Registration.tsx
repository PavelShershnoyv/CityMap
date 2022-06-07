import {Button, Checkbox, Form, Input} from "antd";
import React, { useEffect, useState } from "react";
import classes from "./Registration.module.css";

export const Registration = () => {
  const [form] = Form.useForm();

  return (
    <Form
      form={form}
      name="register"
      labelCol={{ span: 8 }}
      wrapperCol={{ span: 16 }}
      initialValues={{ remember: true }}
      autoComplete="off"
    >
      <Form.Item
        name="username"
        rules={[{ required: true, message: 'Пожалуйста, введите username!' }]}
      >
        <Input placeholder='Username' />
      </Form.Item>

      <Form.Item
        name="email"
        rules={[{ required: true, type: 'email', message: 'Пожалуйста, введите email!' }]}
      >
        <Input placeholder='email'/>
      </Form.Item>

      <Form.Item
        name="password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
      >
        <Input.Password placeholder="Пароль"/>
      </Form.Item>

      <Form.Item
        name="confirm"
        dependencies={['password']}
        rules={[{ required: true, message: 'Пожалуйста, подтвердите пароль!' }]}
      >
        <Input.Password placeholder="Подтвердите пароль"/>
      </Form.Item>

      <Form.Item name="remember" valuePropName="checked" wrapperCol={{ offset: 8, span: 16 }}>
        <Checkbox>Запомнить меня</Checkbox>
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" htmlType="submit">
          Зарегистрироваться
        </Button>
      </Form.Item>
    </Form>
  );
};
