using System.Dynamic;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        double currentNumber = 0;
        double previousNumber = 0;
        double memory = 0;
        String currentOperator = "";
        Boolean newOperator = true;

        public MainPage()
        {
            InitializeComponent();
        }

        //evento para manejar los numeros
        private void Convertion(object sender, EventArgs e)
        {
            Button button = (Button)sender; 
            String number = button.Text;

            //este codigo sirve para concatenar los numeros
            if (newOperator)
            {
                ResultEntry.Text = number;
                newOperator = false;
            }
            else
            {
                ResultEntry.Text += number;
            }
            currentNumber = Convert.ToDouble(ResultEntry.Text); //convierte el numero de String a Double
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String operatorSymbol = button.Text;

            if (!newOperator)
            {
                RealizarCalculo();
            }
            currentOperator = operatorSymbol; //establece el nuevo operador 
            previousNumber = currentNumber; //este codigo guarda el numero nuevo como el antiguo 
            newOperator = true; //esto sirve para marcar que estamos listos para añadir un nuevo numero
        }

        private void RealizarCalculo()
        {
            switch (currentOperator)
            {
                case "+":
                    currentNumber = previousNumber + currentNumber;
                    break;
                case "-":
                    currentNumber = previousNumber - currentNumber;
                    break;
                case "x":
                    currentNumber = previousNumber * currentNumber;
                    break;
                case "/":
                    if (currentNumber != 0)
                    {
                        currentNumber = previousNumber / currentNumber;
                    }
                    else
                    {
                        ResultEntry.Text = "No se puede dividir un número entre cero";
                        return; 
                    }
                    break;
                default:
                    return;
            }
            ResultEntry.Text = "" + currentNumber;
            memory = currentNumber;
            Memory.Text = "Mem: " + currentNumber;
        }
        //metodo para manejar la memoria, podremos sumar, restar, mostrar por pantalla o eliminar la memoria. 
        private void MemoryButtons(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String memoryButtons = button.Text;

            switch (memoryButtons)
            {
                case "M+":
                    memory += currentNumber;
                    Memory.Text = "Mem: " + memory;
                    break;
                case "M-": 
                    memory -= currentNumber;
                    Memory.Text = "Mem: " + memory;
                    break;
                case "MC":
                    memory = 0;
                    Memory.Text = "Mem: " + memory;
                    break;
                case "MR":
                    ResultEntry.Text = memory.ToString();
                    currentNumber = memory;
                    newOperator = true; //permite una nueva operacion 
                    break;
                default:
                    return; 
            }
        }
        //este metodo borra todo, operaciones y memoria incluida. 
        private void EraseBtn_Clicked(object sender, EventArgs e)
        {
            currentNumber = 0;
            previousNumber = 0;
            memory = 0;
            ResultEntry.Text = "0";
            Memory.Text = "Mem: " + memory; 
            currentOperator = "";
            newOperator = true;
        }
    }
}