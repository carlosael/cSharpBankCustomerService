using bytebank.Modelos.ADM.Funcionarios;
using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_ATENDIMENTO.byteBank_Atendimento;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Arrays em C#
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
#endregion

new ByteBankAtendimento().AtendimentoCliente();

public class Estagiario : Funcionario
{
    public Estagiario(double salario, string cpf) : base(salario, cpf)
    {
    }

    public override void AumentarSalario()
    {
        throw new NotImplementedException();
    }

    protected override double getBonificacao()
    {
        throw new NotImplementedException();
    }
}
