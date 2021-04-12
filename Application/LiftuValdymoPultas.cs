using Application.Enums;
using Application.Interfaces;
using Application.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class LiftuValdymoPultas : ILiftuValdymoPultas
    {
        List<Liftas> m_Liftai;
        int m_MaxAukstu;

        public LiftuValdymoPultas(IOptions<PastatoKofiguracija> options)
        {
            m_MaxAukstu = options.Value.Aukstai;
            m_Liftai = new List<Liftas>();

            for(var i = 0; i < options.Value.Liftai; i++)
            {
                m_Liftai.Add(new Liftas());
            }
        }

        public bool Iskviesti(int aukstas)
        {
            if (aukstas > m_MaxAukstu)
                throw new Exception("Nera tiek aukstu.");

            var laisviLiftai = m_Liftai.Where(i => i.Statusas == LiftoStatusas.Laisvas);

            if (!laisviLiftai.Any())
                throw new Exception("Nera laisvu liftu.");

            var arciausiasLiftas = laisviLiftai.First();
            var atstumas = Math.Abs(aukstas - arciausiasLiftas.Aukstas);
            
            foreach(var liftas in laisviLiftai)
            {
                var a = Math.Abs(aukstas - liftas.Aukstas);
                
                if (a < atstumas)
                {
                    arciausiasLiftas = liftas;
                    atstumas = a;
                }
            }

            arciausiasLiftas.Iskviesti(aukstas);
            return true;
        }

        public bool Vaziuoti(int pradinisAukstas, int galinisAukstas)
        {
            if (pradinisAukstas > m_MaxAukstu || galinisAukstas > m_MaxAukstu)
                throw new Exception("Nera tiek aukstu.");

            var laukiantysLiftai = m_Liftai.Where(i => i.Aukstas == pradinisAukstas && i.Statusas == LiftoStatusas.DurysAtidarytos);

            if (!laukiantysLiftai.Any())
                throw new Exception("Nera atvaziavusio lifto.");

            laukiantysLiftai.First().Vaziuoti(galinisAukstas);
            return true;
        }

        public LiftoInformacija GautiInformacija(int liftoNumeris)
        {
            if (liftoNumeris > m_Liftai.Count() - 1)
                throw new Exception("Tokio lifto nera.");
            return new LiftoInformacija(m_Liftai[liftoNumeris].Aukstas, m_Liftai[liftoNumeris].Statusas, m_Liftai[liftoNumeris].Kryptis);
        }

        public Logas GautiLoga(int liftoNumeris)
        {
            if (liftoNumeris > m_Liftai.Count() - 1)
                throw new Exception("Tokio lifto nera.");
            return new Logas(liftoNumeris, m_Liftai[liftoNumeris].Ivykiai);
        }

        public void Tikas()
        {
            m_Liftai.ForEach(i => i.Tikas());
        }
    }
}
