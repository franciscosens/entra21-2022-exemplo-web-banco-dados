let formatarMoeda = (valor) => `R$ ${(Math.round(valor * 100) / 100).toFixed(2)}`.replace('.', ',');