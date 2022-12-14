let veterinarioQuestionarApagar = (botaoApagar) => {
    botaoApagar.addEventListener('click', () => {
        swal({
            title: 'AVISO',
            text: 'Deseja apagar este registro?',
            icon: 'warning',
            buttons: ['Não', 'Sim'],
            dangerMode: true,
            closeModal: false
        }).then((confirmou) => {
            if (confirmou)
                responsavelApagar(botaoApagar);
        });
    });
}

let responsavelApagar = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');

    window.location.href = `/responsavel/apagar?id=${id}`;
}