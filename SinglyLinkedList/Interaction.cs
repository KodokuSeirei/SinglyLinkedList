using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SinglyLinkedList
{
    class Interaction
    {
        string[] line;
        string[,] subscribers;
       public Phonebook EnterData()
        {
            //Узнаем путь к файлу
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Фильтр отображаемых файлов
            openFileDialog.Filter = "text files(*.txt; *.csv)| *.txt; *.csv|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
           
            Phonebook phonebook = new Phonebook();
            //Создаем поток чтения файла 
            using (StreamReader readfile = new StreamReader(openFileDialog.FileName))
            {
                //Записываем строки в массив
                string[] allLines = readfile.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //Массив для абонентов
                subscribers = new string[allLines.Length-1, 5];
                //Заполняем данными
                for (int i = 0; i < allLines.Length; i++)
                {
                    line = allLines[i].Split(';');
                    if (i != allLines.Length-1)
                    {
                        for (int j = 0; j < line.Length; j++)
                        {
                            subscribers[i, j] = line[j];
                        }                     
                    }
                    else
                    {
                        phonebook.OwnerName = line[0];
                        phonebook.Name = line[1];
                    }
                }
                phonebook.Data = subscribers;
            }
            return phonebook;

        }
        public void SaveData(ObservableCollection<Subscriber> subscribers, string ownerName, string phonebookName)
        {
            //Узнаем путь сохранения
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Фильтр отображаемых файлов
            saveFileDialog.Filter = "text files(*.txt; *.csv)| *.txt; *.csv|All files (*.*)|*.*";
            saveFileDialog.ShowDialog();
            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
                //Создадим переменную с именами колонок              
                string allText = "Telephone number;Type of subscriber (company / individual);Subscriber (name / full name);Adress;Rate\n";
                for (int i = 0; i < subscribers.Count; i++)
                {
                    // Заполняем переменную данными из ObservableCollection
                    allText += subscribers[i].Телефон + ";";
                    allText += subscribers[i].Тип + ";";
                    allText += subscribers[i].Имя + ";";
                    allText += subscribers[i].Адрес + ";";
                    allText += subscribers[i].Тариф;   
                    //Отступ для разделения строк
                    allText += "\n";
                }
                //В конец добавляем имена владельца и справочника
                allText+= ownerName + ";" + phonebookName + ";" + ";" + ";";
                //Записываем переменную в файл
                streamWriter.Write(allText);
            }


        }
    }
}
