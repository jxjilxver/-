using System;
namespace lab3
{
    class Program
    {
        public partial class Product
        {
            private readonly int ID;//поле-только для чтения 
            public int Id
            {
                get
                {
                    return ID;
                }
            }
            private string name;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            private int UPC;
            public int Upc
            {
                get
                {
                    return UPC;
                }
            }
            public const string manufacturer = "Nvidia";//поле-константа 
            private int price;
            public int Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }
            private string term;
            public string Term
            {
                get
                {
                    return term;
                }
                set
                {
                    term = value;
                }
            }
            private int quantity;
            public int Quantity
            {
                get
                {
                    return quantity;
                }
                set
                {
                    quantity = value;
                }
            }
            public static int count = 0;//счётчик созданных объектов 
            public static void Hello()
            {
                Console.WriteLine("Вызван статический метод класса Product");
            }

            public Product()//конструктор без параметров 
            {
                count++;
                ID = 3;
                name = "GeForce GTX 1050";
                price = 145;
                UPC = base.GetHashCode();
                quantity = 200;
                term = "5 лет";
            }
            public Product(int iID, string iName, int iUPC, int iPrice, string iTerm, int iQuantity)//конструктор с параметрами
            {
                count++;
                this.ID = iID;
                this.Name = iName;
                this.UPC = base.GetHashCode();
                this.Price = iPrice;
                this.Term = iTerm;
                this.Quantity = iQuantity;
            }
            public void Info()
            {
                Console.WriteLine($"Производитель: {manufacturer}, наименование: {name}, ID: {ID}, UPC: {UPC}, срок хранения: {term}, цена: {price}$, количество: {quantity}");
            }
            public static void RefMethod(ref int refArgument)
            {
                refArgument = refArgument + 44;
            }
            public static void OutArgExample(out int number)
            {
                number = 44;
            }
            //private Product() { } //закрытый конструктор
            
            public override string ToString()
            {
                return $"Type {base.ToString()},  Производитель: {manufacturer}, наименование: {name}, ID: {ID}, UPC: {UPC}, срок хранения: {term}, цена: {price}$, количество: {quantity}"; 
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                Product prod = (Product)obj;
                return (this.name == prod.name && this.ID == prod.ID && this.UPC==prod.UPC && this.term == prod.term && this.price==prod.price && this.quantity==prod.quantity);
            }

            public override int GetHashCode()
            { // 269 или 47 простые
                int hash = 269;
                hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
                hash = (hash * 47) + ID.GetHashCode();
                return hash;
            }
        }
        public partial class Product
        {
            public void Method()
            {
                Console.WriteLine("Цена продукта: "+Price);
            }
        }

        static void Main(string[] args)
        {
            Product product1 = new Product(1,"GTX 1050",124124, 150, "5 лет", 1000);
            Product product2 = new Product(2, "GTX 1050", 2285934, 140, "5 лет", 1100);
            Product product3 = new Product();
            Product[] products = new Product[3];
            products[0] = product1;
            products[1] = product2;
            products[2] = product3;
            Console.WriteLine("Продукты с наменованием GTX 1050:");
            foreach(Product prod in products)
            {
                if(prod.Name=="GTX 1050")
                {
                    prod.Info();
                }
            }
            Console.WriteLine("Продукты, не превыщающий 150$ по стоимости:");
            foreach (Product prod in products)
            {
                if (prod.Name=="GTX 1050" && prod.Price < 150)
                {
                    prod.Info();
                }
            }
            int i=1;
            Product.RefMethod(ref i);

            int initializeInMethod;
            Product.OutArgExample(out initializeInMethod);
            Console.WriteLine("Количество созданных объектов: " + Product.count);//используется статическое поле
            Product.Hello();
        }
    }
}
