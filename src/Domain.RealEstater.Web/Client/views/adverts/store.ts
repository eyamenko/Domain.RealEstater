import {action, observable, runInAction} from "mobx";
import Property from "./models/property";

export class AdvertsStore {
    @observable
    properties: Array<Property> = [];

    @observable
    loading: boolean;

    @action
    async fetchProperties() {
        this.loading = true;

        const response = await fetch("/api/advertising/properties");
        const json = await response.json();

        runInAction(() => {
            this.loading = false;
            this.properties = json;
        });
    }
}

export default new AdvertsStore();