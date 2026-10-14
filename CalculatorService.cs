namespace calculadoraTarea;

internal static class CalculatorService
{
    public static double Calcular(double numero1, double numero2, string operacion)
    {
        if (operacion == "Suma")
        {
            return numero1 + numero2;
        }
        else if (operacion == "Resta")
        {
            return numero1 - numero2;
        }
        else if (operacion == "Multiplicación")
        {
            return numero1 * numero2;
        }
        else
        {
            return numero1 / numero2;
        }
    }
}
