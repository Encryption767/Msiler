﻿using ICSharpCode.AvalonEdit;
using System;
using System.ComponentModel;
using System.Windows;

namespace Quart.Msiler
{
    public class MvvmTextEditor : TextEditor, INotifyPropertyChanged
    {
        /// <summary>
        /// A bindable Text property
        /// </summary>
        public new string Text {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// The bindable text property dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MvvmTextEditor), new PropertyMetadata((obj, args) => {
                var target = (MvvmTextEditor)obj;
                target.Text = (string)args.NewValue;
            }));

        protected override void OnTextChanged(EventArgs e) {
            RaisePropertyChanged("Text");
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Raises a property changed event
        /// </summary>
        /// <param name="property">The name of the property that updates</param>
        public void RaisePropertyChanged(string property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
