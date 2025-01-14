namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        protected Hotel Hotel { get; set; }
        public bool EReservada { get; set; }

        public Suite(Hotel hotel) 
        {
            Hotel = hotel;
        }

        public Suite(Hotel hotel, string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Hotel = hotel;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            EReservada = false; 
        }

        public static Suite CriarSuite(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Nova Su�te ===");

            Console.Write("Digite o tipo de su�te: ");
            string tipoSuite = Console.ReadLine();

            Console.Write("Digite a quantidade de camas: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da di�ria: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            Suite suite = new Suite(hotel, tipoSuite, capacidade, valorDiaria);

            Console.WriteLine("Su�te adicionada com sucesso!");

            return suite;
        }
    }
}