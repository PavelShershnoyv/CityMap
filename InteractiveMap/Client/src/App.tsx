import { Routes, Route, Navigate } from "react-router-dom";
import { Layout } from "./components/layout/layout";
import { DefaultMap } from "./components/maps/defaultMap";
import { PastMap } from "./components/maps/pastMap";
import { FutureMap } from "./components/maps/futureMap";
import {AuthPage} from "./components/Authorization/AuthPage";
import Registration from "./components/Authorization/Registration";
import Login from "./components/Authorization/Login";
import "./App.css";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<DefaultMap />} />
          <Route path="past" element={<PastMap />} />
          <Route path="future" element={<FutureMap />} />
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
