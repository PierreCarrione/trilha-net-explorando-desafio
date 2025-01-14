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

        public List<Suite> GetSuitesDisponiveis()
        {
            var suitesDisponiveis = Suites.Where(s => !s.EReservada).ToList();

            return suitesDisponiveis;
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
            Reserva reserva = Reserva.CriarReserva(this);
            Reservas.Add(reserva);
        }
        public void CancelarReserva()
        {
            //Metodo dessa classe
        }
    }
}
