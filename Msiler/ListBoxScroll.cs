﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Quart.Msiler
{
    class ListBoxScroll : ListBox
    {
        public ListBoxScroll() {
            SelectionChanged += ListBoxScroll_SelectionChanged;
        }

        void ListBoxScroll_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ScrollIntoView(SelectedItem);
        }
    }
}