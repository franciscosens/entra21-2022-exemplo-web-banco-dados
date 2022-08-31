$('#exame-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/exame/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {data: 'nome'},
        {
            data: null,
            render: (data, type, exame) => formatarMoeda(exame.preco)
        },
        {
            data: null,
            width: '20%',
            render: function (data, type, exame) {
                return `<button class='btn btn-primary exame-editar' data-id='${exame.id}'>
                    <i class='fa-solid fa-pencil'></i> Editar
                </button>
                <button class='btn btn-outline-danger exame-apagar' data-id='${exame.id}'>
                    <i class='fa-solid fa-trash'></i> Apagar
                </button>`;
            }
        }
    ],
});