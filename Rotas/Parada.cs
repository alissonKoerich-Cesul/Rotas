using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotas
{
    public class Parada
    {

        public string Nome { get; set; }
        public TimeSpan HorarioSaida { get; private set; }
        public TimeSpan HorarioChegada { get; private set; }

        public Parada(string nome, TimeSpan horarioSaida, TimeSpan horarioChegada)
        {
            this.Nome = nome;
            HorarioSaida = horarioSaida;
            HorarioChegada = horarioChegada;
        }


    }
}
