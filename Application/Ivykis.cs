using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Ivykis
    {
        public DateTime Laikas { get; }
        public string Veiksmas { get; }

        public Ivykis(DateTime laikas, string veiksmas)
        {
            Laikas = laikas;
            Veiksmas = veiksmas;
        }
    }
}
