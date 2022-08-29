let pesoMask = IMask(document.getElementById('cadastroPetModalPeso'), {
    mask: Number,  // enable number mask
    scale: 2,  // digits after point, 0 for integers
    signed: false,  // disallow negative
    thousandsSeparator: '',  // any single char
    radix: ',',  // fractional delimiter
    mapToRadix: ['.'],  // symbols to process as radix
    padFractionalZeros: true,  // if true, then pads zeros at end to the length of scale
    normalizeZeros: true,  // appends or removes zeros at ends
    // additional number interval options (e.g.)
    min: 0,
    max: 120.00
});

let alturaMask = IMask(document.getElementById('cadastroPetModalAltura'), {
    mask: Number,  // enable number mask
    scale: 2,  // digits after point, 0 for integers
    signed: false,  // disallow negative
    thousandsSeparator: '',  // any single char
    padFractionalZeros: true,  // if true, then pads zeros at end to the length of scale
    normalizeZeros: true,  // appends or removes zeros at ends
    radix: ',',  // fractional delimiter
    mapToRadix: ['.'],  // symbols to process as radix
    // additional number interval options (e.g.)
    min: 0,
    max: 1.60
});

let idadeMask = IMask(document.getElementById('cadastroPetModalIdade'), {
    mask: Number,  // enable number mask

    // additional number interval options (e.g.)
    min: 0,
    max: 100
});

document.getElementById('cadastroPetModalSalvar')
    .addEventListener('click', () => petHandleCadastrarButton());


let petHandleCadastrarButton = () => {
    let id = document.getElementById('cadastroPetModalId').value;
    let formData = petCadastroEditarGerarFormData();

    if (id === '') {
        petCadastrarPet(formData);
        return;
    }

    formData.append('id', id);
    
    petEditarPet(formData);
}

let petLimparCampos = () => {
    document.getElementById('cadastroPetModalId').value = '';
    document.getElementById('cadastroPetModalNome').value = '';
    document.getElementById('cadastroPetModalIdade').value = '';
    document.getElementById('cadastroPetModalPeso').value = '';
    document.getElementById('cadastroPetModalAltura').value = '';
    document.getElementById('cadastroPetModalArquivo').value = '';

    $('#cadastroPetModalResponsavel').val('').trigger('change');
    $('#cadastroPetModalRaca').val('').trigger('change');
}

let petCadastroEditarGerarFormData = () => {
    let nome = document.getElementById('cadastroPetModalNome').value;
    let idade = document.getElementById('cadastroPetModalIdade').value;
    let peso = document.getElementById('cadastroPetModalPeso').value;
    let altura = document.getElementById('cadastroPetModalAltura').value;
    let responsavelId = document.getElementById('cadastroPetModalResponsavel').value;
    let racaId = document.getElementById('cadastroPetModalRaca').value;
    let genero = document.querySelector('input[name="cadastroPetModalGenero"]:checked').value;
    let arquivo = document.getElementById('cadastroPetModalArquivo').files[0];

    altura = altura.replace('m', '').trim();
    peso = peso.replace('kg', '').trim();

    let formData = new FormData();
    formData.append('nome', nome);
    formData.append('idade', idade);
    formData.append('peso', peso);
    formData.append('altura', altura);
    formData.append('responsavelId', responsavelId);
    formData.append('racaId', racaId);
    formData.append('genero', genero);
    formData.append('arquivo', arquivo);

    return formData;
};

let petCadastrarPet = (formData) => {
    let statusResponse = 0;

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

                petLimparCampos();

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