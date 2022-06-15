import { Routes, Route, Navigate } from "react-router-dom";
import { AuthRequeired } from "./utils/AuthRequired";
import { Layout } from "./components/layout/layout";
import { AuthPage } from "./components/Authorization/AuthPage";
import { DefaultPlacemarks } from './components/maps/DefaultPlacemarks';
import Registration from "./components/Authorization/Registration";
import Login from "./components/Authorization/Login";
import { ProposalPlacemarks } from "./components/maps/ProposalPlacemarks";
import { Events } from "./components/maps/Events";
import "./App.css";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Navigate to="present" />} />
          <Route element={<AuthRequeired />}>
            <Route path="user" element={<DefaultPlacemarks />} />
          </Route>
          <Route path=":type" element={<DefaultPlacemarks />} />
          <Route path="proposals" element={<ProposalPlacemarks />} />
          <Route path="events" element={<Events />} />
        </Route>
        <Route path="/account" element={<AuthPage />}>
          <Route index element={<Navigate to="login" replace={true} />} />
          <Route path='login' element={<Login />} />
          <Route path="registration" element={<Registration />} />
        </Route>
        <Route path="*" element={<Navigate to='/' replace={true} />} />
      </Routes>
    </>
  );
}

export default App;
