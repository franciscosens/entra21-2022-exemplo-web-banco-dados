$('table').on('click', 'button.pet-editar', (event) => {
    let element = event.target.tagName === 'I' 
        ? event.target.parentElement 
        : event.target;
    
    petEditarPreencherModal(element);
});

// Limpar os campos quando a modal for fechada
document.getElementById('cadastroPetModal').addEventListener('hide.bs.modal', () => petLimparCampos());

let petEditarPreencherModal = (botaoEditar) => {
    let id = botaoEditar.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/pet/obterPorId?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('cadastroPetModal'), {});

                document.getElementById('cadastroPetModalLabel').innerText = `Editar PET: ${data.nome}`
                document.getElementById('cadastroPetModalId').value = data.id;
                document.getElementById('cadastroPetModalNome').value = data.nome;
                document.getElementById('cadastroPetModalIdade').value = data.idade;
                document.getElementById('cadastroPetModalAltura').value = String(data.altura).replace('.', ',');
                document.getElementById('cadastroPetModalPeso').value = String(data.peso).replace('.', ',');

                if (data.genero === 0)
                    document.getElementById('cadastroPetGeneroFeminino').checked = true;
                else
                    document.getElementById('cadastroPetGeneroMasculino').checked = true;

                $('#cadastroPetModalResponsavel')
                    .append(new Option(data.responsavel.nomeCompleto, data.responsavel.id, false, false))
                    .val(data.responsavel.id)
                    .trigger('change');
                $('#cadastroPetModalRaca')
                    .append(new Option(data.raca.nome, data.raca.id, false, false))
                    .val(data.raca.id)
                    .trigger('change');

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let petEditarPet = (formData) => {
    let statusResponse = 0;

    fetch('/pet/editar', {
        method: 'POST',
        body: formData
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('cadastroPetModal')).hide();

                petLimparCampos();

                $('#pet-table').DataTable().ajax.reload();

                toastr.success('PET alterado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível alterar o PET');
        });
};