import {Routes, Route, Navigate} from "react-router-dom";
import {AuthRequired} from "./utils/AuthRequired";
import {Layout} from "./components/layout/layout";
import {AuthPage} from "./components/Authorization/AuthPage";
import {UserPlacemarks} from './components/maps/UserPlacemarks';
import Registration from "./components/Authorization/Registration";
import Login from "./components/Authorization/Login";
import {Placemarks} from "./components/maps/Placemarks";
import "./App.css";

function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<Layout/>}>
                    <Route index element={<Navigate to="present"/>}/>
                    <Route element={<AuthRequired/>}>
                        <Route path="user" element={<UserPlacemarks/>}/>
                    </Route>
                    <Route path=":type" element={<Placemarks/>}/>
                </Route>
                <Route path="/account" element={<AuthPage/>}>
                    <Route index element={<Navigate to="login"/>}/>
                    <Route path="login" element={<Login/>}/>
                    <Route path="registration" element={<Registration/>}/>
                </Route>
                <Route path="*" element={<Navigate to='/' replace={true}/>}/>
            </Routes>
        </>
    );
}

export default App;
