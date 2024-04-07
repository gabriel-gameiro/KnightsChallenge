<template>
    <div class="container mt-4">
        <h1>Lista de personagens</h1>

        <div class="mt-4 d-flex justify-content-between">
            <button class="btn btn-outline-success">Criar novo</button>
            <button class="btn btn-primary"  data-bs-toggle="modal" data-bs-target="#modalInfos">Hall of Heroes</button>
        </div>

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
                        <td class="align-self-end ">{{ knight.nome }}</td>
                        <td>{{ knight.idade }}</td>
                        <td>{{ knight.armas }}</td>
                        <td>{{ knight.atributo }}</td>
                        <td>{{ knight.ataque }}</td>
                        <td>{{ knight.exp }}</td>
                        <td><span class="text-danger">Matar</span></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div id="modalInfos" class="modal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Detalhes do personagem</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-6">
                                <label for="">Nome</label>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-6">
                                <label for="">Nome</label>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-6">
                                <label for="">Nome</label>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-6">
                                <label for="">Nome</label>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-6">
                                <label for="">Nome</label>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-6">
                                <label for="">Nome</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
    </div>
</template>

<script>

import KnightsService from '../services/knightsService.js';

export default {
    data() {
        return {
            knights: []
        }
    },

    mounted() {
        KnightsService.listarKnights().then(res => {
            this.knights = res.data;
        });
    }
}

</script>