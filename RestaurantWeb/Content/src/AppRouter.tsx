
import * as React from "react";
import { Route } from 'react-router';
import { MenuBox } from "./MenuBox";

export class AppRouter extends React.Component {    

    render() {
        return (
            <div>
                <Route exact path='/' component={MenuBox} />                                
            </div>
        );
    }
}