﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace GI.CS.WPF.Core.CheckList
{
    class QuestsBoxForTest
    {
       public static List<QuestItem> questItemsForTest = new List<QuestItem>();
       
       public static void createTest()
       {          
            questItemsForTest = new List<QuestItem>(QuestsBox.questItems);         
            questItemsForTest.RemoveAt(0);
            string val =  questItemsForTest[0].ToolTypeListBox();


            foreach (QuestItem tmp in questItemsForTest)
            {
                tmp.RandomGeneratorIt();
            }             

            questItemsForTest.Sort(delegate (QuestItem a, QuestItem b)
            {
                 return a.intRandomQuest.CompareTo(b.intRandomQuest);
            });
       }
    }
}
