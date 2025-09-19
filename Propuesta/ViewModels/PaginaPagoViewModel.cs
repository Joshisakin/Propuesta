using Propuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public partial class PaginaPagoViewModel : ObservableObject
    {
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }

        public List<string> PaymentMethods { get; }
        private string _selectedPaymentMethod = string.Empty;
        public string SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set { _selectedPaymentMethod = value; OnPropertyChanged(); }
        }

        public ICommand ProcessPaymentCommand { get; }

        public PaginaPagoViewModel()
        {
            Amount = 100.00m;
            PaymentMethods = Enum.GetNames(typeof(PaymentMethod)).ToList();
            SelectedPaymentMethod = PaymentMethods.First();
            ProcessPaymentCommand = new Command(async () => await ProcessPayment());
        }

        private async Task ProcessPayment()
        {
            if (Amount <= 0)
            {
                var window = Application.Current?.Windows?.FirstOrDefault();
                if (window?.Page is not null)
                {
                    await window.Page.DisplayAlert("Error", "Por favor, ingrese un monto válido.", "OK");
                }
                return;
            }

            var mainWindow = Application.Current?.Windows?.FirstOrDefault();
            if (mainWindow?.Page is not null)
            {
                await mainWindow.Page.DisplayAlert("Simulación de Pago", $"Procesando pago de S/ {Amount:F2} con {SelectedPaymentMethod}.", "OK");
                await mainWindow.Page.DisplayAlert("Éxito", "Pago procesado correctamente.", "OK");
            }
            await Shell.Current.GoToAsync(".."); 
        }
    }
}
