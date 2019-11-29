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
       public Phonebook EnterData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            Phonebook phonebook = new Phonebook();
            try
            {
                using (StreamReader readfile = new StreamReader(openFileDialog.FileName,Encoding.Default))
                {

                    string[] allLines = readfile.ReadToEnd().Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                    string[,] subscribers = new string[allLines.Length, 7];
                    string[] meta = new string[7];
                    string[] line;
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

            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
            return phonebook;
        }
    }
}
