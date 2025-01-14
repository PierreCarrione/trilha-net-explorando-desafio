namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        protected Hotel Hotel { get; set; }

        public Reserva(Hotel hotel) 
        {
            Hotel = hotel;
            Hospedes = new List<Pessoa>();  
        }

        public Reserva(Hotel hotel, int diasReservados)
        {
            Hotel = hotel;
            Hospedes = new List<Pessoa>();
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (true)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = 0;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (true)
            {
                valor = 0;
            }

            return valor;
        }

        public static Reserva CriarReserva(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Nova Suíte ===");

            Console.Write("Digite o tipo de suíte: ");
            string tipoSuite = Console.ReadLine();

            Console.Write("Digite a quantidade de camas: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            Reserva reserva = new Reserva(hotel);

            Console.WriteLine("Suíte adicionada com sucesso!");

            return reserva;
        }
    }
}