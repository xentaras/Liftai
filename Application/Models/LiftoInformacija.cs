using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LiftoInformacija
    {
        public int Aukstas { get; }
        public string Statusas { get; }
        public string Kryptis { get; }

        public LiftoInformacija(int aukstas, LiftoStatusas statusas, Kryptis kryptis)
        {
            Aukstas = aukstas;
            Statusas = statusas.ToString();
            Kryptis = kryptis.ToString();
        }
    }
}
