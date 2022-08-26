let editarPreencherModal = (botaoEditar) => {
    let id = botaoEditar.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/veterinario/obterPorId?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('editarVeterinarioModal'), {});
                
                document.getElementById('editarVeterinarioModalLabel').innerText = `Editar Veterinário: ${data.nome} - ${data.crmv}`
                document.getElementById('editarVeterinarioModalId').value = data.id;
                document.getElementById('editarVeterinarioModalIdade').value = data.idade;
                document.getElementById('editarVeterinarioModalSalario').value = data.salario;

                modal.show();
            }

            console.log(data);
        })
        .catch((error) => console.log(error));
};

let botaoSalvarModalEditar = () => {
    let id = parseInt(document.getElementById('editarVeterinarioModalId').value);
    let idade = document.getElementById('editarVeterinarioModalIdade').value
    let salario = document.getElementById('editarVeterinarioModalSalario').value;

    fetch('veterinario/editar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: id,
            idade: idade,
            salario: salario
        })
    })
        .then((response) => {
            if (response.status === 200) {
                toastr.success('Veterinário alterado com sucesso');

                let modal = bootstrap.Modal.getInstance(document.getElementById('editarVeterinarioModal'), {});
                modal.hide();

                $('#veterinario-table').DataTable().ajax.reload();
                return;
            }

            toastr.error('Não foi possível alterar o veterinário');
        })
        .catch((error) => console.err(error));
};

document.getElementById('editarVeterinarioModalSalvar').addEventListener('click', () => {
    botaoSalvarModalEditar();
});