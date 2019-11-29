using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
                
            }
                phonebook = interaction.EnterData();
                phonebookList.Push(phonebook);
            
        }

        private void ButtonEnterData1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListBox1.Items.Add(phonebookList[0].Name);
                ListBox1.Items.Add(phonebookList[0].OwnerName);

                txt1.Text += phonebookList[0].Data.Length;
            
                SubscribersGrid.DataContext = subscribers;

                for (int i = 0; i < phonebookList[0].Data.GetLength(0); i++)
                {
                    subscribers.Add(
                    new Subscriber(phonebookList[0].Data[i, 0], phonebookList[0].Data[i, 1], phonebookList[0].Data[i, 2], phonebookList[0].Data[i, 3], phonebookList[0].Data[i, 4])
                    );

                }
            }




            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

           
        

        
        }

        private void ButtonClearData_Click(object sender, RoutedEventArgs e)
        {
            


        }
    }
}

    

    
          
           
           
     

        
        
   


