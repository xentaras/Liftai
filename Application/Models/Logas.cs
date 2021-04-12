using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Logas
    {
        public int LiftoNumeris { get; set; }
        public List<Ivykis> Ivykiai { get; set; }

        public Logas(int liftoNumeris, List<Ivykis> ivykiai)
        {
            LiftoNumeris = liftoNumeris;
            Ivykiai = ivykiai;
        }
    }
}
