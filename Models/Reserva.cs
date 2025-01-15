namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private static int _ultimoId = 0;
        public int Id { get; set; }
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        protected Hotel Hotel { get; set; }

        public Reserva(Hotel hotel) 
        {
            Id = GerarNovoId();
            Hotel = hotel;
            Hospedes = new List<Pessoa>();  
        }

        public Reserva(Hotel hotel, int diasReservados, List<Pessoa> hospedes)
        {
            Id = GerarNovoId();
            Hotel = hotel;
            Hospedes = hospedes;
            DiasReservados = diasReservados;
        }

        private static int GerarNovoId()
        {
            return ++_ultimoId;
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

        public static Reserva CriarReserva(Hotel hotel, Suite suite)
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Nova Reserva ===");

            Console.Write("Digite a quantidade de dias para reserva: ");
            int dias = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de pessoas: ");
            int qtdPessoas = int.Parse(Console.ReadLine());

            if(qtdPessoas > suite.Capacidade)
            {
                return null;
            }

            List<Pessoa> _pessoas = new List<Pessoa>();

            for (int i = 0; i < qtdPessoas; i++)
            {
                Console.Write("Entre com o nome de cada pessoa: ");
                _pessoas.Add(new Pessoa(Console.ReadLine()));
            }

            Reserva reserva = new Reserva(hotel, dias, _pessoas);
            suite.EReservada = true;

            Console.WriteLine("Reserva feita com sucesso!");

            return reserva;
        }
    }
}