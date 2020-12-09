using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Winkellijst_ASP.Controllers;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.ViewModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NUnitTestWinkellijst
{
    [TestFixture]
    public class ProductTests
    {
        private GebruikerContext _context = A.Fake<GebruikerContext>();
        private SearchProductViewModel _searchProductViewModel;
        

        [Test]
        /*public void Index()
        {
            //Arrange
            searchProductViewModel = new SearchProductViewModel();

            var task = context.Producten.Include(p => p.Afdeling).ToListAsync();
            task.Wait();
            var products = task.Result;

            //Act
            searchProductViewModel.Products = products;

            //Assert
            //Assert.NotNull(searchProductViewModel.Products);
            Assert.IsInstanceOf<List<Product>>(searchProductViewModel.Products);
        }*/

        public async void Ophalen_ReturnsObservableCollectionOfTypeProduct()
        {
            //Arrange
            ObservableCollection<Product> Producten;
            //Act
            Producten = new ObservableCollection<Product>(await _context.Producten.ToListAsync());
            //Assert
            Assert.NotNull(Producten);
           // Assert.IsInstanceOf<ObservableCollection<Product>>(Producten);
        }

        //[Test]
        //public async void Search(SearchProductViewModel searchProductViewModel)
        //{

        //    //Arange
        //    searchProductViewModel = A.Fake<SearchProductViewModel>();

        //    //Act

        //    if (!string.IsNullOrEmpty(searchProductViewModel.ZoekProducten))
        //    {
        //        searchProductViewModel.Products = await context.Producten.Include(p => p.Afdeling)
        //            .Where(c => c.Naam.Contains(searchProductViewModel.ZoekProducten)).ToListAsync();
        //    }
        //    else
        //    {
        //        searchProductViewModel.Products = await context.Producten.Include(p => p.Afdeling).ToListAsync();
        //    }

        //    //Assert
        //    Assert.NotNull(searchProductViewModel.Products);

        //}

        //public async void Details(int? id)
        //{



        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await context.Producten
        //        .Include(p => p.Afdeling)
        //        .FirstOrDefaultAsync(m => m.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }


        //}



        //Still to do
        /*

        --------------------------------
        
        ------------------------------------
        public void Create()
    {
        ProductViewModel productViewModel = new ProductViewModel();
        productViewModel.Product = new Product();
        productViewModel.Afdeling = new SelectList(_context.Afdelingen, "AfdelingId", "Naam");

    }
        -------------------------------------
         */
    }
}
