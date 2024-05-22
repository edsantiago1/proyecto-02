using Menu;

/* public string Owner { get; set; }   
    public string Type { get; set; }
    public string phoneNumber { get; set; }
    public string id {get; set; }
    public decimal balance { get; set; }
    public string addres { get; set; }
 */
class Program{

        public static void Main(string[] args)  {
            bool menuValidate = true;
            OptionMenu menu = new OptionMenu();
            menu.FirstMenu();
            while(menuValidate){
            menuValidate = menu.opcionesPrincipales(menuValidate);
            }
    }
}

