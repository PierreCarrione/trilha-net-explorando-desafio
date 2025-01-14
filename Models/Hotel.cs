using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Hotel
    {
        public List<Suite> Suites { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Hotel() { }  
    }
}
