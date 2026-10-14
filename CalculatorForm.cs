namespace calculadoraTarea;

internal sealed class CalculatorForm : Form
{
    private ComboBox operaciones = new ComboBox();
    private TextBox numero1 = new TextBox();
    private TextBox numero2 = new TextBox();
    private TextBox resultado = new TextBox();

    public CalculatorForm()
    {
        Text = "Form1";
        ClientSize = new Size(329, 229);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        Label etiquetaOperaciones = new Label();
        etiquetaOperaciones.Text = "Operaciones";
        etiquetaOperaciones.SetBounds(20, 23, 120, 22);
        Controls.Add(etiquetaOperaciones);

        operaciones.Items.Add("Suma");
        operaciones.Items.Add("Resta");
        operaciones.Items.Add("Multiplicación");
        operaciones.Items.Add("División");
        operaciones.DropDownStyle = ComboBoxStyle.DropDownList;
        operaciones.SelectedIndex = 2;
        operaciones.SetBounds(16, 39, 155, 24);
        Controls.Add(operaciones);

        Label etiquetaNumero1 = new Label();
        etiquetaNumero1.Text = "Número 1";
        etiquetaNumero1.SetBounds(20, 80, 120, 22);
        Controls.Add(etiquetaNumero1);

        numero1.SetBounds(16, 96, 128, 23);
        Controls.Add(numero1);

        Label etiquetaNumero2 = new Label();
        etiquetaNumero2.Text = "Número 2";
        etiquetaNumero2.SetBounds(198, 80, 120, 22);
        Controls.Add(etiquetaNumero2);

        numero2.SetBounds(197, 96, 128, 23);
        Controls.Add(numero2);

        Button botonCalcular = new Button();
        botonCalcular.Text = "Calcular";
        botonCalcular.SetBounds(197, 140, 96, 26);
        botonCalcular.Click += Calcular;
        Controls.Add(botonCalcular);

        Label etiquetaResultado = new Label();
        etiquetaResultado.Text = "Resultado:";
        etiquetaResultado.SetBounds(20, 198, 75, 22);
        Controls.Add(etiquetaResultado);

        resultado.ReadOnly = true;
        resultado.SetBounds(96, 191, 128, 23);
        Controls.Add(resultado);
    }

    private void Calcular(object? sender, EventArgs e)
    {
        double primerNumero;
        double segundoNumero;

        if (!double.TryParse(numero1.Text, out primerNumero))
        {
            MessageBox.Show("Escribe un número válido en Número 1.");
            return;
        }

        if (!double.TryParse(numero2.Text, out segundoNumero))
        {
            MessageBox.Show("Escribe un número válido en Número 2.");
            return;
        }

        if (operaciones.Text == "División" && segundoNumero == 0)
        {
            MessageBox.Show("No se puede dividir entre cero.");
            return;
        }

        double total = CalculatorService.Calcular(primerNumero, segundoNumero, operaciones.Text);
        resultado.Text = total.ToString();
    }
}
