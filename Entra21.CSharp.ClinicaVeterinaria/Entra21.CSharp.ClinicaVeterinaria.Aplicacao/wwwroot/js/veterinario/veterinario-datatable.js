$('#veterinario-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/veterinario/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {data: 'nome'},
        {data: 'crmv'},
        {
            data: null,
            width: '20%',
            render: function (data, type, veterinario) {
                return `<button class='btn btn-primary veterinario-editar' data-id='${veterinario.id}'>
                <i class='fa-solid fa-pencil'></i> Editar
                </button>
                <button class='btn btn-outline-danger veterinario-apagar' data-id='${veterinario.id}'>
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

        if (classList.contains('veterinario-editar')) { // Verificar se é o botão de editar
            veterinarioEditarPreencherModal(button);
        } else if (classList.contains('veterinario-apagar')) { // Verificar se é o botão de apagar
            veterinarioQuestionarApagar(button);
        }
    }
});