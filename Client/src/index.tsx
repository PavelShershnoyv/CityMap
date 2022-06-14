import React, {useState} from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import {BrowserRouter} from 'react-router-dom';
import {Provider} from 'react-redux';
import {store} from './store/store';
import {ModalContext} from "./context/modalContext";

const Main: React.FC = () => {
    const [visibleModal, setVisibleModal] = useState(false);
    const [modalVariant, setModalVariant] = useState('new_placemark');
    return (
        <BrowserRouter>
            <ModalContext.Provider value={{visibleModal, setVisibleModal, modalVariant, setModalVariant}}>
                <Provider store={store}>
                    <App/>
                </Provider>
            </ModalContext.Provider>
        </BrowserRouter>
    )
}
ReactDOM.render(
    <Main />,
    document.getElementById('root')
);
