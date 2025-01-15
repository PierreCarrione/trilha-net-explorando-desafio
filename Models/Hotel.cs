using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //public void GetReserva(Reserva reserva)
        //{
        //    var _reserva = Reservas.Contains(reserva);
        //}

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
        public void CancelarReserva()
        {
            //Metodo dessa classe
        }
    }
}
