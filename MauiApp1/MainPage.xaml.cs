namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        // 1. Obtener los textos de las cajas de texto
        string nombre = NombreEntry.Text;
        string apellido = ApellidoEntry.Text;
        string edadTexto = EdadEntry.Text;
        string salarioTexto = SalarioEntry.Text;

        // 2. Validación de campos vacíos
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(edadTexto) ||
            string.IsNullOrWhiteSpace(salarioTexto))
        {
            await DisplayAlert("Error", "Todos los campos deben estar completos.", "OK");
            return; // Detiene la ejecución si hay campos vacíos
        }

        // 3. Validación de números y conversión
        int edad;
        double salario;

        bool esEdadValida = int.TryParse(edadTexto, out edad);
        bool esSalarioValido = double.TryParse(salarioTexto, out salario);

        if (!esEdadValida || !esSalarioValido)
        {
            await DisplayAlert("Error", "La edad y el salario deben aceptar solo números.", "OK");
            return;
        }

        // 4. Calcular el aporte al IESS (9.45% del salario)
        double aporteMensual = salario * 0.0945;

        // 5. Mostrar la salida de información usando \n para saltos de línea
        string mensaje = $"Bienvenido {nombre} {apellido}\n" +
                         $"Tienes {edad} años\n" +
                         $"Tu aporte mensual es ${aporteMensual:F2}";

        await DisplayAlert("Resultado", mensaje, "Aceptar");
    }
}