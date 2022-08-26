document.getElementById('responsavel-cadastro').addEventListener('click', (event) => {
    let url = event.target.getAttribute('data-url');

    fetch(url)
        .then((response) => response.text())
        .then((response) => {
            document.getElementById("modal-contato").innerHTML = response;

            abrirModalCadastroAtribuindoClickBotaoSalvarCriadoDinamicamente();
        })
});

let abrirModalCadastroAtribuindoClickBotaoSalvarCriadoDinamicamente = () => {

    if (document.getElementsByClassName("modal-backdrop show").length > 0) {
        document.getElementsByTagName("body")[0].removeChild(document.getElementsByClassName("modal-backdrop show")[0]);
    }

    let modal = new bootstrap.Modal(document.getElementById('cadastroResponsavelContatoModal'), {});
    modal.show();

    // atribuirClickBotaoSalvarCriadoDinamicamente
    document.getElementById('responsavel-contato-cadastrar-form')
        .addEventListener('submit', (event) => saveContact(event));
}

let saveContact = (event) => {
    event.preventDefault();

    let responsavelId = parseInt(document.getElementById('ResponsavelId').value);
    let tipo = document.getElementById('Tipo').value;
    let valor = document.getElementById('Valor').value;
    let observacao = document.getElementById('Observacao').value;

    let statusResponse = 0;

    fetch(event.target.action, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            responsavelId,
            tipo,
            valor,
            observacao
        })
    })
        .then((response) => {
            statusResponse = response.status;
            return response.text();
        })
        .then((response) => {
            if (statusResponse === 200) {

                document.getElementById("modal-contato").innerHTML = response;

                abrirModalCadastroAtribuindoClickBotaoSalvarCriadoDinamicamente();

                return;
            }
            
            if (statusResponse === 201) {
                window.location.href = window.location.href;
                return;
            }
            
            toastr.error('Não foi possível cadastrar o contato');
        })
        .catch((error) => {
            toastr.error('Não foi possível cadastrar o contato');
            
            console.error(error);
        });
}

