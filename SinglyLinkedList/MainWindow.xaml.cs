using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
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
using Gu.Wpf.DataGrid2D;
using Microsoft.Win32;

namespace SinglyLinkedList
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
        ObservableCollection<Subscriber> subscribers=new ObservableCollection<Subscriber>();
        PhonebookList phonebookList = new PhonebookList();
        Phonebook phonebook;
       
        private void ButtonEnterData_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookList.Length > 0)
            {
                MessageBox.Show(@"Вы уже работаете с одним документом, нажмите кнопку ""Очистить всё"" для начала работы с новым документом");
            }
            else
            {
                phonebook = interaction.EnterData();
                phonebookList.Push(phonebook);
            }
        }

        private void ButtonEnterData1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subscribers.Count > 0)
                {
                    MessageBox.Show(@"Данные уже были отображены, нажмите кнопку ""Очистить таблицу"", затем снова ""Отобразить"" для повторного отображения данных");
                }
                else
                {
                    ListBox1.Items.Add(phonebookList[0].Name);
                    ListBox1.Items.Add(phonebookList[0].OwnerName);
                    txt1.Text += phonebookList[0].Data.Length;
                    SubscribersGrid.DataContext = subscribers;

                    for (int i = 1; i < phonebookList[0].Data.GetLength(0); i++)
                    {
                        subscribers.Add(
                        new Subscriber(phonebookList[0].Data[i, 0], phonebookList[0].Data[i, 1], phonebookList[0].Data[i, 2], phonebookList[0].Data[i, 3], phonebookList[0].Data[i, 4])
                        );
                    }
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ButtonClearData_Click(object sender, RoutedEventArgs e)
        {
            phonebookList = null;
            phonebookList = new PhonebookList();
            subscribers.Clear();
        }

        private void ButtonAddSubscriber_Click(object sender, RoutedEventArgs e)
        {
            AddSubscriberWindow addSubscriberWindow = new AddSubscriberWindow();
            addSubscriberWindow.Owner = this;
          
            if (addSubscriberWindow.ShowDialog() == true)
                subscribers.Add(addSubscriberWindow.Subscriber);
            

        }

        private void ButtonDeleteSubscriber_Click(object sender, RoutedEventArgs e)
        {
            int i = SubscribersGrid.SelectedIndex;
            subscribers.RemoveAt(i);
        }

        private void ButtonClearTable_Click(object sender, RoutedEventArgs e)
        {
            subscribers.Clear();
        }

        private void ButtonSaveData_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < subscribers.Count; i++)
            {
                phonebookList[0].Data[i, 0] = subscribers[i].НомерТелефона;
                phonebookList[0].Data[i, 1] = subscribers[i].Тип;
                phonebookList[0].Data[i, 2] = subscribers[i].Имя;
                phonebookList[0].Data[i, 3] = subscribers[i].Адрес;
                phonebookList[0].Data[i, 4] = subscribers[i].Тариф;
            }
            interaction.SaveData(phonebookList);
        }
    }
}

    

    
          
           
           
     

        
        
   


