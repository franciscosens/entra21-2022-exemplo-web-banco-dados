VMasker(document.getElementById('cadastroPetModalPeso')).maskMoney({
    // Decimal precision -> '90'
    precision: 2,
    // Decimal separator -> ',90'
    separator: ',',
    suffixUnit: 'kg'
});

VMasker(document.getElementById('cadastroPetModalAltura')).maskMoney({
    // Decimal precision -> '90'
    precision: 2,
    // Decimal separator -> ',90'
    separator: ',',
    suffixUnit: 'm'
});

VMasker(document.getElementById('cadastroPetModalIdade')).maskNumber();

document.getElementById('cadastroPetModalSalvar')
    .addEventListener('click', () => cadastrarPet());

let limparCampos = () => {
    document.getElementById('cadastroPetModalNome').value = '';
    document.getElementById('cadastroPetModalIdade').value = '';
    document.getElementById('cadastroPetModalPeso').value = '';
    document.getElementById('cadastroPetModalAltura').value = '';

    document.getElementById('cadastroPetModalResponsavel').value = '';
    document.getElementById('cadastroPetModalResponsavel').dispatchEvent(new Event('change'));

    document.getElementById('cadastroPetModalRaca').value = '';
    document.getElementById('cadastroPetModalRaca').dispatchEvent(new Event('change'));
}

let cadastrarPet = () => {
    let nome = document.getElementById('cadastroPetModalNome').value;
    let idade = document.getElementById('cadastroPetModalIdade').value;
    let peso = document.getElementById('cadastroPetModalPeso').value;
    let altura = document.getElementById('cadastroPetModalAltura').value;
    let responsavel = document.getElementById('cadastroPetModalResponsavel').value;
    let raca = document.getElementById('cadastroPetModalRaca').value;
    let genero = document.querySelector('input[name="cadastroPetModalGenero"]:checked').value;
    let arquivo = document.getElementById('cadastroPetModalArquivo').files[0];
    debugger;
    altura = altura.replace(',', '.').replace('m', '').trim();
    peso = peso.replace(',', '.').replace('kg', '').trim();

    let statusResponse = 0;

    var formData = new FormData();
    formData.append('nome', nome);
    formData.append('idade', idade);
    formData.append('peso', peso);
    formData.append('altura', altura);
    formData.append('responsavelId', responsavel);
    formData.append('racaId', raca);
    formData.append('genero', genero);
    formData.append('arquivo', arquivo);

    fetch('/pet/cadastrar', {
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

                limparCampos();

                $('#pet-table').DataTable().ajax.reload();

                toastr.success('PET cadastrado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível cadastrar o PET');
        });
}