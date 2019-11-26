using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3
{
    class Interaction
    {
       public Phonebook EnterData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            Phonebook phonebook = new Phonebook();
            using (StreamReader readfile = new StreamReader(openFileDialog.FileName))
            {

                string[] allLines = readfile.ReadToEnd().Split('\n');
                string[,] subscribers = new string[7,7];
                string[] meta = new string[7];
                string[] line=new string[7];
                for (int i = 0; i < allLines.Length; i++)
                {
                    line = allLines[i].Split(';');
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (i == 0)
                            meta[j] = line[j];
                        else
                            subscribers[i, j] = line[j];                         
                    }
                }               
                phonebook.Name = meta[0];             
                MessageBox.Show(phonebook.Name);
                phonebook.OwnerName = meta[1];
                MessageBox.Show(phonebook.OwnerName);
                phonebook.Data = subscribers;
            }
            return phonebook;
        }
    }
}
