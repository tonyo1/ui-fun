import  "./about.css";
import React from "react";
import { Tabs, Tab, Button } from "react-bootstrap"; 
import { useAppSelector } from "../../hooks";
import IUser from "../../models/IUser";
import AboutForm from "./about-form";

import Page1 from "./page1";
import Page2 from "./page2";


const About = () => {
    const user: IUser = useAppSelector(state => state.userState.user);

    const [key, setKey] = React.useState<string>('');

    const handleSubmit = (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        alert("clicked");
        // or you can send to backend
    };

    return (
        <>
            <h2>About{key}</h2>
            <Tabs
                defaultActiveKey=""
                transition={true}
                id="noanim-tab-example"
                className="mb-3"
                activeKey={key}
                onSelect={(k) => setKey(k + '')}
            >
                <Tab eventKey="page1" title="page1">
                    <Page1 />
                </Tab>

                {user.loggedIn
                    ? (
                        <Tab eventKey="page2" title="PAGE2">
                            <button onClick={handleSubmit} type="submit" title="Empty" >
                                click
                            </button>
                            <Page2 />
                        </Tab>)
                    : ''}


                <Tab eventKey="page3" title="form stuff">
                    <AboutForm />
                </Tab>
            </Tabs>



        </>
    );
}

export default About;
