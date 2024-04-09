import { http } from "./config";

// Service para interacao com a API do projeto
// Por padrao retorna a Promise da requisicao
export default {

    listarKnights: () => {
        return http.get('Knight');
    },

    listarHallOfHeroes: () => {
        return http.get('Knight?filter=heroes');
    },

    detalharKnight: (id) => {
        return http.get(`Knight/${id}`);
    },

    criarKnight: (knight) => {
        return http.post('Knight', knight);
    },

    removerKnight: (id) => {
        return http.delete(`Knight/${id}`);
    },

}