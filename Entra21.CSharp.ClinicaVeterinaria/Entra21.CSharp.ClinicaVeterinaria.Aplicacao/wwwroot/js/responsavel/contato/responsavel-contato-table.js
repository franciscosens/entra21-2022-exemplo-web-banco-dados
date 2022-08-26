document.querySelector('table').addEventListener('click', function (event) {
    if (event.target.tagName.toLowerCase() === 'button') {
        let button = event.target;
        let classList = button.classList;

        if (classList.contains('responsavel-contato-editar')) { // Verificar se é o botão de apagar
            editarPreencherModal(button);
        }
    }
});