using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
//List<Pessoa> hospedes = new List<Pessoa>();

//Pessoa p1 = new Pessoa(nome: "Hóspede 1");
//Pessoa p2 = new Pessoa(nome: "Hóspede 2");

//hospedes.Add(p1);
//hospedes.Add(p2);

//// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

//// Cria uma nova reserva, passando a suíte e os hóspedes
//Reserva reserva = new Reserva(diasReservados: 5);
//reserva.CadastrarSuite(suite);
//reserva.CadastrarHospedes(hospedes);

//// Exibe a quantidade de hóspedes e o valor da diária
//Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
//Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

Hotel hotel = new Hotel();
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Suíte");
    Console.WriteLine("2 - Reservar Suíte");
    Console.WriteLine("3 - Cancelar Reserva");
    Console.WriteLine("4 - Obter valor a pagar");
    Console.WriteLine("5 - Listar Reservas ativas");
    Console.WriteLine("6 - Listar Suítes Disponíveis");
    Console.WriteLine("7 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            hotel.AddSuite();
            break;

        case "2":
            hotel.FazerReserva();
            break;

        case "3":
            hotel.CancelarReserva();
            Thread.Sleep(2000);
            break;

        case "4":
            hotel.ObterValorTotalPagar();
            Thread.Sleep(2000);
            break;

        case "5":
            hotel.ShowReservas();
            Thread.Sleep(3000);
            break;

        case "6":
            hotel.ShowSuitesDisponiveis();
            Thread.Sleep(3000);
            break;

        case "7":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    //Console.WriteLine("Pressione uma tecla para continuar");
    //Console.ReadLine();
}