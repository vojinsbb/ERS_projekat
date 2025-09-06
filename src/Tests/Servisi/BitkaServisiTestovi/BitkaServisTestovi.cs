using Domain.Modeli;
using Domain.Repozitorijumi.MapeRepozitorijum;
using Domain.Repozitorijumi.ProdavniceRepozitorijum;
using Domain.Repozitorijumi.TestMapeSaPodacimaRepozitorijum;
using Domain.Servisi;
using Moq;
using Domain.Enumeracije;
using NUnit.Framework;
using Services.BitkaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Servisi.BitkaServisiTestovi
{
    [TestFixture]
    public class BitkaServisTestovi
    {
        private IBitkaServis bitkaServis;
        private Mock<IVremeServis> vremeServis;
        private Mock<INapadServis> napadServis;
        private Mock<IKupovinaServis> kupovinaServis;
        

        public BitkaServisTestovi()
        {
            vremeServis = new Mock<IVremeServis>();
            napadServis = new Mock<INapadServis>();
            kupovinaServis = new Mock<IKupovinaServis>();
            bitkaServis = new BitkaServis(vremeServis.Object, napadServis.Object, kupovinaServis.Object);
        }
        [SetUp]

        public void Setup()
        {
            vremeServis = new Mock<IVremeServis>();
            napadServis = new Mock<INapadServis>();
            kupovinaServis = new Mock<IKupovinaServis>();
            bitkaServis = new BitkaServis(vremeServis.Object, napadServis.Object, kupovinaServis.Object);

            vremeServis.Setup(v => v.Vreme(It.IsAny<int>())).Verifiable();
            napadServis.Setup(n => n.Napad(It.IsAny<Heroj>(), It.IsAny<Entitet>())).Verifiable();
            kupovinaServis.Setup(k => k.Kupi(It.IsAny<Heroj>(), It.IsAny<Predmet>())).Verifiable();
        }

        [Test]
        [TestCaseSource(typeof(TestMapeSaPodacimaRepozitorijum), nameof(TestMapeSaPodacimaRepozitorijum.StaticSpisakTestMapa))]
        public void Bitka_inicijalizovaniPodaci(Mapa m)
        {
            bool ishodBitke = bitkaServis.Bitka(m);

            Assert.That(ishodBitke, Is.True);
        }

        [Test]
        [TestCase(null)]
        public void Bitka_neinicijalizovaniPodaci(Mapa m)
        {
            bool ishodBitke = bitkaServis.Bitka(m);

            Assert.That(ishodBitke, Is.False);
        }

    }

}
