import React from "react";
import { Tabs, Tab, Button } from "react-bootstrap";
import { useAppSelector } from "../../hooks";
import IUser from "../../models/IUser";
import AboutForm from "./about-form";

import Page1 from "./page1";
import Page2 from "./page2";
import * as AppService from "../../services/appservice";

const About = () => {
  const user: IUser = useAppSelector((state) => state.userState.user);

  const [key, setKey] = React.useState<string>("");

  const [liveValue, setliveValue] = React.useState<string>("default");

  return (
    <>
      <h3>About {key}</h3>
      <div>{liveValue} </div>
      <Tabs
        defaultActiveKey=""
        transition={true}
        id="noanim-tab-example"
        className="mb-3"
        activeKey={key}
        onSelect={(k) => setKey(k + "")}
      >
        <Tab eventKey="page1" title="page1">
          <Page1 />
        </Tab>

        {user.loggedIn ? (
          <Tab eventKey="page2" title="PAGE2">
            <Page2 />
          </Tab>
        ) : (
          ""
        )}

        <Tab eventKey="page3" title="form stuff">
          <AboutForm />
        </Tab>
      </Tabs>
    </>
  );
};

export default About;
