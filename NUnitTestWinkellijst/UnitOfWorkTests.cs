using FakeItEasy;
using NUnit.Framework;
using Winkellijst_ASP.Models;
using System.Collections.ObjectModel;
using Winkellijst_ASP.UnitOfWork;
using Winkellijst_ASP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [Test]
        public void MaakAan_NieuwProductView()
        {
            //Arrange
            ProductViewModel productViewModel;
            Afdeling afdeling = A.Fake<Afdeling>();

            //Act
            productViewModel = A.Fake<ProductViewModel>();
            productViewModel.Product = A.Fake<Product>();
            productViewModel.Afdeling = new SelectList(unitOfWork.AfdelingRepo.Ophalen(a => afdeling.AfdelingId), "AfdelingIdFake", "NaamFake");

            //Assert
            Assert.NotNull(productViewModel);

        }
        [Test]
        public void CreateWinkelLijst()
        {
            //Arrange
            WinkellijstCreateViewModel viewModel = A.Fake<WinkellijstCreateViewModel>();
            //Act
            viewModel.Winkellijst = A.Fake<WinkelLijst>();
            //Assert
            Assert.NotNull(viewModel.Winkellijst);
        }
    }
}
