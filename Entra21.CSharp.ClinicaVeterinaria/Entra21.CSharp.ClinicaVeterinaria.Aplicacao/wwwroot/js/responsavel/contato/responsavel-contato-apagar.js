document.querySelectorAll(".contato-button-apagar")
    .forEach(button => button.addEventListener('click', () => questionarApagar(button)));

let questionarApagar = (botaoApagar) => {
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
                apagar(botaoApagar);
        });
    });
}

let apagar = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');

    window.location.href = `/responsavelcontato/apagar?id=${id}`;
}