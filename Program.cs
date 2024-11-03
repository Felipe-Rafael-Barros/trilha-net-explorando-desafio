using System;
using System.Text;
using DesafioProjetoHospedagem.Models;
using System.Collections.Generic;

Console.OutputEncoding = Encoding.UTF8;

// Função para cadastrar hóspedes
List<Pessoa> CadastrarHospedes()
{
    List<Pessoa> hospedes = new List<Pessoa>();

    Console.WriteLine("Digite o número de hóspedes:");
    int numeroHospedes = int.Parse(Console.ReadLine());

    for (int i = 1; i <= numeroHospedes; i++)
    {
        Console.WriteLine($"Digite o nome do hóspede {i}:");
        string nome = Console.ReadLine();
        hospedes.Add(new Pessoa(nome: nome));
    }

    return hospedes;
}

// Função para cadastrar uma suíte
Suite CadastrarSuite()
{
    Console.WriteLine("Digite o tipo de suíte:");
    string tipoSuite = Console.ReadLine();

    Console.WriteLine("Digite a capacidade da suíte:");
    int capacidade = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor da diária da suíte:");
    decimal valorDiaria = decimal.Parse(Console.ReadLine());

    return new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);
}

// Função para cadastrar uma reserva
Reserva CadastrarReserva(List<Pessoa> hospedes, Suite suite)
{
    Console.WriteLine("Digite o número de dias reservados:");
    int diasReservados = int.Parse(Console.ReadLine());

    Reserva reserva = new Reserva(diasReservados: diasReservados);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    return reserva;
}

// Função para avaliar uma reserva
void AvaliarReserva(Reserva reserva)
{
    Console.WriteLine("Digite sua avaliação para a reserva (de 1 a 5):");
    int avaliacao = int.Parse(Console.ReadLine());
    
    // Aqui você pode implementar lógica para salvar a avaliação
    // Exemplo: reserva.Avaliacao = avaliacao;

    Console.WriteLine($"Avaliação registrada: {avaliacao} estrelas");
}

// Lista para armazenar todas as reservas
List<Reserva> reservas = new List<Reserva>();

// Execução do programa
bool continuar = true;

while (continuar)
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Cadastrar nova reserva");
    Console.WriteLine("2 - Listar reservas");
    Console.WriteLine("3 - Avaliar uma reserva");
    Console.WriteLine("4 - Sair");
    
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            List<Pessoa> hospedes = CadastrarHospedes();
            Suite suite = CadastrarSuite();
            Reserva novaReserva = CadastrarReserva(hospedes, suite);
            reservas.Add(novaReserva);
            Console.WriteLine("Reserva cadastrada com sucesso!");
            break;

        case 2:
            Console.WriteLine("Reservas cadastradas:");
            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine($"Reserva {i + 1}:");
                Console.WriteLine($" - Hóspedes: {reservas[i].ObterQuantidadeHospedes()}");
                Console.WriteLine($" - Valor diária: {reservas[i].CalcularValorDiaria()}");
                Console.WriteLine();
            }
            break;

        case 3:
            Console.WriteLine("Escolha o número da reserva que deseja avaliar:");
            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine($"Reserva {i + 1}");
            }

            int indiceReserva = int.Parse(Console.ReadLine()) - 1;

            if (indiceReserva >= 0 && indiceReserva < reservas.Count)
            {
                AvaliarReserva(reservas[indiceReserva]);
            }
            else
            {
                Console.WriteLine("Número de reserva inválido.");
            }
            break;

        case 4:
            continuar = false;
            Console.WriteLine("Encerrando o sistema.");
            break;

        default:
            Console.WriteLine("Opção inválida, tente novamente.");
            break;
    }
}
