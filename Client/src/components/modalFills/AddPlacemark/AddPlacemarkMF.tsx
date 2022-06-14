import React from 'react';
import styles from './AddPlacemarkMF.module.css';
import { Button, Form, Input } from "antd";
import TextArea from 'antd/lib/input/TextArea';
import { useCreatePlacemarkMutation } from '../../../sevices/PlacemarkService';
import { ICreateRequest } from '../../../sevices/PlacemarkService';
import { IUnionRequestsType} from '../../../types/PlacemarkTypes';
import { useParams } from 'react-router-dom';

interface IAddPlacemarkProps {
    placemarkPosition: {
        latitude: number;
        longitude: number;
    };
    onCloseModal: () => void;
}

export const AddPlacemark: React.FC<IAddPlacemarkProps> = ({placemarkPosition, onCloseModal}) => {
    const {type} = useParams();
    const [form] = Form.useForm();
    const [createPlacemark, {}] = useCreatePlacemarkMutation();
    
    const onFinish = async (data: any) => {
        const body: IUnionRequestsType = {
            title: data.title,
            description: data.description,
            images: [],
            address: '213', 
            position: {
                latitude: placemarkPosition.latitude,
                longitude: placemarkPosition.longitude
            }
        };

        if (type === 'present' || type === 'past') {
            body.type = 'sport';
        }

        const req: ICreateRequest = {
            layer: type ? type : 'user',
            body: body
        }
        console.log(req);
        await createPlacemark(req);

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
                name="title"
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
