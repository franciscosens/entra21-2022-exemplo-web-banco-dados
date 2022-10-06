// Carregar os veterinarios quando o usuário abrir o campo
$('#campo-veterinario').select2({
    ajax: {
        url: '/veterinario/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({ results: data })
    }
});

$('#campo-pet').select2({
    ajax: {
        url: '/pet/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({ results: data })
    }
});