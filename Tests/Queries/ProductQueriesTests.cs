using Domain.Entities;
using Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private IList<Product> _products;

        public ProductQueriesTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto 1", 10, true));
            _products.Add(new Product("Produto 2", 20, true));
            _products.Add(new Product("Produto 3", 30, true));
            _products.Add(new Product("Produto 4", 40, false));
            _products.Add(new Product("Produto 5", 50, false));
        }

        [TestMethod]
        [TestCategory("Domain/Queries/ProductQuery")]
        public void Consulta_de_produtos_ativos_deve_retornar_3()
        {
            IQueryable<Product> result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Domain/Queries/ProductQuery")]
        public void Consulta_de_produtos_inativos_deve_retornar_2()
        {
            IQueryable<Product> result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
