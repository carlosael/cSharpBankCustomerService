using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
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
List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
  new ContaCorrente(95, "123456-X"){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique"}},
  new ContaCorrente(95, "951258-X"){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro"}},
  new ContaCorrente(94, "987321-W"){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa"}}
};
AtendimentoCliente();
void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception excecao)
            {
                throw new ByteBankException(excecao.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverContas();
                    break;
                case '4':
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarContas();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }
    catch (ByteBankException excecao)
    {
        Console.WriteLine($"{excecao.Message}");
    }
    
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Infome nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Infome CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Infome Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);


    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     LISTA DE CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine(item.ToString());
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }

}

void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      REMOVER CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var item in _listaDeContas)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }
    if (conta != null)
    {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        Console.WriteLine(" ... Conta para remoção não encontrada ...");
    }
    Console.ReadKey();
}

void OrdenarContas()
{
    _listaDeContas.Sort();
    Console.WriteLine("... Lista de Contas ordenadas ...");
    Console.ReadKey();
}

void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("===      PESQUISAR CONTAS     ===");
    Console.WriteLine("=================================");
    Console.WriteLine("\n");
    Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2) CPF DO TITULAR? ");
    switch(int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.WriteLine("Informe o número da Conta: ");
                string _numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultarContaPorNumero(_numeroConta);
                if(consultaConta != null)
                {
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("Informe o CPF do Titular: ");
                string _cpf = Console.ReadLine();
                ContaCorrente consultaCpf = ConsultarCPFTitular(_cpf);
                if (consultaCpf != null)
                {
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
                Console.ReadKey();
                break;
            }
        default:
            Console.WriteLine("Opção não implementada");
            break;
    }
}

ContaCorrente ConsultarCPFTitular(string cpf)
{
    return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
}

ContaCorrente ConsultarContaPorNumero(string? numeroConta)
{
    return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
}