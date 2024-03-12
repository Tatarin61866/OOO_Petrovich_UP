using OOO_Petrovich.Classes;
using OOO_Petrovich.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOO_Petrovich.View
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        List<Classes.ProductOrder> listProductOrder = new List<Classes.ProductOrder>();
        public Catalog()
        {
            InitializeComponent();
            tbFullName.Text = App.fullName;
            tbRole.Text = App.userRole;
            
        
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window w in App.Current.Windows)
                w.Close();
            Close();
            App.userClear();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void cbSort_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ShowProducts();
        }

        private void ShowProducts()
        {
            //Заполнить список товаров из БД
            List<Model.product> products = new List<Model.product>();
            products = Helper.DB_OOO_PetrovichEntities.product.ToList();
            cbFilterCategory.DisplayMemberPath = "CategoryName";
            //Сортировка
            switch (cbSort.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(pr => pr.productCost).ToList();
                    break;
                case 1:
                    products = products.OrderByDescending(pr => pr.productCost).ToList();
                    break;
            }

            //Поиск по названию
            string search = tbSearch.Text;	//Введенная строка поиска
            if (search.Length > 0)			//Если она не пустая
            {
                products = products.Where(pr => pr.productName.Contains(search)).ToList();
            }
            List<Classes.ProductExtended> productExtendeds = new List<Classes.ProductExtended>();
            foreach (Model.product product in products)
            {
                Classes.ProductExtended productExtended = new Classes.ProductExtended();
                productExtended.Product = product;
                productExtendeds.Add(productExtended);
            }

            //Оторазить отфильтрованный список
            listBoxProduct.ItemsSource = productExtendeds;
        }

        private void miAddInOrder_Click(object sender, RoutedEventArgs e)
        {
            Classes.ProductExtended productSelect = listBoxProduct.SelectedItem as Classes.ProductExtended;
            //Артикул выбранного товара
            int art = productSelect.Product.idProduct;
            //Поиск товара с этим артиклем в заказе
            Classes.ProductOrder productFind = listProductOrder.Find(pr => pr.ProductExtended.Product.idProduct == art);

            if (productFind != null)			//Нашел - такой товар уже есть в заказе
            {
                productFind.countProductInOrder++;	//Увеличиваем его количество в заказе
            }
            else                  //такого товара еще не было – создаем новый товар в заказе
            {
                Classes.ProductOrder productNew = new Classes.ProductOrder();
                productNew.countProductInOrder = 1;
                productNew.ProductExtended = productSelect;
                listProductOrder.Add(productNew);
            }

        }

        private void cbFilterDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowProducts();
        }

        private void cbFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowProducts();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowProducts();
        }

        private void buttonOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            this.Hide();
            order.ShowDialog();
            this.ShowDialog();
        }
    }
}
