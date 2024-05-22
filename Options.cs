using System.Globalization;
using System.Security.AccessControl;

namespace Proyecto2;
class OpcionesClass
    {
        InternalProcesses internalProcesses = new InternalProcesses();
        /* "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Salir" */
        public void infoCuenta(string[] accountData)
        {
            Console.Clear();
            BankAccount bankAccount = new BankAccount(accountData);
            bankAccount.AccountQuery();

        }

        public string[] compraProducto(string[] accountData)
        {
            decimal amount = decimal.Parse(accountData[6])/10;
            BankAccount bankAccount = new BankAccount(accountData);
            bankAccount.AccountDebit(amount);
            accountData[6] = bankAccount.balance.ToString();
            accountData[7] = amount.ToString();
            Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}");
            return accountData;
        }

        public string[] ventaProducto(string[] accountData){
            if (decimal.Parse(accountData[6]) >= 500)
            {
                double amount = double.Parse(accountData[6])*0.11;
                decimal amount2 = Convert.ToDecimal(amount);
                BankAccount bankAccount = new BankAccount(accountData);
                bankAccount.AccountCredit(amount2);
                Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}");
                accountData[6] = bankAccount.balance.ToString();
                accountData[7] = amount.ToString();
            }
            else
            {
                Console.WriteLine($"No es factible realizar esta transaccion debido al bajo saldo de la cuenta.");
            }
            Console.ReadKey();
            return accountData;
        }

        public string[] abonoCuenta(string[] accountData)
        {
            decimal amount = decimal.Parse(accountData[6]);
            if (amount > 500)
            {
                BankAccount bankAccount = new BankAccount(accountData);
                bankAccount.AccountCredit(amount);
                Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}");
                accountData[6] = bankAccount.balance.ToString();
                accountData[7] = amount.ToString(); 
            }
            else
            {
                Console.WriteLine("No se cumplen las condiciones necesarias para realizar esta accion.");
            }
            Console.ReadKey();
            return accountData;
        }

        public string[] pasoTiempo(string[] accountData){
            double amount;
            int Seleccion;
            double periodoCapitalizacion = 0;
            Console.WriteLine("Seleccion el periodo de Capitalizacion deseado, indicando el numero de opcion");
            Console.Write("1. 15 dias.\n2. 30 dias.");
            string? periodocapitalizacionString = Console.ReadLine();
            if(periodocapitalizacionString == ""){
                Seleccion = 0;
            }else{
                Seleccion = int.Parse(periodocapitalizacionString ?? string.Empty);
            }
            switch (Seleccion){
                case 1:
                periodoCapitalizacion = 15;
                break;

                case 2:
                periodoCapitalizacion = 30;
                break;

                default:
                Console.WriteLine("Opcion invalida");
                break;
            }  
            amount = double.Parse(accountData[6])*0.02 * (periodoCapitalizacion/360);
            decimal amount2 = Convert.ToDecimal(amount);
            BankAccount bankAccount = new BankAccount(accountData);
            bankAccount.AccountCredit(amount2);
            Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}, generó: {amount.ToString("f2")} en intereses.");
            accountData[6] = bankAccount.balance.ToString();
            accountData[7] = amount.ToString(); 
            Console.ReadKey();
            return accountData;
        }

        public string[] thirdPartyAccount(string[] accountData,string[,] thirdAccounts, int thirdAccountSeeds){
            Console.WriteLine("Solicite los siguientes datos al usuario que desea agregar");
            Console.ReadKey();
            thirdAccounts[thirdAccountSeeds-1,0] = thirdAccountSeeds.ToString();
            thirdAccounts[thirdAccountSeeds-1,1] = internalProcesses.AccountNameValidation();
            thirdAccounts[thirdAccountSeeds-1,2] = internalProcesses.ThirdPartyAccountNumber();
            thirdAccounts[thirdAccountSeeds-1,3] = internalProcesses.NameBanksValidation();
            thirdAccounts[thirdAccountSeeds-1,5] = internalProcesses.BadgesValidation();
            thirdAccounts[thirdAccountSeeds-1,4] = internalProcesses.AmountTransfers(thirdAccounts[thirdAccountSeeds-1,5]);
            accountData[7] = thirdAccounts[thirdAccountSeeds-1,4];
            BankAccount bankAccount = new BankAccount(accountData);
            bankAccount.AccountDebit(Convert.ToDecimal(accountData[7]));
            Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}");
            accountData[6] = bankAccount.balance.ToString();
            return accountData;
        }

                public string[] thirdAccountTransfers(string[] accountData,string[,] thirdAccounts){
            for(int i = 0; i < thirdAccounts.GetLength(0); i++){
//                Console.WriteLine(thirdAccounts.GetLength(0));
                for(int j = 0; j < thirdAccounts.GetLength(1); j++){
//                    Console.WriteLine(thirdAccounts.GetLength(1));
                    if(thirdAccounts[i,j] == "" || thirdAccounts[i, j] == null){
                        break;
                    } else{
                    Console.Write($"{thirdAccounts[i,j]}");
                    Console.Write("\n");
                    }
                }
            }
            while(true){
            Console.WriteLine("Seleccion la cuenta a la que desea transferir indicando el numero de indice");
                string selecccionCuentas = Console.ReadLine()??string.Empty;
                if (int.TryParse(selecccionCuentas, out int selecccionCuentasInt)){
                        selecccionCuentas = selecccionCuentasInt.ToString();
                        break;
                }else{
                    Console.WriteLine("Opcion invalida");
                }
                }
            accountData[7] = internalProcesses.AmountTransfers("Quetzales");
            BankAccount bankAccount = new BankAccount(accountData);
            try{
                bankAccount.AccountDebit(Convert.ToDecimal(accountData[7]));
                Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}");
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }
            accountData[6] = bankAccount.balance.ToString();
            return accountData;
        }

        public string[] servicesPay(string[] accountData, string[]proveedores){
            string proveedor;
            while(true){
                for(int i = 0; i < proveedores.Length; i++){
                    Console.WriteLine($"{i+1}.{proveedores[i]}");
                }
                Console.WriteLine("Indique al proveedor al que desea pagar, seleccionando el numero de opcion");
                proveedor = Console.ReadLine()?? string.Empty;
            if(proveedor == ""){
                Console.WriteLine("Debe ingresar un valor");
                Console.ReadKey();
            }
            else{
                int.TryParse(proveedor, out int proveedorInt);
                if(proveedorInt >0 && proveedorInt < 5){
                proveedor = internalProcesses.switchCase4(proveedorInt, proveedores);
                break;
                }else{
                    Console.WriteLine("El valor ingresado no es una opcion valida");
                    Console.ReadKey();
                }
                }
            }
            accountData[7] = internalProcesses.AmountTransfers("Quetzales");
            BankAccount bankAccount = new BankAccount(accountData);
            try{
                bankAccount.AccountDebit(Convert.ToDecimal(accountData[7]));
                Console.WriteLine($"Saldo de cuenta: {bankAccount.balance}");
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }
            accountData[6] = bankAccount.balance.ToString();
            return accountData;
        }
        public void printLogs(List<string> Logs)
        {
            Console.WriteLine("\n\nLogs: ");
            for (int i = 0; i < Logs.Count; i++)
            {
                Console.WriteLine($"{i+1}.{Logs[i]}");
            }
        }

        public void addLogs(List<string> Logs, string[] opciones, int menuOpciones, string[] accountData, string operationType)
        {
            BankAccount bankAccount = new BankAccount(accountData);
            Logs.Add($"Operacion realizada: {opciones[menuOpciones - 1]}, Fecha: {DateTime.Now},Tipo de operacion: {operationType},Monto de transaccion: {accountData[7]} ");
        }
    }
