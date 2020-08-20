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
    public partial class MesView : ContentView
    {
        public MesView()
        {
            InitializeComponent();
        }

        public string Mes
        {
            get => (string)GetValue(MesProperty);
            set => SetValue(MesProperty, value);
        }

        public static readonly BindableProperty MesProperty
            = BindableProperty.Create(
                propertyName: nameof(Mes),
                returnType: typeof(string),
                declaringType: typeof(string),
                defaultValue: default,
                propertyChanged: MesChanged,
                defaultBindingMode: BindingMode.TwoWay);

        private static void MesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (MesView)bindable;
            element.MesLabel.Text = (string)newValue;
        }

        public bool Selecionado
        {
            get => (bool)GetValue(SelecionadoProperty);
            set => SetValue(SelecionadoProperty, value);
        }

        public static readonly BindableProperty SelecionadoProperty
            = BindableProperty.Create(
                propertyName: nameof(Selecionado),
                returnType: typeof(bool),
                declaringType: typeof(bool),
                defaultValue: default,
                propertyChanged: SelecionadoChanged,
                defaultBindingMode: BindingMode.TwoWay);

        private static void SelecionadoChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (MesView)bindable;

            if ((bool)newValue)
            {
                if (!App.Current.Resources.TryGetValue("PrimaryLight", out object corFundo))
                    corFundo = Color.FromHex("cbcbfe");

                if (!App.Current.Resources.TryGetValue("PrimaryDark", out object corTexto))
                    corFundo = Color.FromHex("cbcbfe");

                element.MesContainer.BackgroundColor = (Color)corFundo;
                element.MesLabel.TextColor = (Color)corTexto;
            }
            else
            {
                element.MesContainer.BackgroundColor = Color.White;
                element.MesLabel.TextColor = Color.FromHex("#b0b0b0");
            }

        }
    }
}