using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Liftai.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiftuValdiklis : ControllerBase
    {
        ILiftuValdymoPultas m_ValdymoPultas;
        public LiftuValdiklis(ILiftuValdymoPultas valdymoPultas)
        {
            m_ValdymoPultas = valdymoPultas;
        }

        [HttpPost("iskviesti")]
        public void IskviestiLifta(int aukstas) => m_ValdymoPultas.Iskviesti(aukstas);

        [HttpPost("vaziuoti")]
        public void Vaziuoti(int pradinisAukstas, int galinisAukstas) => m_ValdymoPultas.Vaziuoti(pradinisAukstas, galinisAukstas);

        [HttpGet("liftoinformacija")]
        public LiftoInformacija GautiLiftoInformacija(int liftoNumeris) => m_ValdymoPultas.GautiInformacija(liftoNumeris);

        [HttpGet("logas")]
        public Logas GautiLoga(int liftoNumeris) => m_ValdymoPultas.GautiLoga(liftoNumeris);
    }
}
