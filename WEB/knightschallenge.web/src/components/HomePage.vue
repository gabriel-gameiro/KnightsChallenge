<template>
    <div class="container mt-4">
        <h1>Lista de personagens</h1>

        <div class="mt-4 d-flex justify-content-between">
            <button class="btn btn-outline-success" v-on:click="criar()">Criar novo</button>
            <div class="d-flex">
                <button v-on:click="listarHallOfHeroes()" class="btn btn-outline-secondary">Hall of Heroes</button>
                <button v-on:click="listarKnights()" class="btn btn-outline-primary ms-2">Knights</button>
            </div>
        </div>

        <!-- Tabela dos knights da base -->
        <div class="w-100 mt-4 table-responsive ">
            <table class="table table-hover table-responsive ">
                <thead>
                    <tr>
                        <th scope="col">Nome</th>
                        <th scope="col">Idade</th>
                        <th scope="col">Armas</th>
                        <th scope="col">Atributo</th>
                        <th scope="col">Ataque</th>
                        <th scope="col">Exp</th>
                        <th scope="col" class="text-right">Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <tr style="cursor: pointer;" class="align-items-center" v-for="knight of knights" :key="knight.id">
                        <td>{{ knight.nome }}</td>
                        <td>{{ knight.idade }}</td>
                        <td>{{ knight.armas }}</td>
                        <td>{{ knight.atributo }}</td>
                        <td>{{ knight.ataque }}</td>
                        <td>{{ knight.exp }}</td>
                        <td>
                            <span class="text-primary" v-on:click="detalhar(knight)">Detalhar</span>
                            <span class="ms-4 text-danger" v-on:click="removerKnight(knight)">Matar</span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <!-- Modal para edicao e consulta dos knights -->
        <b-modal id="modal-detalhes" ref="modal-detalhes" title="Detalhes do personagem">
            <div class="d-block text-center">
                <h4>Informações</h4>
                <div class="row mb-4">
                    <input hidden type="text" v-model="knightDetalhe.id">
                    <div class="col-6 mb-3">
                        <label for="">Nome</label>
                        <input type="text" class="form-control" v-model="knightDetalhe.name">
                    </div>
                    <div class="col-6 mb-3">
                        <label for="">Apelido</label>
                        <input type="text" class="form-control" v-model="knightDetalhe.nickname">
                    </div>
                    <div class="col-6 mb-3">
                        <label for="">Ataque</label>
                        <input type="text" class="form-control" v-model="knightDetalhe.attack">
                    </div>
                    <div class="col-6 mb-3">
                        <label for="">Aniversário</label>
                        <input type="text" class="form-control" v-model="knightDetalhe.birthday">
                    </div>
                    <div class="col-6 mb-3">
                        <label for="">Especialidade</label>
                        <input type="text" class="form-control" v-model="knightDetalhe.keyAttribute">
                    </div>
                </div>

                <h4>Atributos</h4>
                <div class="row mb-4">
                    <div class="col-3">
                        <label for="">Força</label>
                        <input type="number" class="form-control mb-3" v-model="knightDetalhe.attributes.strength">
                    </div>
                    <div class="col-3">
                        <label for="">Destreza</label>
                        <input type="number" class="form-control mb-3" v-model="knightDetalhe.attributes.dexterity">
                    </div>
                    <div class="col-3">
                        <label for="">Constituição</label>
                        <input type="number" class="form-control mb-3" v-model="knightDetalhe.attributes.constitution">
                    </div>
                    <div class="col-3">
                        <label for="">Inteligencia</label>
                        <input type="number" class="form-control mb-3" v-model="knightDetalhe.attributes.intelligence">
                    </div>
                    <div class="col-3">
                        <label for="">Sabedoria</label>
                        <input type="number" class="form-control mb-3" v-model="knightDetalhe.attributes.wisdom">
                    </div>
                    <div class="col-3">
                        <label for="">Carisma</label>
                        <input type="number" class="form-control mb-3" v-model="knightDetalhe.attributes.charisma">
                    </div>
                </div>

                <h4>Armas</h4>
                <div class="row mg-4">
                    <table class="table table-hover table-responsive ">
                        <thead>
                            <tr>
                                <th scope="col">Nome</th>
                                <th scope="col">Modificador</th>
                                <th scope="col">Atributo</th>
                                <th scope="col">Equipado</th>
                                <th scope="col">Ação</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr style="cursor: pointer;" class="align-items-center"
                                v-for="(weapon, index) of knightDetalhe.weapons" :key="weapon.name">
                                <td>{{ weapon.name }}</td>
                                <td>{{ weapon.mod }}</td>
                                <td>{{ weapon.attr }}</td>
                                <td>{{ weapon.equipped }}</td>
                                <td>
                                    <b-button v-on:click="removerArma(index)" variant="outline-danger"
                                        size="sm">Remover</b-button>
                                </td>
                            </tr>

                            <tr style="cursor: pointer;" class="align-items-center">
                                <td> <b-form-input v-model="newWeapon.name" size="sm" type="text" class="w-100" /> </td>
                                <td> <b-form-input v-model="newWeapon.mod" size="sm" type="number" class="w-100" />
                                </td>
                                <td> <b-form-input v-model="newWeapon.attr" size="sm" type="text" class="w-100" /> </td>
                                <!-- <td> <b-form-input v-model="newWeapon.equipped" size="sm" type="checkbox" class="w-100"/> </td> -->
                                <td> <b-form-checkbox v-model="newWeapon.equipped" value="true"
                                        unchecked-value="false" /> </td>
                                <td>
                                    <b-button v-on:click="adicionarArma()" variant="outline-success"
                                        size="sm">Adicionar</b-button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <template #modal-footer>
                <button v-on:click="$bvModal.hide('modal-detalhes')"
                    class="btn btn-outline-danger btn-sm m-1">Cancelar</button>
                <button v-on:click="salvarKnight()" class="btn btn-success btn-sm m-1">Salvar</button>
            </template>
        </b-modal>
    </div>
