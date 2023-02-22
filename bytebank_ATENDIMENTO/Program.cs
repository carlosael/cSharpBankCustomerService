using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");


void ArrayContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "333222-a"));
    listaDeContas.Adicionar(new ContaCorrente(874, "232323-b"));
    listaDeContas.Adicionar(new ContaCorrente(874, "434343-c"));
    listaDeContas.Adicionar(new ContaCorrente(874, "434343-f"));
    listaDeContas.Adicionar(new ContaCorrente(874, "434343-d"));
    listaDeContas.Adicionar(new ContaCorrente(874, "434343-s"));
    var contaDoAndre = new ContaCorrente(898, "433344-g");
    //listaDeContas.Adicionar(contaDoAndre);
    //listaDeContas.ExibirLista();
    //Console.WriteLine("==================");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibirLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

ArrayContasCorrentes();