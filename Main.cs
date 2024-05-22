using Menu;
//Clase Program. Metodo Main
//En esta clase unicamente llamo a los metodos principales del codigo y creo un while con la variable menuValidate para poder cerrar el programa
class Program
{

    public static void Main(string[] args)
    {
        bool menuValidate = true;
        OptionMenu menu = new OptionMenu();
        menu.FirstMenu();
        while (menuValidate)
        {
            menuValidate = menu.opcionesPrincipales(menuValidate);
        }
    }
}

