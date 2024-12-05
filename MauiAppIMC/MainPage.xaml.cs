using Microsoft.Maui.Controls;

namespace MauiAppIMC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalcularImcClicked(object sender, EventArgs e)
        {
            try
            {
                // Usando TryParse para evitar exceções
                if (!double.TryParse(txtPeso.Text, out double peso) || !double.TryParse(txtAltura.Text, out double altura))
                {
                    lblResultado.Text = "Por favor, insira valores válidos para peso e altura.";
                    return;
                }

                if (peso <= 0 || altura <= 0)
                {
                    lblResultado.Text = "Peso e altura devem ser maiores que zero.";
                    return;
                }

                // Calculando o IMC
                double imc = peso / (altura * altura);

                // Formatando o resultado
                string resultado = $"IMC: {imc:F2}\n";

                // Classificação do IMC
                if (imc < 18.5)
                    resultado += "Abaixo do peso.";
                else if (imc >= 18.5 && imc <= 24.9)
                    resultado += "Peso normal.";
                else if (imc >= 25 && imc <= 29.9)
                    resultado += "Sobrepeso.";
                else
                    resultado += "Obesidade.";

                // Exibindo o resultado
                lblResultado.Text = resultado;
            }
            catch (Exception ex)
            {
                // Exibir mensagem de erro em caso de exceções
                lblResultado.Text = "Erro: " + ex.Message;
            }
        }
    }
}
