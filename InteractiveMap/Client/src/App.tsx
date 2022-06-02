import React from 'react';
import { Routes, Route } from 'react-router-dom';
import './App.css';
import { Layout } from './components/layout/layout';
import { DefaultMap } from './components/maps/defaultMap';
import { PastMap } from './components/maps/pastMap';
import { FutureMap } from './components/maps/futureMap';
import { MyMap } from './components/maps/myMap';
import { MainMap } from './components/maps/mainMap';


function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="default" element={<DefaultMap />}/>
          <Route path="past" element={<PastMap />}/>
          <Route path="future" element={<FutureMap />}/>
        </Route>
      </Routes>
    </>
  );
}

export default App;
