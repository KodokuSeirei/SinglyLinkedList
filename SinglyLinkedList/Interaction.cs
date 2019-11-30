using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
       public Phonebook EnterData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "")
                MessageBox.Show("Файл не выбран");
            
            Phonebook phonebook = new Phonebook();
            
                using (StreamReader readfile = new StreamReader(openFileDialog.FileName,Encoding.Default))
                {
                    string[] allLines = readfile.ReadToEnd().Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                    string[,] subscribers = new string[allLines.Length, 7];
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        line = allLines[i].Split(';');
                        for (int j = 0; j < line.Length; j++)
                        {
                            subscribers[i, j] = line[j];
                        }
                    }
                    phonebook.Name = subscribers[0, 5];
                    phonebook.OwnerName = subscribers[0, 6];
                    phonebook.Data = subscribers;
                }         
            return phonebook;
        }
        public void SaveData(PhonebookList phonebookList)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
                string allText = "";
                for (int i = 0; i < phonebookList[0].Data.GetLength(0); i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j != 4)
                            allText += phonebookList[0].Data[i, j] + ";";
                        else allText += phonebookList[0].Data[i, j];
                    }
                    if (i != phonebookList[0].Data.GetLength(0) - 1)
                        allText += "\n";
                }
                streamWriter.Write(allText, Encoding.Unicode);
            }


        }
    }
}
