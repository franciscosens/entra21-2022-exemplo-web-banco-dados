$('table').on('click', 'button.exame-editar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    exameEditarPreencherModal(element);
});

// Limpar os campos quando a modal for fechada
document.getElementById('cadastroExameModal').addEventListener('hide.bs.modal', () => exameLimparCampos());

let exameEditarPreencherModal = (botaoEditar) => {
    let id = botaoEditar.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/exame/obterPorId?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((exame) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('cadastroExameModal'), {});

                document.getElementById('cadastroExameModalSalvar').value = 'Salvar';
                document.getElementById('cadastroExameModalLabel').innerText = `Editar Exame: ${exame.nome}`
                document.getElementById('cadastroExameModalId').value = exame.id;
                document.getElementById('cadastroExameModalNome').value = exame.nome;
                document.getElementById('cadastroExameModalPreco').value = exame.preco;
                document.getElementById('cadastroExameModalDescricao').value = String(exame.descricao).replace('.', ',');

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let exameEditarExame = (bodyRequest) => {
    let statusResponse = 0;

    fetch('/exame/editar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bodyRequest)
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('cadastroExameModal')).hide();

                exameLimparCampos();

                $('#exame-table').DataTable().ajax.reload();

                toastr.success('Exame alterado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível alterar o exame');
        });
}