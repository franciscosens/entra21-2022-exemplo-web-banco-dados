document.getElementById('cadastroVeterinarioModalSalvar').addEventListener('click', () => {
    let nome = document.getElementById('cadastroVeterinarioModalNome').value;
    let crmv = document.getElementById('cadastroVeterinarioModalCrmv').value;
    let statusResponse = 0;

    fetch('/veterinario/cadastrar', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            nome: nome,
            crmv: crmv
        })
    })
        .then((response) => {
            statusResponse = response.status;
            return response.json();
        })
        .then((response) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('cadastroVeterinarioModal')).hide();

                document.getElementById('cadastroVeterinarioModalNome').value = '';
                document.getElementById('cadastroVeterinarioModalCrmv').value = '';

                $('#veterinario-table').DataTable().ajax.reload();

                toastr.success('Veterinário cadastrado com sucesso');

                return;
            }
            
            showNotificationErrorsOfValidation(response);
        })
        .catch((error) => {
            toastr.error("Não foi possível cadastrar veterinário");
            
            console.log(error);
        });
});