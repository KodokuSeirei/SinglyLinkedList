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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
           
            Phonebook phonebook = new Phonebook();
            using (StreamReader readfile = new StreamReader(openFileDialog.FileName))
            {
                string[] allLines = readfile.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                subscribers = new string[allLines.Length-1, 5];
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
               
               
                string allText = "Telephone number;Type of subscriber (company / individual);Subscriber (name / full name);Adress;Rate\n";
                for (int i = 0; i < subscribers.Count; i++)
                {
                    MessageBox.Show(subscribers.Count.ToString());
                    //Файл данными из ObservableCollection
                    allText += subscribers[i].Телефон + ";";
                    allText += subscribers[i].Тип + ";";
                    allText += subscribers[i].Имя + ";";
                    allText += subscribers[i].Адрес + ";";
                    allText += subscribers[i].Тариф;                        
                    allText += "\n";
                }
                allText+= ownerName + ";" + phonebookName + ";" + ";" + ";";
                streamWriter.Write(allText);
            }


        }
    }
}
