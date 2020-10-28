﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CheckListQuests
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // QuestsBox.file_readTXT("TEMPTXT.txt");
            ListBox_Quest.ItemsSource = QuestsBox.questItems;

            // QuestsBox.questItems.Add();
            QuestsBox.file_readTXT("TEMPTXT.txt");

            ResetListNew();
            //ListBox_New.Items.Add("<Добавить новый вопрос>");
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            input_AnAnswer.Text = "";
            input_Answer.Text = "";
            input_Comment.Text = "";
            input_Quest.Text = "";
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (QuestsBox.if_ThereQuest(input_Quest.Text))
            {
                MessageBox.Show("Такой вопрос уже был добавлен ранее", "Невозможно добавить вопрос");
                return;
            }

            QuestItem questItem = new QuestItem();
            questItem.quest = input_Quest.Text;
            questItem.comment = input_Comment.Text;
            questItem.InputAnswerList(input_Answer.Text, input_AnAnswer.Text);
            addListBoxQuetsItem(questItem);
        }
        private void addListBoxQuetsItem(QuestItem questItem)
        {
            QuestsBox.questItems.Add(questItem);
            //ListBox_Quest.Items.Add(questItem);    
            /*TODO будут ли они сортироваться, можно ли добаваить всплывающую подсказку*/
        }

        private void MenuItemSaveTXT_Click(object sender, RoutedEventArgs e)
        {
            QuestsBox.file_saveTXT("text.txt");
            MessageBox.Show("Файл сохранен text.txt");
        }

        private void ListBox_Quest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var t = ListBox_Quest.items[ListBox_Quest.Itemindex];
            // var temp = ListBox_Quest.SelectedItem;
            int val = IndexClickListBox(ListBox_Quest.SelectedItem.ToString());
            input_AnAnswer.Text = QuestsBox.questItems.ElementAt(val).StrFullAnswer(false);
            input_Answer.Text = QuestsBox.questItems.ElementAt(val).StrFullAnswer();
            input_Comment.Text = QuestsBox.questItems.ElementAt(val).comment;
            input_Quest.Text = QuestsBox.questItems.ElementAt(val).quest;


            Button_Clear.Content = "Удалить";
            Button_Save.Content = "Изменить";
            ResetListNew();
        }
        private int IndexClickListBox(string str)
        {
            int count = 0;
            foreach (QuestItem tmp in QuestsBox.questItems)
            {
                if(tmp.ToString() == str)
                    return count;
                count++;
            }
            return 0;
        }
        private void  ResetListNew()
        {
            ListBox_New.Items.Clear();
            ListBox_New.Items.Add("<Добавить новый вопрос>");
        }

        private void ListBox_New_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListBox_Quest.SelectedIndex = -1;


              // ClearSelected();
            Button_Clear.Content = "Очистить";
            Button_Save.Content = "Сохранить";
        }
    }
}
