import "./oldschool";
import "./App.css";

import * as React from "react";
import * as Redux from "./store";
import { Routes, Route } from "react-router-dom";

import NavHeader from "./components/nav-header";
import Home from "./components/_about/home";
import { Footer } from "./components/footer";
import { NoMatch } from "./components/_about/NoMatch";
import About from "./components/_about/about";
import { Provider } from "react-redux";

export default class App extends React.Component<{}> {
  render() {
    return (
      <>
        <Provider store={Redux.store}>
          <NavHeader />
          <main
            className="main container row h-100"
            style={{ border: "1px solid #ff0000" }}
          >
            <div className="col-sm-12 my-auto">
              <div className="card card-block w-25">
                <Routes>
                  <Route path="/" element={<Home />} />
                  <Route path="home" element={<Home />} />
                  <Route path="about/*" element={<About />} />
                  <Route path="*" element={<NoMatch />} />
                </Routes>
              </div>
            </div>
          </main>
          <Footer />
        </Provider>
      </>
    );
  }
}
