import * as React from "react";
import Property from "../models/property";
import {inject, observer} from "mobx-react";
import {AdvertsStore} from "../store";
import Loader from "../../../components/Loader";

interface IPropertyItemProps {
    property: Property;
}

interface IPropertyListProps {
    advertsStore?: AdvertsStore
}

function PropertyItem(props: IPropertyItemProps) {
    return (
        <tr>
            <td>{props.property.name}</td>
            <td>{props.property.address}</td>
            <td>{props.property.agencyCode}</td>
            <td>{props.property.latitude}</td>
            <td>{props.property.longitude}</td>
        </tr>
    );
}

@inject("advertsStore")
@observer
class PropertyList extends React.Component<IPropertyListProps> {
    advertsStore: AdvertsStore;

    constructor(props: IPropertyListProps) {
        super(props);

        this.advertsStore = props.advertsStore!;
    }

    componentDidMount() {
        this.advertsStore.fetchProperties();
    }

    render() {
        if (this.advertsStore.loading) {
            return <Loader/>;
        }

        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Agency code</th>
                        <th>Latitude</th>
                        <th>Longitude</th>
                    </tr>
                </thead>
                <tbody>
                    {this.advertsStore.properties.map((p, idx) => <PropertyItem key={idx} property={p}/>)}
                </tbody>
            </table>
        );
    }
}

export default PropertyList;