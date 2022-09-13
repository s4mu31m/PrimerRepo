using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        //Variables Locales
        string enterPa, nombreAr, apellidosAr, direccionAr, runAr;
        //saldoAr almacena el valor de retorno el cual va variando segun deposite o retire
        double saldoAr;
        saldoAr = 0;



        Console.WriteLine("            -------------      ----------------------------------");
        Console.WriteLine("           | BANCO GAMMA |    | USUARIO: Agente Perry PLAZA : LS | ");
        Console.WriteLine("            ¯¯¯¯¯¯¯¯¯¯¯¯¯      ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
        Console.WriteLine(" Se encuentra por abrir una cuenta en nuestro banco, favor presione enter para continuar\n");
        //usuario procede a ingresar datos
        enterPa = Console.ReadLine();

        Console.WriteLine(" Ingrese la información que se solicita a continuación ");
        Console.WriteLine(" ______________________________________________________");
        Console.WriteLine("|                                                      |");
        Console.Write("| Nombre : "); ;
        nombreAr = Console.ReadLine();

        Console.Write("| Apellidos : ");
        apellidosAr = Console.ReadLine();

        Console.Write("| Dirección : ");
        direccionAr = Console.ReadLine();

        Console.Write("| Run : ");
        runAr = Console.ReadLine();

        Console.WriteLine("|");
        Console.Write("| Ingrese su depósito inicial: $");
        //se asigna un valor inicial a saldoAr
        //se realiza conversión de datos para poder ocupar el método "ReadLine" ya que este solo lee datos tipo "string"
        saldoAr = Convert.ToDouble(Console.ReadLine());


        Console.WriteLine("|______________________________________________________|");
        Console.WriteLine(" -------------------------------------------");
        Console.WriteLine("| Cuenta creada con éxito                   |");
        Console.WriteLine(" -------------------------------------------");
        // se utiliza variable "enterPa" para darle una pausa al sistema
        Console.WriteLine("Presione Enter para continuar");
        enterPa = Console.ReadLine();
        Console.Clear();

        //instanciamos la clase CuentaBancaria
        CuentaBancaria cuenta1 = new CuentaBancaria(nombreAr, apellidosAr, direccionAr, runAr, saldoAr);


        // Se ingresa al bucle "menú" el cuál no se detendrá mientras la opción del usuario sea entre 1 y 4
        int opc = 0;
        do
        {
            Console.WriteLine(" ____________________$_____________________");
            Console.WriteLine("$       MENU PRINCIPAL                     $");
            Console.WriteLine("| 1: Depósito                              |");
            Console.WriteLine("| 2: Retiro                                |");
            Console.WriteLine("$ 3: Consultar saldo                       $");
            Console.WriteLine("| 4: Mostrar información de la cuenta      |");
            Console.WriteLine("| 5: Salir                                 |");
            Console.WriteLine("$____________________$_____________________$");
            opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)

            {
                // se llaman a los métodos para aplicar sus respectivas funciones
                case 1:
                    Console.Clear();
                    Console.Write("¦Ingrese su depósito: $");

                    saldoAr = cuenta1.Deposito(saldoAr);

                    Console.WriteLine("¦Presione Enter para volver al menú principal¦");
                    enterPa = Console.ReadLine();
                    // se utiliza el método ".Clear" para limpiar la consola
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("¦Cuánto quiere retirar: $");


                    saldoAr = cuenta1.Retiro(saldoAr);

                    Console.WriteLine("\nPresione Enter para volver al menú principal");
                    enterPa = Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    Console.Clear();
                    cuenta1.ConsultaSaldo(saldoAr);

                    Console.WriteLine("\nPresione Enter para volver al menú principal");
                    enterPa = Console.ReadLine();
                    Console.Clear();
                    break;

                case 4:
                    Console.Clear();
                    cuenta1.ToString();

                    Console.WriteLine("\nPresione Enter para volver al menú principal");
                    enterPa = Console.ReadLine();
                    Console.Clear();
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine(" ---------------------------------");
                    Console.WriteLine("¦Hasta luego, !ten un gran día! :D ¦");
                    Console.WriteLine(" ---------------------------------");
                    enterPa = Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("¦¡Por favor ingresa una opción válida!¦");
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("\nPresione Enter para volver al menú principal");
                    enterPa = Console.ReadLine();
                    Console.Clear();
                    break;

            }
            //se definen las condiciones bajo las cuales seguirá ejecutándose el ciclo "do while"
        } while (opc != 5);
    }
}
// se crea la clase CuentaBancaria
class CuentaBancaria
{
    // Definimos Atributos
    private string nombre, apellidos, direccion, run;

    private double saldo;

    // Creamos método Constructor

    public CuentaBancaria(string nombrePa, string apellidosPa, string direccionPa, string runPa, double saldoPa)
    {
        nombre = nombrePa;
        apellidos = apellidosPa;
        direccion = direccionPa;
        run = runPa;
        saldo = saldoPa;
    }

    //Creamos los Métodos

    public double Deposito(double saldo)
    {
        //Definimos la función de cada método
        double saldoVa = Convert.ToDouble(Console.ReadLine());
        saldo = saldoVa + saldo;

        Console.WriteLine(" ------------------------------");
        Console.WriteLine("¦¡Depósito realizado con Éxito!¦");
        Console.WriteLine(" ------------------------------");

        Console.WriteLine("¦Aportaste: $" + saldoVa + "¦" + "\n"
                          + "¦Su saldo actual es de: $" + saldo);
        return saldo;
    }

    public double Retiro(double saldo)
    {
        //se utiliza la variable "saldoVa" como una variabre volatil la cual solo recibirá el monto con el qu el usuario quiere trabajar
        //se comparará y/u operará con esta variable para asignar el nuevo valor de saldo

        double saldoVa = Convert.ToDouble(Console.ReadLine());

        //se utiliza una función condicional para la correcta ejecución de lo requerido por el programa

        if (saldoVa > saldo)
        {
            Console.WriteLine(" ------------------------------------------");
            Console.WriteLine("¦Saldo insuficiente, Realiza un depósito :D¦");
            Console.WriteLine(" ------------------------------------------");

        }
        else
        {
            saldo = saldo - saldoVa;

            Console.WriteLine(" ------------------------------");
            Console.WriteLine("¦!Retiro realizado con Éxito! ¦");
            Console.WriteLine(" ------------------------------");

            Console.WriteLine("|Retiraste: $" + saldoVa + "|" + "\n"
                              + "|Su saldo actual es de: $" + saldo + "|");

        }

        return saldo;
    }

    public void ConsultaSaldo(double saldo)
    {
        double saldoAr = saldo;
        Console.Write("¦Su saldo es de: $" + saldoAr + "¦" + "\n"
                    + " ----------------------");
    }

    public override string ToString()
    {
        //se modifica el método "ToString" para enlazar cadenas de texto y entregarlas al menú
        string mensaje = "";
        mensaje = "|Nombre Cliente: " + nombre + "\n"
                  + "|Apellidos: " + apellidos + "\n"
                  + "|Su Dirección es: " + direccion + "\n"
                  + "|Su RUN es: " + run + "\n";
        Console.WriteLine(mensaje);
        return mensaje;
    }
}