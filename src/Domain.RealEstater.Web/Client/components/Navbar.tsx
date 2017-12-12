import * as React from "react";
import {observer, inject} from "mobx-react";
import {NavLink} from "react-router-dom";
import {withRouter} from "react-router";
import {Store} from "../store";
import "../styles/Navbar.scss";

interface IProps {
    store?: Store
}

@withRouter
@inject("store")
@observer
class Navbar extends React.Component<IProps> {
    store: Store;

    constructor(props: IProps) {
        super(props);

        this.store = props.store!;
    }

    render() {
        return (
            <nav className="Navbar navbar navbar-expand-lg navbar-dark bg-dark">
                <div className="navbar-brand"/>
                <button className="navbar-toggler" type="button" onClick={() => this.store.toggleNavbar()}
                        aria-controls="navbar" aria-expanded={this.store.navbarOpen} aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"/>
                </button>
                <div className={"collapse navbar-collapse" + (this.store.navbarOpen ? " show" : "")} id="navbar">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <NavLink className="nav-link" exact to="/">Home</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/adverts">Adverts</NavLink>
                        </li>
                    </ul>
                </div>
            </nav>
        );
    }
}

export default Navbar;