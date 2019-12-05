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
            //Используем наш ObservableCollection в качестве контекста данных для таблицы
            SubscribersGrid.DataContext = subscribers;
            //Подписываем событие при закрытии формы
            Closing += MainWindow_Closing;
           
        }
        //Создаем объект,класса с помощью которого мы сохраняем или октрываем файл
        Interaction interaction = new Interaction();
        //Создаем коллекцию данных для отображение абонентов dataGrid
        ObservableCollection<Subscriber> subscribers = new ObservableCollection<Subscriber>();
        PhonebookList phonebookList=new PhonebookList();
        Phonebook phonebook;
        MessageBoxResult result;

        //Метод что мы вызовем перед закрытием формы
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Проверяем есть ли данные
            if (subscribers.Count > 0)
            {
                //Нужно сохранить данные? Если отвечаем согласием, то сохраняем 
                result = MessageBox.Show("Вы хотите сохранить данные перед выходом?", "Выход из приложения", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    ButtonSaveData_Click(sender, null);

            }
        }

        //Событие нажатие на кнопку "Выбрать файл"        
        private void ButtonEnterData_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                //Проверка если открыть 2-ой файл
                if (phonebookList.Length > 0)
                {
                    MessageBox.Show(@"Вы уже работаете с одним документом, нажмите кнопку ""Очистить всё"" для начала работы с новым документом");
                }
                else
                {
                    //Заполняем нашу структуру данными из файла             
                    phonebook = interaction.EnterData();
                    //Дабавляем заполненную структуру в список
                    phonebookList.Push(phonebook);                    
                     
                    //Заполняем поля для имён
                    TxtOwnerName.Text = phonebookList[0].OwnerName;
                    TxtPhonebookName.Text = phonebookList[0].Name;
                        //Добавляем в список для отображения в таблице
                    for (int i = 1; i < phonebookList[0].Data.GetLength(0); i++)
                        {
                            subscribers.Add(
                            new Subscriber(phonebookList[0].Data[i, 0], phonebookList[0].Data[i, 1], phonebookList[0].Data[i, 2], phonebookList[0].Data[i, 3], phonebookList[0].Data[i, 4])
                            );
                        }

                    }
                }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
       
        
        //Событие нажатие на кнопку "Удалить все данные"
        private void ButtonClearData_Click(object sender, RoutedEventArgs e)
        {
            //Присваеваем phonebookList значение null
            phonebookList = null;
            //Создаем новый phonebookList
            phonebookList = new PhonebookList();
            //Удаляем имена из текстбоксов
            TxtOwnerName.Text = "";
            TxtPhonebookName.Text = "";
            //Очищаем список абонетов
            subscribers.Clear();
        }
        //Событие нажатие на кнопку "Добавить абонента"
        private void ButtonAddSubscriber_Click(object sender, RoutedEventArgs e)
        {
            //Создаем объект окна нового абонента
            AddSubscriberWindow addSubscriberWindow = new AddSubscriberWindow();
            //Присваиваем в качестве владельца текущее окно
            addSubscriberWindow.Owner = this;
            //Открываем окно добавления абонента в качестве диалогового окна, и если оно вернет тру то добавим его свойство Subscriber 
            //в качестве элемента коллекции ObservableCollection, которая отображает данные в таблицу
            if (addSubscriberWindow.ShowDialog() == true)
                subscribers.Add(addSubscriberWindow.Subscriber);
            

        }
        //Событие нажатие на кнопку "Уничтожить абонента"
        private void ButtonDeleteSubscriber_Click(object sender, RoutedEventArgs e)
        { 
            //Удаляем абонента по индексу выделенной строки
            int i = SubscribersGrid.SelectedIndex;
            subscribers.RemoveAt(i);
        }
        //Событие нажатие на кнопку "Очистить таблицу"
     

        private void ButtonSaveData_Click(object sender, RoutedEventArgs e)
        { 
            try
            {                         
                //Вызываем метод сохранение и передаем ему данные из программы через параметры
                interaction.SaveData(subscribers,TxtOwnerName.Text,TxtOwnerName.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

    

    
          
           
           
     

        
        
   


