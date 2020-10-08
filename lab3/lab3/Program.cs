﻿using System;

namespace lab3
{
    class Program
    {
        public class Product
        {
            public readonly int ID;//поле-только для чтения 
            public string name;
            public int UPC;
            public const string manufacturer="Nvidia";//поле-константа 
            public int price;
            public string term;
            public int quantity;
            public Product()//конструктор без параметров 
            {
                ID = 1;
                name = "GeForce GTX 1050";

            }
            public Product(int iID, string iName, int iUPC, int iPrice, string iTerm, int iQuantity)//конструктор с параметрами
            {
                this.ID = iID;
                this.name = iName;
                this.UPC = iUPC;
                this.price = iPrice;
                this.term = iTerm;
                this.quantity = iQuantity;
            }
            public void Info()
            {
                Console.WriteLine($"Производитель: {manufacturer}, наименование: {name}, ID: {ID}, UPC: {UPC}, срок хранения: {term}, цена: {price}$, количество: {quantity}");
            }
        }
        static void Main(string[] args)
        {
            Product product1 = new Product(1,"GTX 1050",124124, 150, "5 лет", 1000);
            Product product2 = new Product(2, "GTX 1050", 2285934, 140, "5 лет", 1100);
            Product product3 = new Product();
            Product[] products = new Product[5];
            products[0] = product1;
            products[1] = product2;

        }
    }
}
