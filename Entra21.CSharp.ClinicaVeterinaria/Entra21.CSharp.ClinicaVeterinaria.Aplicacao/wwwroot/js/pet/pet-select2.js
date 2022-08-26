$('#cadastroPetModalRaca').select2({
    ajax: {
        url: '/raca/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({ results: data})
    }
});

$('#cadastroPetModalResponsavel').select2({
    ajax: {
        url: '/responsavel/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({ results: data})
    }
});