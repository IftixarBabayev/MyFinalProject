﻿using DataAccess.Abstract;
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
            _products = new List<Product> {
               new Product{ProductId=1,CategotyId=1,ProductName="Bardaq",UnitPrice=15,UnitsInStock=15},
               new Product{ProductId=2,CategotyId=1,ProductName="Camera",UnitPrice=500,UnitsInStock=3},
               new Product{ProductId=3,CategotyId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
               new Product{ProductId=4,CategotyId=2,ProductName="Klavyatura",UnitPrice=150,UnitsInStock=65},
               new Product{ProductId=5,CategotyId=2,ProductName="Mause",UnitPrice=85,UnitsInStock=1}
            }; 
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            _products.Remove(productToDelete);
            
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategotyId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategotyId = product.CategotyId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
