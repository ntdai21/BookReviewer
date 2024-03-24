﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAn1.UI.UserControls
{
    /// <summary>
    /// Interaction logic for InputFieldUC.xaml
    /// </summary>

    public partial class InputFieldUC : UserControl, INotifyPropertyChanged
    {
        public string UC_Title {  get; set; }

        public static readonly DependencyProperty UC_TextInputProperty =
            DependencyProperty.Register("UC_TextInput", typeof(String),
                typeof(InputFieldUC), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public String UC_TextInput
        {
            get { return GetValue(UC_TextInputProperty).ToString(); }
            set { SetValue(UC_TextInputProperty, value); }
        }

        public InputFieldUC()
        {
            InitializeComponent();
        }

        private void textBox_Loaded(object sender, RoutedEventArgs e)
        {
            BindingExpression mainTxtBxBinding = BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty);
            BindingExpression textBinding = BindingOperations.GetBindingExpression(this, UC_TextInputProperty);

            if (textBinding != null && mainTxtBxBinding != null && textBinding.ParentBinding != null && textBinding.ParentBinding.ValidationRules.Count > 0 && mainTxtBxBinding.ParentBinding.ValidationRules.Count < 1)
            {
                foreach (ValidationRule vRule in textBinding.ParentBinding.ValidationRules)
                    mainTxtBxBinding.ParentBinding.ValidationRules.Add(vRule);
            }
        }
    }
}
