import React from 'react';
import styles from './AddPlacemarkMF.module.css';
import { Button, Form, Input } from "antd";
import TextArea from 'antd/lib/input/TextArea';
import { useCreatePlacemarkMutation } from '../../sevices/PlacemarkService';
import {IMarkRequest} from '../../sevices/PlacemarkService';

interface IAddPlacemarkProps {
    placemarkPosition: {
        latitude: number;
        longitude: number;
    };
    onCloseModal: () => void;
}

export const AddPlacemark: React.FC<IAddPlacemarkProps> = ({placemarkPosition, onCloseModal}) => {
    const [form] = Form.useForm();
    const [createPlacemark, {}] = useCreatePlacemarkMutation();
    const onFinish = async (data: any) => {
        
        const mark: IMarkRequest = {
            title: data.name,
            description: data.description,
            position: {
                latitude: placemarkPosition.latitude,
                longitude: placemarkPosition.longitude
            },
            layerType: 1,
            type: 1,
            id: 0
        };
        await createPlacemark(mark);
        form.resetFields();
        onCloseModal();
      };
    
    return (
        <Form
            form={form}
            wrapperCol={{ span: 24}}
            layout={'vertical'}
            autoComplete="off"
            onFinish={onFinish}
        >
            <Form.Item
                label="Имя метки"
                name="name"
                rules={[{ required: true, message: 'Поле обязательно к заполнению' }]}
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
