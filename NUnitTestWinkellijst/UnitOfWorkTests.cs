using FakeItEasy;
using NUnit.Framework;
using Winkellijst_ASP.Models;
using System.Collections.ObjectModel;
using Winkellijst_ASP.UnitOfWork;

namespace NUnitTestWinkellijst
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]

        public void Ophalen_ReturnsObservableCollectionOfTypeProduct()
        {
            //Arrange
            ObservableCollection<Product> Producten;
            //Act
            Producten = new ObservableCollection<Product>(unitOfWork.ProductRepo.Ophalen(x => x.Afdeling));
            //Assert
            Assert.NotNull(Producten);
            Assert.IsInstanceOf<ObservableCollection<Product>>(Producten);
        }

        [Test]
        public void ZoekOpPK_Returns1Reeks()
        {
            //Arrange
            Product product = A.Fake<Product>();

            //Act
            product = unitOfWork.ProductRepo.ZoekOpPK(product.ProductId);

            //Assert
            Assert.NotNull(product);
            Assert.IsInstanceOf<Product>(product);
            A.CallTo(() => unitOfWork.ProductRepo.ZoekOpPK(product.ProductId)).MustHaveHappened();
        }
    }
}
