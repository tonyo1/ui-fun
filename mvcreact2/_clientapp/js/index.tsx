import "./bootstrap.min.css";

import * as React from "react";
import * as ReactDom from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { Provider } from "react-redux";
import NavHeader from "./components/nav-header";
import * as Redux from "./store";

ReactDom.render(
  <React.StrictMode>
    <Provider store={Redux.store}>
      <BrowserRouter basename="/app">
        <NavHeader />
        <App />{" "}
      </BrowserRouter>
    </Provider>
  </React.StrictMode>,
  document.getElementById("app")
);
