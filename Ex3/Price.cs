using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Ex3
{
    class PriceTable
    {
        struct Price
        {
            string number;
            string shop;
            int? cost;

            public Price(string number, string shop, int? cost)
            {
                this.number = number;
                this.shop = shop;
                this.cost = cost;
            }

            public string Number
            {
                get
                {
                    return number;
                }
            }
            public string Shop

            {
                get
                {
                    return shop;

                }
            }
            public int? Cost
            {
                get
                {
                    return cost;
                }
            }

            public string Show()
            {
                return string.Format("Товар № {0} из магазина {1} стоит {2}", number, shop, cost);
            }
        }

        Price[] product;

        public PriceTable() //Конструктор по умолчанию
        {
            product = new Price[2]; //Объявление массива из двух элементов
            string shop;
            string number;
            int? cost;

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Введите номер товара");
                number = Console.ReadLine();

                Console.WriteLine("Введите магазин");
                shop = Console.ReadLine();

                Console.WriteLine("Введите цену");
                try //Попытка присвоить переменной price значения полученного от пользователя конвертированного в ToUInt32
                {
                    cost = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) //Обратока возможного исключения
                {
                    Console.WriteLine("Попытка записи неверного формата.");
                    Console.WriteLine(e.Message);
                    cost = null;
                }
                product[i] = new Price(number, shop, cost); //В массив добавляется новый экземпляр Prices со значениями переданными в качестве аргументов конструктору
            }
            product = product.OrderBy(products => products.Number).ToArray<Price>(); //Сортировка массива по полю Number
        }
        public string this[int index]
        {
            get
            {
                try
                {
                    return product[index].Show();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Такого нет");
                    return "";
                }
            }

        }

        public string this[string index] //Индексатор для поиска значения по указаному номеру товара
        {
            get
            {

                try
                {
                    return product[Convert.ToInt32(index) - 1].Show(); //Попытка найти товар за указаным номером
                }
                catch (Exception e)
                {
                    Console.WriteLine("Попытка обращения за пределы массива.");
                    Console.WriteLine(e.Message);
                    return string.Format("\"{0}\" нет такого товара.", index);
                }
            }
        }


    }
    
}
