using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Interaction interaction = new Interaction();

        private void ButtonEnterData_Click(object sender, RoutedEventArgs e)
        {
            //Тупо для проверки

            Phonebook phonebook = interaction.EnterData();
            PhonebookList phonebookList = new PhonebookList();
            phonebookList.Push(phonebook);
            ListBox1.Items.Add(phonebookList[0].Name);
            ListBox1.Items.Add(phonebookList[0].OwnerName);
            foreach(string subscriber in phonebookList[0].Data)
            {
                ListBox1.Items.Add(subscriber);
            }                 
        }
    }
}

