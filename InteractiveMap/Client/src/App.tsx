import React from 'react';
import { Routes, Route } from 'react-router-dom';
import './App.css';
import { Layout } from './components/layout/layout';
import { DefaultMap } from './components/maps/defaultMap';
import { FutureMap } from './components/maps/futureMap';
import { MyMap } from './components/maps/myMap';
import { MainMap } from './components/maps/mainMap';


function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="rezh" element={<MainMap />}/>
        </Route>
      </Routes>
    </>
  );
}

export default App;
