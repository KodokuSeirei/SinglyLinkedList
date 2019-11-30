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

namespace SinglyLinkedList
{
    /// <summary>
    /// Логика взаимодействия для AddSubscriberWindow.xaml
    /// </summary>
    public partial class AddSubscriberWindow : Window
    {
        public AddSubscriberWindow()
        {
            InitializeComponent();
        }
        Subscriber _subscriber;
       public Subscriber Subscriber { get { return _subscriber; } set { value = _subscriber; } }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            _subscriber = new Subscriber(TextPhoneNumber.Text, TextType.Text, TextName.Text, TextAdress.Text, TextRate.Text);
            DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
