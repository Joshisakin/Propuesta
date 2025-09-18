using Propuesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }

        public List<string> PaymentMethods { get; }
        private string _selectedPaymentMethod;
        public string SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set { _selectedPaymentMethod = value; OnPropertyChanged(); }
        }

        public ICommand ProcessPaymentCommand { get; }

        public PaymentViewModel()
        {
            Amount = 100.00m; // Default inscription fee
            PaymentMethods = Enum.GetNames(typeof(PaymentMethod)).ToList();
            SelectedPaymentMethod = PaymentMethods.First();
            ProcessPaymentCommand = new Command(async () => await ProcessPayment());
        }

        private async Task ProcessPayment()
        {
            if (Amount <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese un monto válido.", "OK");
                return;
            }

            // This simulates payment processing.
            await Application.Current.MainPage.DisplayAlert("Simulación de Pago", $"Procesando pago de S/ {Amount:F2} con {SelectedPaymentMethod}.", "OK");

            // In a real app, you would handle the payment gateway integration here.
            // For this prototype, we'll just show a success message and navigate back.
            await Application.Current.MainPage.DisplayAlert("Éxito", "Pago procesado correctamente.", "OK");
            await Shell.Current.GoToAsync(".."); // Go back to the previous page
        }
    }
}
