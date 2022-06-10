import React from 'react';
import { useAppAction, useAppSelector } from '../../hooks/redux';
import './modal.css'

interface IModalProps {
    children: React.ReactNode;
}

export const Modal: React.FC<IModalProps> = ({ children }) => {
    const active = useAppSelector((state) => state.modal.isActive);
    return (
        <div className={active ? "modal active " : "modal"} onClick={() => {
            
        }}>
            <div className={active ? "modal-content active " : "modal-content"} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    )
}