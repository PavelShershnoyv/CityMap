import React from 'react';
import { useParams } from 'react-router-dom';
import { Button, Form, Input, Select, Upload } from "antd";
import TextArea from 'antd/lib/input/TextArea';
import { useCreatePlacemarkMutation } from '../../../sevices/PlacemarkService';
import { ICreateRequest } from '../../../sevices/PlacemarkService';
import { IUnionRequestsType } from '../../../types/PlacemarkTypes';
import styles from './AddPlacemarkMF.module.css';
import { UploadOutlined } from '@ant-design/icons';

interface IAddPlacemarkProps {
    placemarkPosition: {
        latitude: number;
        longitude: number;
    };
    onCloseModal: () => void;
}

export const AddPlacemark: React.FC<IAddPlacemarkProps> = ({ placemarkPosition, onCloseModal }) => {
    const { type } = useParams();
    const [form] = Form.useForm();
    const { Option } = Select;
    const [createPlacemark, { }] = useCreatePlacemarkMutation();

    const onSelectChange = (value: string) => {
        form.setFieldsValue({ type: value });
    }

    const normFile = (event: any) => {
        if (Array.isArray(event)) {
            return event;
        }
        return event?.fileList;
    }

    const onFinish = async (data: any) => {
        console.log(data)
        const body: IUnionRequestsType = {
            title: data.title,
            description: data.description ? data.description : '-',
            images: data.images ? data.images.map((image: any) => image.originFileObj) : [],
            address: '-',
            position: {
                latitude: placemarkPosition.latitude,
                longitude: placemarkPosition.longitude
            },
            type: data.type
        };

        const req: ICreateRequest = {
            layer: type ? type : 'user',
            body: body
        }
        await createPlacemark(req);

        form.resetFields();
        onCloseModal();
    };

    return (
        <Form
            form={form}
            wrapperCol={{ span: 24 }}
            layout={'vertical'}
            autoComplete="off"
            onFinish={onFinish}
        >
            <Form.Item
                label="Имя метки"
                name="title"
                rules={[{ required: true, message: 'Поле обязательно к заполнению' }]}
            >
                <Input placeholder="Введите имя метки" />
            </Form.Item>
            {type !== 'events' && type && <Form.Item
                label="Тип метки"
                name="type"
                rules={[{ required: true, message: 'Поле обязательно к заполнению' }]}
            >
                <Select onChange={onSelectChange}>
                    <Option value='administration'>Администрация</Option>
                    <Option value='education'>Образование</Option>
                    <Option value='sport'>Спорт</Option>
                    <Option value='medicine'>Медицина</Option>
                    <Option value='production'>Производство</Option>
                    <Option value='security'>Безопасность</Option>
                    <Option value='culture'>Культура и отдых</Option>
                    <Option value='other'>Другое</Option>
                </Select>
            </Form.Item>}
            <Form.Item
                label="Описание метки"
                name="description"
                className={styles.area}
            >
                <TextArea placeholder="Введите описание метки" />
            </Form.Item>
            <Form.Item
                label='Фотографии'
                name='images'
                getValueFromEvent={normFile}
            >
                <Upload
                    accept='image/*'
                    listType='picture-card'
                    beforeUpload={() => false}
                >
                    <UploadOutlined />
                </Upload>
            </Form.Item>
            <Button type="primary" htmlType="submit">
                Сохранить
            </Button>
        </Form>
    );
};
