$('#iniciarAgendamentoConsultaModalResponsavel').select2({
    ajax: {
        url: '/responsavel/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({results: data})
    }
}).on('select2:select', function (e) {
    let selectPet = $('#iniciarAgendamentoConsultaModalPet');
    selectPet.val(null).trigger('change');
    selectPet.select2('open');
});

$('#iniciarAgendamentoConsultaModalPet').select2({
    ajax: {
        url: '/pet/obterTodosSelect2PorResponsavel',
        dataType: 'json',
        data: () => ({
            responsavelId: document.getElementById('iniciarAgendamentoConsultaModalResponsavel').value
        }),
        processResults: (data) => ({results: data})
    }
});

$('#iniciarAgendamentoConsultaModalVeterinario').select2({
    ajax: {
        url: '/veterinario/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({results: data})
    }
});