using Application;
using Xunit;

namespace Testai
{
    public class LiftoValdymoPultoTestai
    {
        LiftuValdymoPultas m_ValdymoPultas;

        public LiftoValdymoPultoTestai()
        {
            m_ValdymoPultas = new LiftuValdymoPultas(MockOptions.GetOptions<PastatoKofiguracija>());

            m_ValdymoPultas.Iskviesti(7);
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Iskviesti(3);
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Vaziuoti(7, 1);
            m_ValdymoPultas.Vaziuoti(3, 5);
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
            m_ValdymoPultas.Tikas();
        }

        [Fact]
        public void GautiInformacijaTestas()
        {
            var info0 = m_ValdymoPultas.GautiInformacija(0);
            var info1 = m_ValdymoPultas.GautiInformacija(1);
            Assert.Equal(2, info0.Aukstas);
            Assert.Equal("Zemyn", info0.Kryptis);
            Assert.Equal("Vaziuoja", info0.Statusas);
            Assert.Equal(5, info1.Aukstas);
            Assert.Equal("Stovi", info1.Kryptis);
            Assert.Equal("DurysAtidarytos", info1.Statusas);
        }

        [Fact]
        public void GautiLogaTestas()
        {
            var log0 = m_ValdymoPultas.GautiLoga(0);
            var log1 = m_ValdymoPultas.GautiLoga(1);
            Assert.Equal(16, log0.Ivykiai.Count);
            Assert.Equal(10, log1.Ivykiai.Count);
        }

    }
}
