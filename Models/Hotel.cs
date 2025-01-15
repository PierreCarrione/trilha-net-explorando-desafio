using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Hotel
    {
        protected List<Suite> Suites { get; set; }
        protected List<Reserva> Reservas { get; set; }

        public Hotel() 
        {
            Suites = new List<Suite>(); 
            Reservas = new List<Reserva>(); 
        }  

        public void ShowSuitesDisponiveis()
        {
            var suitesDisponiveis = Suites.Where(s => !s.EReservada).ToList();

            Console.Clear();

            if (suitesDisponiveis.Count == 0)
            {
                Console.WriteLine("Não há suites disponíveis no momento para reserva.");
            }
            else
            {
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < suitesDisponiveis.Count; i++)
                {
                    Console.WriteLine($"Tipo de suíte: {suitesDisponiveis[i].TipoSuite}\n" +
                        $"Valor diária: {suitesDisponiveis[i].ValorDiaria}\nCapacidade: {suitesDisponiveis[i].Capacidade}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }

        public List<Reserva> GetReservas()
        {
            return Reservas;
        }

        public void ShowReservas()
        {
            Console.Clear();

            if (Reservas.Count == 0)
            {
                Console.WriteLine("Não há reservas no momento.");
            }
            else
            {
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < Reservas.Count; i++)
                {
                    Console.WriteLine($"Código da reserva: {Reservas[i].Id}\nSuíte reservada: {Reservas[i].Suite.TipoSuite}\n" +
                        $"Dias reservada: {Reservas[i].DiasReservados}\nQuantidade de hospedes: {Reservas[i].ObterQuantidadeHospedes()}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }

        public void AddSuite()
        {
            Suite suite = Suite.CriarSuite(this);
            Suites.Add(suite);
        }
        public void FazerReserva()
        {
            var suitesDisponiveis = Suites.Where(s => !s.EReservada).ToList();
            Console.Clear();

            if (suitesDisponiveis.Count == 0)
            {
                Console.WriteLine("Não há suites disponíveis no momento para reserva.");
                Thread.Sleep(2000);
            }
            else
            {
                int suite;
                Console.WriteLine("Escolha o número de uma das suítes disponíveis.");

                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < suitesDisponiveis.Count; i++)
                {
                    Console.WriteLine($"{i + 1}º\nTipo de suíte: {suitesDisponiveis[i].TipoSuite}\n" +
                        $"Valor diária: {suitesDisponiveis[i].ValorDiaria}\nCapacidade: {suitesDisponiveis[i].Capacidade}");
                }
                Console.WriteLine("-----------------------------------------");

                suite = int.Parse(Console.ReadLine());

                while (suite > suitesDisponiveis.Count)
                {
                    Console.WriteLine("Número de suíte não existente, por favor digite novamente um número correto.");
                    suite = int.Parse(Console.ReadLine());
                }

                suite = suite - 1;
                Reserva reserva = Reserva.CriarReserva(this, suitesDisponiveis[suite]);

                if (reserva == null)
                {
                    Console.WriteLine("Número de pessoas excede o máximo comportado pela suíte.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Reservas.Add(reserva);
                }
            }
        }
        public void ObterValorTotalPagar()
        {
            string id;
            Console.Clear();
            Console.WriteLine("Entre com o código da reserva que deseja ver o valor.");
            id = Console.ReadLine();

            if (Regex.IsMatch(id, @"^\d$"))
            {
                Reserva reserva = Reservas.Where(r => r.Id == int.Parse(id)).FirstOrDefault();

                if (reserva != null)
                {
                    Console.WriteLine($"Valor total a pagar: {reserva.CalcularValorDiaria()}");
                }
                else
                {
                    Console.WriteLine("Reserva não encontrada ou não existente. Por favor verifique o código e tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("O código é composto somente de números.");
            }
        }

        public void CancelarReserva()
        {
            string id;
            Console.Clear();
            Console.WriteLine("Entre com o código da reserva que deseja cancelar.");
            id = Console.ReadLine();

            if (Regex.IsMatch(id, @"^\d$"))
            {
                Reserva reserva = Reservas.Where(r => r.Id == int.Parse(id)).FirstOrDefault();

                if (reserva != null)
                {
                    var suite = reserva.Suite;
                    var index = Suites.IndexOf(suite);
                    Suites[index].EReservada = false;
                    Reservas.Remove(reserva);
                    Console.WriteLine("Reserva cancelada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Reserva não encontrada ou não existente. Por favor verifique o código e tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("O código é composto somente de números.");
            }
        }
    }
}
