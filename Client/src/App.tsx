import { Routes, Route, Navigate } from "react-router-dom";
import { Layout } from "./components/layout/layout";
import { AuthPage } from "./components/Authorization/AuthPage";
import { DefaultPlacemarks } from "./components/maps/DefaultPlacemarks";
import Registration from "./components/Authorization/Registration";
import Login from "./components/Authorization/Login";
import "./App.css";
import { ProposalPlacemarks } from "./components/maps/ProposalPlacemarks";
import { Events } from "./components/maps/Events";
import { About } from "./components/About/About";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Navigate to="present" />} />
          <Route path=":type" element={<DefaultPlacemarks />} />
          <Route path="proposals" element={<ProposalPlacemarks />} />
          <Route path="events" element={<Events />} />
        </Route>
        <Route path="/about" element={<About />} /> 
        <Route path="/account" element={<AuthPage />}>
          <Route index element={<Navigate to="login" />} />
          <Route path="login" element={<Login />} />
          <Route path="registration" element={<Registration />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
