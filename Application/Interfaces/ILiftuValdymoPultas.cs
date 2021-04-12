using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ILiftuValdymoPultas
    {
        public bool Iskviesti(int aukstas);

        public bool Vaziuoti(int pradinisAukstas, int galinisAukstas);

        public void Tikas();

        public LiftoInformacija GautiInformacija(int liftoNumeris);

        public Logas GautiLoga(int liftoNumeris);
    }
}
