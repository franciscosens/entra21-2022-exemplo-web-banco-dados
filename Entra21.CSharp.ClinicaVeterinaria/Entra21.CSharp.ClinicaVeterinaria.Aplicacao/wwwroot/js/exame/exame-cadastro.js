document.getElementById('cadastroExameModalSalvar').addEventListener('click', () => exameHandleCadastrarButton());

let exameHandleCadastrarButton = () => {
    let id = document.getElementById('cadastroExameModalId').value;
    let bodyRequest = exameCadastroEditarGerarBodyRequest();

    if (id === '') {
        exameCadastrarExame(bodyRequest);
        return;
    }

    bodyRequest.id = id;

    exameEditarExame(bodyRequest);
}

let exameCadastroEditarGerarBodyRequest = () => {
    let nome = document.getElementById('cadastroExameModalNome').value;
    let preco = document.getElementById('cadastroExameModalPreco').value;
    let descricao = document.getElementById('cadastroExameModalDescricao').value;
    let body = {
        nome, preco, descricao
    }

    return body;
}

let exameCadastrarExame = (bodyRequest) => {
    let statusResponse = 0;

    fetch('/exame/cadastrar', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json',
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

                toastr.success('Exame cadastrado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível cadastrar o Exame');
        });
};

let exameLimparCampos = () => {
    document.getElementById('cadastroExameModalLabel').value = 'Cadastro de Exame';
    document.getElementById('cadastroExameModalSalvar').value = 'Cadastrar';
    document.getElementById('cadastroExameModalId').value = '';
    document.getElementById('cadastroExameModalNome').value = '';
    document.getElementById('cadastroExameModalPreco').value = '';
    document.getElementById('cadastroExameModalDescricao').value = '';
}