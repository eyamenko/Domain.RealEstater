import * as React from "react";
import {Link} from "react-router-dom";

class Home extends React.Component {
    render() {
        return (
            <p className="text-center">
                Proceed to <Link to="/adverts">Adverts</Link> to list all advertised properties.
            </p>
        );
    }
}

export default Home;