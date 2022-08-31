$('#consulta-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/consulta/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {data: 'responsavel'},
        {data: 'pet'},
        {data: 'veterinario'},
        {data: 'dataConsulta'},
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