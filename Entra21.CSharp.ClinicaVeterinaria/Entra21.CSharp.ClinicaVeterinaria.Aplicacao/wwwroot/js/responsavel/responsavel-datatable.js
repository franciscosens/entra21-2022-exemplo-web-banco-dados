$('#responsavel-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/responsavel/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {data: 'nomeCompleto'},
        {data: 'cpf'},
        {data: 'idade'},
        {
            data: null,
            width: '20%',
            render: function (data, type, responsavel) {
                return `<a href="/responsavel/editar?id=${responsavel.id}" class='btn btn-primary'>
                    <i class='fa-solid fa-pencil'></i> Editar
                </a>
                <button class='btn btn-outline-danger responsavel-apagar' data-id='${responsavel.id}'>
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
        
        if (classList.contains('responsavel-apagar')) { // Verificar se é o botão de apagar
            veterinarioQuestionarApagar(button);
        }
    }
});