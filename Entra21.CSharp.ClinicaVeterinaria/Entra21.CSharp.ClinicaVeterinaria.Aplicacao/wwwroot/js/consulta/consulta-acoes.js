$('table').on('click', '.consulta-iniciar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    consultaIniciar(element);
});

$('table').on('click', '.consulta-cancelar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    consultaCancelar(element);
});

$('table').on('click', '.consulta-finalizar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    consultaFinalizar(element);
});


let cancelarAgendamento = () => {
    let id = document.getElementById('campo-id-cancelamento').value;
    let motivo = document.getElementById('campo-motivo').value;

    let formData = new FormData();
    formData.append('id', id);
    formData.append('motivo', motivo);

    fetch('/consulta/cancelar', {
        method: 'POST',
        body: formData
    })
        .then((data) => {
            $('#tabela-consultas').DataTable().ajax.reload();

            bootstrap.Modal.getInstance(
                document.getElementById('cancelarModal')).hide();

            toastr.success('Agendamento cancelado com sucesso');
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível iniciar a consulta');
        })
}

let consultaCancelar = (element) => {
    let id = element.getAttribute("data-id");
    document.getElementById('campo-id-cancelamento').value = id;

    let modal = new bootstrap.Modal(
        document.getElementById('cancelarModal'), {});

    modal.show();
}

let consultaFinalizar = (element) => {
    let id = element.getAttribute("data-id");

    let formData = new FormData();
    formData.append("id", id);

    fetch('/consulta/finalizar', {
        method: "POST",
        body: formData
    })
        .then((data) => {
            console.log(data);

            $('#tabela-consultas').DataTable().ajax.reload();

            toastr.success('Consulta finalizada com sucesso');
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível finalizar a consulta');
        })
}

let consultaIniciar = (element) => {
    let id = element.getAttribute("data-id");

    let formData = new FormData();
    formData.append("id", id);

    fetch('/consulta/iniciar', {
        method: "POST",
        body: formData
    })
        .then((data) => {
            console.log(data);

            $('#tabela-consultas').DataTable().ajax.reload();

            toastr.success('Consulta iniciada com sucesso');
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível iniciar a consulta');
        })
}

document.getElementById("botao-modal-cancelar")
    .addEventListener("click", cancelarAgendamento);