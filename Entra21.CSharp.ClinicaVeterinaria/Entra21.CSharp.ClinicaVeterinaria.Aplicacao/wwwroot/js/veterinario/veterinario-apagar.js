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
                veterinarioApagar(botaoApagar);
        });
    });
}

let veterinarioApagar = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');

    toastr.clear();

    fetch(`/veterinario/apagar?id=${id}`)
        .then((response) => {
            let statusResponse = response.status;

            switch (statusResponse) {
                case 200:
                    toastr.success('Veterinário apagado com sucesso');
                    $('#veterinario-table').DataTable().ajax.reload();
                    break;
                case 404:
                    toastr.error('Não foi possível encontrar o Veterinário');
                    break;
                default:
                    toastr.error('Não foi possível apagar o veterinário');
            }

            swal.stopLoading();
            swal.close();
        })
        .catch((error) => console.log(error));
}