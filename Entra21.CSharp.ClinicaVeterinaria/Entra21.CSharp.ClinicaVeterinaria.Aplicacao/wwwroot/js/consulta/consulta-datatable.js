// consulta-datatable.js

$('#tabela-consultas').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/consulta/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        { data: 'pet' },
        { data: 'veterinario' },
        { data: 'dataHoraPrevista' },
        {
            data: null,
            render: function (data, type, consulta) {
                let cor = '';
                let status  = '';
                if (consulta.status === 0) {
                    status = "Pendete";
                    cor = "warning text-dark";
                } else if (consulta.status === 1) {
                    status = "Em Andamento";
                    cor = "primary";
                } else if (consulta.status === 2) {
                    status = "Realizada";
                    cor = "success";
                } else if (consulta.status === 3) {
                    status = "Cancelada";
                    cor = "danger";
                }
                 
                return `<span class="badge bg-${cor}">${status}</span>`;
            }
        },
        {
            data: null,
            width: '20%',
            render: function (data, type, consulta) {
                if (consulta.status == 0) {
                    return `<button class="btn btn-primary consulta-iniciar" data-id="${consulta.id}">Iniciar</button>
                    <button class="btn btn-danger consulta-cancelar" data-id="${consulta.id}">Cancelar</button>`;
                }

                if (consulta.status == 1) {
                    return `<button class="btn btn-success consulta-finalizar" data-id="${consulta.id}">Finalizar</button>`;
                }

                if (consulta.status == 2) {
                    return `<button class="btn btn-light consulta-detalhar" data-id="${consulta.id}">Exibir detalhes</button>`;
                }

                return "";
            }
        }
    ],
});