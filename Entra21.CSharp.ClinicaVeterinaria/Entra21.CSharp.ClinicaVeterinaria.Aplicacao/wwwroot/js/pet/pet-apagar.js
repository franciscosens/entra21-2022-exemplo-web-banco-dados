$('table').on('click', '.pet-apagar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;
    
    petQuestionarApagar(element);
});

let petQuestionarApagar = (botaoApagar) => {
    swal({
        title: 'AVISO',
        text: 'Deseja apagar este registro?',
        icon: 'warning',
        buttons: ['Não', 'Sim'],
        dangerMode: true,
        closeModal: false
    }).then((confirmou) => {
        if (confirmou)
            petApagar(botaoApagar);
    });
}

let petApagar = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');

    toastr.clear();

    fetch(`/pet/apagar?id=${id}`)
        .then((response) => {
            let statusResponse = response.status;

            switch (statusResponse) {
                case 200:
                    toastr.success('Pet apagado com sucesso');
                    $('#pet-table').DataTable().ajax.reload();
                    break;
                case 404:
                    toastr.error('Não foi possível encontrar o pet');
                    break;
                default:
                    toastr.error('Não foi possível apagar o pet');
            }

            swal.stopLoading();
            swal.close();
        })
        .catch((error) => console.log(error));
}