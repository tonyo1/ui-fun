import * as React from "react";
import * as Redux from "./store";
import { Routes, Route } from "react-router-dom";

import NavHeader from "./components/nav-header";
import Home from "./pages/home";
import { Footer } from "./components/footer";
import { NoMatch } from "./pages/NoMatch";
import About from "./components/_about/about";
import { Provider } from "react-redux";

export default class App extends React.Component<{}> {
  render() {
    return (
      <>
        <Provider store={Redux.store}>
          <NavHeader />
          <main className="main">
            <Routes>
              <Route path="/home" element={<Home />} />
              <Route path="/about/*" element={<About />} />
              <Route path="/" element={<Home />} />
              <Route path="*" element={<NoMatch />} />
            </Routes>
          </main>
          <Footer />
        </Provider>
      </>
    );
  }
}
