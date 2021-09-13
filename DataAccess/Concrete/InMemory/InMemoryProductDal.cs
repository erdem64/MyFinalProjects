using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server,Postgres,MongoDb
            _products = new List<Product> {
            new Product{ProductId=1,CateagoryId=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=2,CateagoryId=1,ProductName="Kamera",UnitPrice=500,UnitInStock=3},
            new Product{ProductId=3,CateagoryId=2,ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
            new Product{ProductId=4,CateagoryId=2,ProductName="Klavye",UnitPrice=150,UnitInStock=65},
            new Product{ProductId=5,CateagoryId=2,ProductName="Fare",UnitPrice=85,UnitInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LING - Language Integrated Query
            //Lambda(p =>)
            Product productToDelete = _products.SingleOrDefault(p =>p.ProductId == product.ProductId);

            _products.Remove(product);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sini sahip olan ürün olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CateagoryId = product.CateagoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CateagoryId == categoryId).ToList();
        }

    }
}
