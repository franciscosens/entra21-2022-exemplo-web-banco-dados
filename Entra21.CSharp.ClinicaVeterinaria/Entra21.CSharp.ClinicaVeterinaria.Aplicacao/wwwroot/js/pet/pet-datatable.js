$('#pet-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/pet/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {
            data: null,
            width: '20%',
            render: function (data, type, pet) {
                return `<img src="/Pets/${pet.caminhoArquivo}"/>`;
            }
        },
        {data: 'raca.nome'},
        {data: 'nome'},
        {data: 'responsavel.nomeCompleto'},
        {
            data: null,
            render: (data, type, pet) => pet.genero === 0 ? "Feminino" : "Masculino"
        },
        {
            data: null,
            width: '20%',
            render: function (data, type, pet) {
                return `<button class='btn btn-primary pet-editar' data-id='${pet.id}'>
                    <i class='fa-solid fa-pencil'></i> Editar
                </button>
                <button class='btn btn-outline-danger pet-apagar' data-id='${pet.id}'>
                    <i class='fa-solid fa-trash'></i> Apagar
                </button>`;
            }
        }
    ],
});

document.querySelector('table').addEventListener('click', function (event) {
    if (event.target.tagName.toLowerCase() === 'button') {
        let button = event.target;
        let classList = button.classList;

        if (classList.contains('pet-editar')) { // Verificar se é o botão de editar
            editarPreencherModal(button);
        } else if (classList.contains('pet-apagar')) { // Verificar se é o botão de apagar
            questionarApagar(button);
        }
    }
});