document.querySelectorAll(".responsavel-contato-editar")
    .forEach(button => button.addEventListener('click', () => contatoEditarPreencherModal(button)));


let contatoEditarPreencherModal = (button) => {
    debugger;
    let id = button.getAttribute('data-id');
    
    fetch(`/responsavelContato/editar?id=${id}`)
        .then((response) => response.text())
        .then((response) => {
            document.getElementById("modal-contato").innerHTML = response;

            contatoAbrirModalEditarAtribuindoClickBotaoSalvarCriadoDinamicamente();
        })
}

let contatoAbrirModalEditarAtribuindoClickBotaoSalvarCriadoDinamicamente = () => {

    if (document.getElementsByClassName("modal-backdrop show").length > 0) {
        document.getElementsByTagName("body")[0].removeChild(document.getElementsByClassName("modal-backdrop show")[0]);
    }

    let modal = new bootstrap.Modal(document.getElementById('editarResponsavelContatoModal'), {});
    modal.show();
    
    document.getElementById('responsavel-contato-editar-form')
        .addEventListener('submit', (event) => contatoAtualizarContato(event));
}

let contatoAtualizarContato = (event) => {
    event.preventDefault();

    let id = parseInt(event.target.getAttribute("data-id"));
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
            id,
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

            toastr.error('Não foi possível alterar o contato');
        })
        .catch((error) => {
            toastr.error('Não foi possível alterar o contato');

            console.error(error);
        });
}

