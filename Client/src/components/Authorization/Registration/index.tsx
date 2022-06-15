import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { Button, Checkbox, Form, Input } from "antd";
import { useLazyRegisterQuery } from "../../../sevices/AuthService";
import { IRegisterRequest } from "../../../types/AuthTypes";
import { useAppAction } from "../../../hooks/redux";
import classes from "../AuthPage.module.css";

const Registration = () => {
  const { setUser } = useAppAction();
  const [register] = useLazyRegisterQuery();
  const navigate = useNavigate();

  const handleFinish = async (values: any) => {
    const request: IRegisterRequest = {
      firstName: values.firstName,
      email: values.email,
      password: values.password,
      confirmPassword: values.confirm,
      rememberMe: !!values.remember
    };

    try {
      const user = await register(request).unwrap();
      console.log(user);
      setUser(user);
      navigate('/');
    } catch {
    }
  }

  return (
    <Form
      name="register"
      onFinish={handleFinish}
    >
      <Form.Item
        name="firstName"
        rules={[{ required: true, message: 'Пожалуйста, введите username!' }]}
      >
        <Input placeholder='Имя' autoComplete='off' />
      </Form.Item>

      <Form.Item
        name="email"
        rules={[{ required: true, message: 'Пожалуйста, введите email!' }]}
      >
        <Input placeholder='Email' autoComplete='off' />
      </Form.Item>

      <Form.Item
        name="password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
        hasFeedback
      >
        <Input.Password placeholder='Пароль' autoComplete='off' />
      </Form.Item>

      <Form.Item
        name="confirm"
        rules={[
          { required: true, message: 'Пожалуйста, введите пароль!' },
          ({ getFieldValue }) => ({
            validator(_, value) {
              if (!value || getFieldValue('password') === value) {
                return Promise.resolve();
              }
              return Promise.reject(new Error('Пароли должны совпадать!'));
            },
          }),
        ]}
        hasFeedback
      >
        <Input.Password placeholder="Подтвердите пароль" autoComplete='off' />
      </Form.Item>

      <Form.Item name="remember" valuePropName="checked">
        <Checkbox>Запомнить меня</Checkbox>
      </Form.Item>


      <Form.Item>
        <Button type="primary" htmlType="submit" className={classes.submitBtn}>
          Зарегистрироваться
        </Button>
        Или <Link to="/account/login">Войти</Link>
      </Form.Item>
    </Form>
  );
};

export default Registration;
