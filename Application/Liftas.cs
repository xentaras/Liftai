using Application.Enums;
using System;
using System.Collections.Generic;

namespace Application
{
    public class Liftas
    {
        int? m_VaziuojaIAuksta;
        int? m_Laukia;

        public Liftas()
        {
            Ivykiai = new List<Ivykis>();
            Kryptis = Kryptis.Stovi;
        }

        public LiftoStatusas Statusas { private set; get; }
        public int Aukstas { private set; get; }
        public Kryptis Kryptis { private set; get; }
        public List<Ivykis> Ivykiai { private set; get; }

        public void Tikas()
        {
            switch (Statusas)
            {
                case LiftoStatusas.Laisvas:
                    break;

                case LiftoStatusas.Vaziuoja:
                    if (Kryptis == Kryptis.Aukstyn)
                    {
                        Aukstas++;
                        Ivykiai.Add(new Ivykis(DateTime.Now, $"Liftas pakilo i {Aukstas} auksta."));
                    }
                    else if (Kryptis == Kryptis.Zemyn)
                    { 
                        Aukstas--;
                        Ivykiai.Add(new Ivykis(DateTime.Now, $"Liftas nusileido i {Aukstas} auksta."));
                    }

                    if (m_VaziuojaIAuksta == Aukstas)
                    {
                        Statusas = LiftoStatusas.Atvaziavo;
                        Kryptis = Kryptis.Stovi;
                    }

                    break;

                case LiftoStatusas.DurysUzdarytos:
                    if (m_VaziuojaIAuksta != null)
                        Statusas = LiftoStatusas.Vaziuoja;
                    else
                        Statusas = LiftoStatusas.Laisvas;

                    break;

                case LiftoStatusas.DurysAtsidaro:
                    Statusas = LiftoStatusas.DurysAtidarytos;
                    m_Laukia = 0;
                    Ivykiai.Add(new Ivykis(DateTime.Now, "Durys atsidare."));
                    break;

                case LiftoStatusas.DurysAtidarytos:
                    if (++m_Laukia == 100 || m_VaziuojaIAuksta != null)
                    {
                        Statusas = LiftoStatusas.DurysUzsidaro;
                        m_Laukia = null;
                    }
 
                    break;

                case LiftoStatusas.DurysUzsidaro:
                    Statusas = LiftoStatusas.DurysUzdarytos;
                    Ivykiai.Add(new Ivykis(DateTime.Now, "Durys uzsidare."));
                    break;

                case LiftoStatusas.Atvaziavo:
                    m_VaziuojaIAuksta = null;
                    Statusas = LiftoStatusas.DurysAtsidaro;
                    break;
            }
        }

        public void Iskviesti(int aukstas)
        {
            Ivykiai.Add(new Ivykis(DateTime.Now, $"Liftas iskviestas i {aukstas} auksta."));

            if (Aukstas == aukstas)
            {
                Statusas = LiftoStatusas.DurysAtsidaro;
                return;
            }

            m_VaziuojaIAuksta = aukstas;
            Statusas = LiftoStatusas.Vaziuoja;

            if (Aukstas > aukstas)
                Kryptis = Kryptis.Zemyn;
            else
                Kryptis = Kryptis.Aukstyn;    
        }

        public void Vaziuoti(int aukstas)
        {
            if (Aukstas == aukstas)
                return;

            m_VaziuojaIAuksta = aukstas;

            if (Aukstas > aukstas)
                Kryptis = Kryptis.Zemyn;
            else
                Kryptis = Kryptis.Aukstyn;

            Ivykiai.Add(new Ivykis(DateTime.Now, $"Liftas pasiustas i {aukstas} auksta."));
        }
    }
}
