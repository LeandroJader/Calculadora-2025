namespace Calculadora.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string opcao = ExibirMenu();

            if (OpcaoSairFoiEscolhida(opcao))
                break;

            else if (OpcaoTabuadaFoiEscolhida(opcao))
                ExibirTabuada();

            else if (OpcaoHistoricoFoiEscolhida(opcao))
                ExibirHistoricoOperacoes();

            else
                ExibirResultado(RealizarCalculo(opcao));
        }
    }

    static string ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Calculadora Tabajara 2025");
        Console.WriteLine("--------------------------------");

        Console.WriteLine("1 - Somar");
        Console.WriteLine("2 - Subtrair");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");
        Console.WriteLine("5 - Tabuada");
        Console.WriteLine("6 - Histórico de Operações");
        Console.WriteLine("S - Sair");

        Console.WriteLine();
        Console.Write("Escolha uma opção: ");

        string opcao = Console.ReadLine()!.ToUpper();

        return opcao;
    }

    static bool OpcaoSairFoiEscolhida(string opcao)
    {
        bool opcaoSairFoiEscolhida = opcao == "S";

        return opcaoSairFoiEscolhida;
    }

    static bool OpcaoTabuadaFoiEscolhida(string opcao)
    {
        bool opcaoTabuadaFoiEscolhida = opcao == "5";

        return opcaoTabuadaFoiEscolhida;
    }

    static bool OpcaoHistoricoFoiEscolhida(string opcao)
    {
        bool opcaoHistoricoFoiEscolhida = opcao == "6";

        return opcaoHistoricoFoiEscolhida;
    }

    static void ExibirTabuada()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Tabuada");
        Console.WriteLine("--------------------------------");

        Console.Write("Digite o número: ");
        int numeroTabuada = Convert.ToInt32(Console.ReadLine());

        string[] linhasTabuada = Calculadora.GerarTabuada(numeroTabuada);

        for (int contador = 0; contador < linhasTabuada.Length; contador++)
            Console.WriteLine(linhasTabuada[contador]);

        Console.WriteLine("--------------------------------");
        Console.Write("Aperte ENTER para continuar");
        Console.ReadLine();
    }

    static void ExibirHistoricoOperacoes()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Histórico de Operações");
        Console.WriteLine("--------------------------------");

        string[] historicoOperacoes = Calculadora.ObterHistoricoDeOperacoes();

        for (int contador = 0; contador < historicoOperacoes.Length; contador++)
        {
            string valorAtual = historicoOperacoes[contador];

            if (valorAtual != null)
                Console.WriteLine(valorAtual);
        }

        Console.WriteLine("--------------------------------");
        Console.Write("Aperte ENTER para continuar");
        Console.ReadLine();
    }

    static decimal RealizarCalculo(string operacao)
    {
        Console.Write("Digite o primeiro número: ");
        decimal primeiroNumero = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite o segundo número: ");
        decimal segundoNumero = Convert.ToDecimal(Console.ReadLine());

        decimal resultado = 0;

        if (operacao == "1")
            resultado = Calculadora.Somar(primeiroNumero, segundoNumero);

        else if (operacao == "2")
            resultado = Calculadora.Subtrair(primeiroNumero, segundoNumero);

        else if (operacao == "3")
            resultado = Calculadora.Multiplicar(primeiroNumero, segundoNumero);

        else if (operacao == "4")
        {
            while (segundoNumero == 0)
            {
                Console.Write("Não é possível dividir por 0\n Digite o segundo número novamente -> ");

                segundoNumero = Convert.ToDecimal(Console.ReadLine());
            }

            resultado = Calculadora.Dividir(primeiroNumero, segundoNumero);
        }

        return resultado;
    }

    static void ExibirResultado(decimal resultado)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Resultado: " + resultado.ToString("F2"));
        Console.WriteLine("--------------------------------");

        Console.ReadLine();
    }
}
