using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineasITSUR
{
    public class Vuelo
    {
        private String TipoVuelo;
        private String Horallegada;
        private String HoraSalida;
        private int numeroasientos;
        private double Total;
        private String Origen;
        private String Destino;
        private String[] asientoscomprados;

        public Vuelo(string tipoVuelo, string horallegada, string horaSalida, int numeroasientos, double total, string origen, string destino, String[] asientosc)
        {
            this.TipoVuelo = tipoVuelo;
            this.Horallegada = horallegada;
            this.HoraSalida = horaSalida;
            this.numeroasientos = numeroasientos;
            this.Total = total;
            this.Origen = origen;
            this.Destino = destino;
            this.asientoscomprados = asientosc;
        }
        public Vuelo()
        {

        }
        public String[] getAsientosCompradosArreglo()
        {
            return this.asientoscomprados;
        }
        public void setAsientosComprados(String[] asientosc)
        {
            this.asientoscomprados = asientosc;

        }
        

        public String getTipoVuelo()
        {
            return this.TipoVuelo;
        }
        public void setTipoVuelo(String vuelo)
        {
            this.TipoVuelo = vuelo;

        }
        public String getHoraLlegada()
        {
            return this.Horallegada;
        }

        public void setHoraLlegada(String horallegada)
        {
            this.Horallegada = horallegada;

        }
        public String getHoraSalida()
        {
            return this.HoraSalida;
        }

        public void setHoraSalida(String horasalida)
        {
            this.HoraSalida = horasalida;

        }
        public int getNumAsientos()
        {
            return this.numeroasientos;
        }

        public void setNumAsientos(int asientos)
        {
            this.numeroasientos = asientos;

        }
        public Double getTotal()
        {
            return this.Total;
        }

        public void setTotal(double tot)
        {
            this.Total = tot;

        }
        public String getDestino()
        {
            return this.Destino;
        }

        public void setDestino(String des)
        {
            this.Destino = des;

        }

        public String getOrigen()
        {
            return this.Origen;
        }

        public void setOrigen(String orig)
        {
            this.Origen = orig;

        }

        

    }

}
