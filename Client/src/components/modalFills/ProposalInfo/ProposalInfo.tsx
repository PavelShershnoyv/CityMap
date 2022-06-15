import React, { useContext } from 'react';
import { useAppSelector } from "../../../hooks/redux";
import { getCurrentPlacemarkInfo } from "../../../store/reducers/placemarks";
import {
    ICurrentPlacemarkInfo,
    ILikeRequest,
    useDeletePlacemarkMutation,
    useGetCurrentProposalQuery,
    useLikeProposalMutation
} from "../../../sevices/PlacemarkService";
import styles from '../styles.module.css';
import { LikeOutlined } from "@ant-design/icons";
import { Button } from 'antd';
import { ModalContext } from '../../../context/modalContext';

export const ProposalInfo: React.FC = () => {
    const currentInfo = useAppSelector(getCurrentPlacemarkInfo);
    const [likeRequest, _] = useLikeProposalMutation();
    const req: ICurrentPlacemarkInfo = {
        id: currentInfo.currentPlacemarkId,
        layer: currentInfo.currentLayer
    }
    const {setVisibleModal} = useContext(ModalContext);
    const { data: info } = useGetCurrentProposalQuery(req);
    const [deletePlacemark, promise] = useDeletePlacemarkMutation();
    
    if (!info) {
        return <div>Ошибка</div>
    }

    return (
        <div style={{ display: 'flex', flexDirection: 'column', gap: '5px' }}>
            <div style={{ display: 'flex', alignItems: 'center', gap: '20px' }}>
                <h2 className={styles.noMargin}>{info && info.title}</h2>
                <div style={{ color: '#1890ff' }}>
                    {info.positiveVotesCount}
                    <Button
                        type="default"
                        className={styles.btn}
                        icon={<LikeOutlined style={{ color: '#1890ff' }} />}
                        style={{ marginLeft: '5px' }}
                        onClick={async () => {
                            const like: ILikeRequest = {
                                proposalId: req.id,
                                isPositive: true,
                            }
                            await likeRequest(like);
                        }}
                    />
                </div>
            </div>
            <h3 className={styles.noMargin}>Адрес</h3>
            <div>{info && info.address}</div>
            <h3 className={styles.noMargin}>Описание</h3>
            <div>{info && info.description}</div>
            <Button danger onClick={async () => {
                await deletePlacemark(req);
                setVisibleModal(false);
            }}>Удалить</Button>
        </div>
    );
};

