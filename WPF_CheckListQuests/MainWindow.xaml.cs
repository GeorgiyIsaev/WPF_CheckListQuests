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
        List<string> str_list_test = new List<string>();        
        public MainWindow()
        {
            InitializeComponent();
            inputTestList();


        }
        void inputTestList()
        {
            for (int i = 0; i < 50; i++)
            {
                str_list_test.Add($"Тестовый вопрос {i}");
                ListBox_Quest.Items.Add($"Тестовый вопрос {i}");
            }
        }

    }



}