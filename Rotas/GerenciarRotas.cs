using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotas
{
    public class GerenciarRotas
    {
        public List<Rota>Rotas {  get; set; }

        public GerenciarRotas() { 
        
            Rotas = new List<Rota>();
        }
        public void AdicionarRota(int numero , string nome)
        {
            if (Rotas.Any(r => r.Numero == numero))
            {
                throw new InvalidOperationException("Rota com o mesmo número já existe.");
            }

            Rotas.Add(new Rota(numero, nome));
        }



        public void RemoverRota(int numero)
        {
            var rota = Rotas.FirstOrDefault(r => r.Numero == numero);
            if (rota == null)
            {
                throw new KeyNotFoundException("Rota não encontrada.");
            }

            Rotas.Remove(rota);
        }



        public Rota BuscarRota(int numero)
        {
            var rota = Rotas.FirstOrDefault(r => r.Numero == numero);
            if (rota == null)
            {
                throw new KeyNotFoundException($"Rota com o número {numero} não encontrada.");
            }
            return rota;
        }


        public List<Rota> ListarRotas()
        {
            return Rotas;
        }

        public bool VerificarConflitos()
        {
            foreach (var rota in Rotas)
            {
                foreach (var outraRota in Rotas)
                {
                    if (rota.Numero != outraRota.Numero)
                    {
                        foreach (var parada in rota.Paradas)
                        {
                            foreach (var outraParada in outraRota.Paradas)
                            {
                                if (parada.Nome == outraParada.Nome &&
                                    parada.HorarioChegada == outraParada.HorarioChegada)
                                {
                                    return true; // Conflito de horários
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
