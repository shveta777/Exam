using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Exam
{
    public partial class MainWindow : Window
    {
        public readonly DeviceShop _shop = new DeviceShop();
        private int requiredCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetCountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(CountTextBox.Text, out requiredCount))
            {
                MessageTextBlock.Text = "Ошибка: введите целое число.";
                return;
            }

            if (requiredCount <= 0)
            {
                MessageTextBlock.Text = "Ошибка: количество смартфонов должно быть больше 0.";
                return;
            }

    
            SmartphonesDataGrid.ItemsSource = null;
            MessageTextBlock.Text = "Количество смартфонов задано. Теперь введите данные о них.";
        }

        private void AddSmartphoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (requiredCount <= 0)
            {
                MessageTextBlock.Text = "Сначала задайте количество смартфонов.";
                return;
            }

            
            var currentCount = _shop.GetOriginal().Count;

            if (currentCount >= requiredCount)
            {
                MessageTextBlock.Text = "Все смартфоны уже добавлены.";
                return;
            }

            string marka = MarkaTextBox.Text;
            if (string.IsNullOrWhiteSpace(marka))
            {
                MessageTextBlock.Text = "Ошибка: введите марку смартфона.";
                return;
            }

            if (!int.TryParse(PriceTextBox.Text, out int price) || price <= 0)
            {
                MessageTextBlock.Text = "Ошибка: цена должна быть целым числом больше 0.";
                return;
            }

            string model = ModelTextBox.Text;
            if (string.IsNullOrWhiteSpace(model))
            {
                MessageTextBlock.Text = "Ошибка: введите модель смартфона.";
                return;
            }

            var smartphone = new Smartphone(marka, model, price);
            _shop.AddSmartphone(smartphone);

            SmartphonesDataGrid.ItemsSource = null;
            SmartphonesDataGrid.ItemsSource = _shop.GetOriginal();

            MarkaTextBox.Clear();
            ModelTextBox.Clear();
            PriceTextBox.Clear();

            int addedCount = _shop.GetOriginal().Count;
            if (addedCount == requiredCount)
            {
                MessageTextBlock.Text = "Все смартфоны добавлены. Можно вывести исходный или отсортированный список.";
            }
            else
            {
                MessageTextBlock.Text = $"Смартфон добавлен. Добавлено {addedCount} из {requiredCount}.";
            }
        }

        private void ShowOriginalButton_Click(object sender, RoutedEventArgs e)
        {
            var original = _shop.GetOriginal();
            if (original.Count == 0)
            {
                MessageTextBlock.Text = "Сначала добавьте смартфоны.";
                return;
            }

            SmartphonesDataGrid.ItemsSource = null;
            SmartphonesDataGrid.ItemsSource = original;
            MessageTextBlock.Text = "Показан исходный список смартфонов.";
        }

        private void ShowSortedButton_Click(object sender, RoutedEventArgs e)
        {
            var sorted = _shop.GetSortedByPriceAndMarka();
            if (sorted.Count == 0)
            {
                MessageTextBlock.Text = "Сначала добавьте смартфоны.";
                return;
            }

            SmartphonesDataGrid.ItemsSource = null;
            SmartphonesDataGrid.ItemsSource = sorted;
            MessageTextBlock.Text = "Показан отсортированный список по цене и марке.";
        }
    }
}
