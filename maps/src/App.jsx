import React from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import './App.css';
import { Header } from './components/header/header';
import { Layout } from './components/layout/layout';
import { DefaultMap } from './components/maps/defaultMap';
import { PastMap } from './components/maps/pastMap';
import { FutureMap } from './components/maps/futureMap';


function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<DefaultMap />}/>
          <Route path="past" element={<PastMap />}/>
          <Route path="future" element={<FutureMap />}/>
        </Route>
      </Routes>
    </>
  );
}

export default App;
