import { http } from "./config";

export default {

    listarKnights: () => {
        return http.get('Knight');
    }

}