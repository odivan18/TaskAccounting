using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskAccounting.Filler
{
    class ListControlFiller
    {
        public static void ComboBoxWithStringList(ComboBox comboBox, List<string> fields)
        {
            if (fields == null)
            {
                throw new Exception("Подан пустой список для впадающего списка на заполнение");
            }

            var array = new string[comboBox.Items.Count + 1];
            comboBox.Items.CopyTo(array, 0);

            comboBox.Items.Clear();
            foreach (string field in fields)
            {
                if (field == null)
                {
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(array);
                    throw new Exception("В списке для впадающего списка оказалось путое имя");
                }

                comboBox.Items.Add(field);
            }
        }

        public static void CheckedListBoxWithStringList(CheckedListBox checkedListBox, List<string> tasks)
        {
            if (tasks == null)
            {
                throw new Exception("Подан пустой список для впадающего списка на заполнение");
            }

            var array = new string[checkedListBox.Items.Count + 1];
            checkedListBox.Items.CopyTo(array, 0);

            checkedListBox.Items.Clear();
            foreach (string task in tasks)
            {
                if (task == null)
                {
                    checkedListBox.Items.Clear();
                    checkedListBox.Items.AddRange(array);
                    throw new Exception("Ошибка в списке задач на заполнение");
                }

                checkedListBox.Items.Add(task);
            }
        }
    }
}
