import  "../js/bootstrap.min.css";
 

import * as React from 'react';
import * as ReactDom from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';

ReactDom.render(
    <React.StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </React.StrictMode>, document.getElementById("app"));
