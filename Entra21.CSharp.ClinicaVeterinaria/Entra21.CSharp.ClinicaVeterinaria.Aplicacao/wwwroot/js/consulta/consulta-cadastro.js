let cadastrarConsulta = () => {
    let procedimento = document.getElementById("campo-procedimento").value;
    let valor = document.getElementById("campo-valor").value;
    let dataHoraPrevista = document.getElementById("campo-data-hora-prevista").value;
    let veterinario = document.getElementById("campo-veterinario").value;
    let pet = document.getElementById("campo-pet").value;

    let dados = {
        procedimento: procedimento,
        valor: valor,
        dataHoraPrevista: dataHoraPrevista,
        veterinarioId: veterinario,
        petId: pet
    };
    console.log(dados);

    fetch('/consulta/cadastrar', {
        method: 'POST',
        body: JSON.stringify(dados)
    })
        .then((data) => {
            console.log(data);
        })

}

document.getElementById("botao-cadastrar-consulta")
    .addEventListener("click", cadastrarConsulta);