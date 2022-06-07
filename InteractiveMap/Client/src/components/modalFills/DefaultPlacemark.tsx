import React from 'react';
import styles from './DefaultPlacemark.module.css';
import { Button, Form, Input } from "antd";
import TextArea from 'antd/lib/input/TextArea';

export const DefaultPlacemark: React.FC = () => {
    const [form] = Form.useForm();

    const onReset = () => {
        form.resetFields();
      };
    
    return (
        <Form
            form={form}
            labelCol={{ span: 6}}
            wrapperCol={{ span: 20}}
            autoComplete="off"
        >
            <Form.Item
                label="Имя метки"
                name="name"
                rules={[{ required: true, message: 'Поле обязательно к заполнению' }]}
                className={styles.name}
            >
                <Input placeholder="Введите имя метки"/>
            </Form.Item>
            <Form.Item
                label="Описание метки"
                name="description"
                className={styles.area}
                >
                <TextArea placeholder="Введите описание метки"/>
            </Form.Item>
            <Button type="primary" htmlType="submit">
                Сохранить
            </Button>
        </Form>
    );
};
