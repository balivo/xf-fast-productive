using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPicker : ContentView
    {
        public CustomPicker()
        {
            InitializeComponent();
        }

        public string Selected
        {
            get => (string)GetValue(SelectedProperty);
            set => SetValue(SelectedProperty, value);
        }

        public static readonly BindableProperty SelectedProperty
            = BindableProperty.Create(
                propertyName: nameof(Selected),
                returnType: typeof(string),
                declaringType: typeof(string),
                defaultValue: "All",
                propertyChanged: SelectedChanged,
                defaultBindingMode: BindingMode.TwoWay);

        private static void SelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (CustomPicker)bindable;
            element.PickerLabel.Text = (string)newValue;
        }

        private async void PickerContainerTapped(object sender, EventArgs e)
        {
            //var opcoes = new 

            Selected = await App.Current.MainPage.DisplayActionSheet("Selecione...",
                  cancel: "Voltar", destruction: default, new[] { "Opção 1", "Opção 2", "Opção 3", "Opção 4", "Opção 5" });
        }
    }
}