import * as React from "react";
import advertsStore from "./store";
import {Provider} from "mobx-react";
import PropertyList from "./components/PropertyList";

export default () => (
    <Provider advertsStore={advertsStore}>
        <PropertyList/>
    </Provider>
);