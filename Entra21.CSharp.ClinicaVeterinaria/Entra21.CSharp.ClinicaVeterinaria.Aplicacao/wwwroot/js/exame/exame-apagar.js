$('table').on('click', '.exame-apagar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    exameQuestionarApagar(element);
});

let exameQuestionarApagar = (botaoApagar) => {
    swal({
        title: 'AVISO',
        text: 'Deseja apagar este registro?',
        icon: 'warning',
        buttons: ['Não', 'Sim'],
        dangerMode: true,
        closeModal: false
    }).then((confirmou) => {
        if (confirmou)
            exameApagar(botaoApagar);
    });
}

let exameApagar = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');

    toastr.clear();

    fetch(`/exame/apagar?id=${id}`)
        .then((response) => {
            let statusResponse = response.status;

            switch (statusResponse) {
                case 200:
                    toastr.success('Exame apagado com sucesso');
                    $('#exame-table').DataTable().ajax.reload();
                    break;
                case 404:
                    toastr.error('Não foi possível encontrar o exame');
                    break;
                default:
                    toastr.error('Não foi possível apagar o exame');
            }

            swal.stopLoading();
            swal.close();
        })
        .catch((error) => console.log(error));
}