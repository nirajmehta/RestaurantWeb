// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from "react";
import * as ReactDOM from "react-dom";
import { BrowserRouter } from 'react-router-dom';
import { AppRouter } from "./AppRouter";

const rootElement = document.getElementById('foodorder');

ReactDOM.render(
    <BrowserRouter basename="/">
        <AppRouter />
    </BrowserRouter>,
    rootElement);






