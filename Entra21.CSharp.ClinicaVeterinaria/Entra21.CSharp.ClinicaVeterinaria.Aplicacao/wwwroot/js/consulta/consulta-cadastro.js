let cadastrarConsulta = () => {
    let procedimento = document.getElementById("campo-procedimento").value;
    let valor = document.getElementById("campo-valor").value;
    let dataHoraPrevista = document.getElementById("campo-data-hora-prevista").value;
    let veterinarioId = document.getElementById("campo-veterinario").value;
    let petId = document.getElementById("campo-pet").value;

    let dados = new FormData();
    dados.append("procedimento", procedimento);
    dados.append("valor", valor);
    dados.append("dataHoraPrevista", dataHoraPrevista);
    dados.append("veterinarioId", veterinarioId);
    dados.append("petId", petId);
    console.log(dados);

    fetch('/consulta/cadastrar', {
        method: 'POST',
        body: dados
    })
        .then((data) => {
            console.log(data);

            toastr.success("Consulta agendada com sucesso");

            $('#tabela-consultas').DataTable().ajax.reload();

            bootstrap.Modal.getInstance(
                document.getElementById('exampleModal')).hide();

        })
        .catch((error) => {
            toastr.error("Não foi possível agendar a consulta");

            console.log(error);
        });
}

document.getElementById("botao-cadastrar-consulta")
    .addEventListener("click", cadastrarConsulta);