</template>

<script>

import KnightsService from '../services/knightsService.js';
import { BModal, VBModal } from 'bootstrap-vue'

export default {
    // Referencias que esse componente faz a outros componentes
    components: { BModal },

    // Alias do componente para tag html
    directives: { 'b-modal': VBModal },

    // Metodos que serao consumidos pela tela
    methods: {
        detalhar: function (knight) {
            console.log(knight);

            // consulta detalhes na API
            KnightsService.detalharKnight(knight.id)
                .then(res => {
                    this.knightDetalhe = res.data;
                    console.log('Sucesso ao detalhar knight: ', this.knightDetalhe);
                })
                .catch(res => {
                    console.log('Erro ao obter detalhes do knight:', res);
                });

            this.$refs['modal-detalhes'].show()
        },

        criar: function () {
            this.knightDetalhe = { attributes: {} }
            this.newWeapon = {}
            this.$refs['modal-detalhes'].show();
        },

        salvarKnight: function () {
            if (this.knightDetalhe.id == null) {
                this.knightDetalhe.id = "";
                KnightsService.criarKnight(this.knightDetalhe)
                    .then(() => {
                        console.log('Sucesso ao criar knight.');
                    })
                    .catch(res => {
                        console.log('Erro ao criar knight:', res);
                    });
            }
            else {
                KnightsService.atualizarKnight(this.knightDetalhe)
                    .then(() => {
                        console.log('Sucesso ao atualizar knight.');
                    })
                    .catch(res => {
                        console.log('Erro ao atualizar knight:', res);
                    });
            }
        },

        adicionarArma: function () {
            if (this.knightDetalhe.weapons == null)
                this.knightDetalhe.weapons = [];

            this.knightDetalhe.weapons.push({
                name: this.newWeapon.name,
                mod: this.newWeapon.mod,
                attr: this.newWeapon.attr,
                equipped: this.newWeapon.equipped == "true",
            });

            this.newWeapon = {};
        },

        removerArma: function (index) {
            this.knightDetalhe.weapons.splice(index, 1);
        },

        listarHallOfHeroes: function () {
            KnightsService.listarHallOfHeroes()
                .then(res => {
                    this.knights = res.data;
                    console.log('Sucesso ao detalhar heroes: ', res.data);
                })
                .catch(res => {
                    console.log('Erro ao obter detalhes heroes:', res);
                });
        },

        listarKnights: function () {
            KnightsService.listarKnights()
                .then(res => {
                    this.knights = res.data;
                })
                .catch(res => {
                    console.log('Erro ao obter knights:', res);
                });
        },

        removerKnight: function (knight) {
            KnightsService.removerKnight(knight.id)
                .then(res => {
                    console.log('Sucesso ao remover knight:', res);
                    this.listarKnights();
                })
                .catch(res => {
                    console.log('Erro ao remover knight:', res);
                });
        },
    },

    // Inicia variaveis que serao consumidas pela tela
    data() {
        return {
            knights: [],
            knightDetalhe: { attributes: {} },
            newWeapon: {}
        }
    },


    // Ao carregar a tela, executa acoes que podem preencher as variaveis iniciadas acima
    mounted() {
        this.listarKnights();
    }
}

</script>
