import { Routes, Route, Navigate } from "react-router-dom";
import { Layout } from "./components/layout/layout";
import {AuthPage} from "./components/Authorization/AuthPage";
import {Placemarks} from './components/maps/placemarks';
import Registration from "./components/Authorization/Registration";
import Login from "./components/Authorization/Login";
import "./App.css";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Navigate to="present" />}/>
          <Route path=":type" element={<Placemarks />} />
        </Route>
        <Route path="/account" element={<AuthPage />}>
          <Route index element={<Navigate to="login" />}/>
          <Route path='login' element={<Login />} />
          <Route path="registration" element={<Registration />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
