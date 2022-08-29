document.querySelector('table').addEventListener('click', function (event) {
    if (event.target.tagName.toLowerCase() === 'button') {
        let button = event.target;
        let classList = button.classList;

        // Verificar se é o botão de editar
        if (classList.contains('responsavel-contato-editar')) { 
            contatoEditarPreencherModal(button);
        }
    }
});