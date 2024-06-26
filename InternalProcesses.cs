using System.Collections;
using System.Data.Common;
using Proyecto2;

//Clase InternaProcesses
//En esta clase estan todos los metodos de funcionalidades internas del banco
//Tales como el generador de numeros de cuenta (este genera los numeros de cuenta basandose en un numero base que itera y una terminacion especifica segun el tipo de cuenta)

namespace Proyecto2;

/* public string Owner { get; set; }   
    public string Type { get; set; }
    public string phoneNumber { get; set; }
    public string id {get; set; }
    public decimal balance { get; set; }
    public string address { get; set; }
    public int AccountNumber { get; set; }   */
public class InternalProcesses
{
    private static int s_accountNumberSeed = 12345678;
    #region AccountNumber
    public string AccountId(string Type)
    {
        int AccountType;
        switch (Type)
        {
            case "Cuenta Monetaria Quetzales.":
                AccountType = 0101;
                break;
            case "Cuenta Monetaria Dolares.":
                AccountType = 0202;
                break;
            case "Cuenta Ahorro Quetzales.":
                AccountType = 0303;
                break;
            case "Cuenta Ahorro Dolares.":
                AccountType = 0404;
                break;
            default:
                throw new ArgumentException(nameof(Type), "Tipo de cuenta invalido para la creacion del numero de cuenta");
        }
        string s_accountNumberSeedString = s_accountNumberSeed.ToString() + AccountType.ToString();
        return s_accountNumberSeedString;
    }
    public static string switchCase1(int tipoCuenta)
    {
        string AccountType;
        switch (tipoCuenta)
        {
            case 1:
                AccountType = "Cuenta Monetaria Quetzales.";
                break;

            case 2:
                AccountType = "Cuenta Monetaria Dolares.";
                break;

            case 3:
                AccountType = "Cuenta Ahorro Quetzales.";
                break;

            case 4:
                AccountType = "Cuenta Ahorro Dolares.";
                break;

            default:
                Console.Clear();
                Console.WriteLine("Opcion invalida");
                Console.ReadKey();
                AccountType = "";
                break;
        }
        return AccountType;

    }
    public string ThirdPartyAccountNumber()
    {
        string accountNumber;
        while (true)
        {
            Console.Clear();
            Console.Write("Ingrese el numero de cuenta (Campo estrico de 10 caracteres): ");
            accountNumber = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(accountNumber, out int accountNumberValor) && accountNumber.Length == 10)
            {
                accountNumber = accountNumberValor.ToString();
                break;
            }
            else
            {
                Console.WriteLine("El numero de cuenta debe ser un valor numerico (Campo estricto de 10 caracteres)");
            }
            Console.ReadKey();
        }
        return accountNumber;

    }
    #endregion
    #region AccountType
    public string AccountTypeValidation()
    {
        string AccountType;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("A continuacion ingrese los datos solicitados.");
            Console.WriteLine("1. Cuenta monetaria Quetzales.\n2.Cuenta monetaria Dolares.\n3.Cuenta de ahorro en Quetzales.\n4.Cuenta de ahorro en Dolares.");
            Console.Write("Seleccione su tipo de cuenta indicando la opcion acorde: ");
            AccountType = Console.ReadLine() ?? string.Empty;
            if (AccountType == "")
            {
                Console.WriteLine("Debe ingresar un valor");
                Console.ReadKey();
            }
            else
            {
                int.TryParse(AccountType, out int tipoCuentaInt);
                if (tipoCuentaInt > 0 && tipoCuentaInt < 5)
                {
                    AccountType = switchCase1(tipoCuentaInt);
                    break;
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es una opcion valida");
                    Console.ReadKey();
                }
            }
        }
        return AccountType;
    }
    #endregion
    #region AccountName
    public string AccountNameValidation()
    {
        string ownerName;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ingrese su nombre completo");
            ownerName = Console.ReadLine() ?? string.Empty;
            if (ownerName == "")
            {
                Console.WriteLine("Debe ingresar su nombre para continuar");
            }
            else if (int.TryParse(ownerName, out int ownerNameError))
            {
                Console.WriteLine("No se aceptan numero en el ingreso del nombre");
                Console.ReadKey();
            }
            else
            {
                break;
            }
        }
        return ownerName;
    }
    #endregion
    #region AccountOwnerID
    public string AccountIdOwner()
    {
        string Id;
        while (true)
        {
            Console.Clear();
            Console.Write("Ingrese su numero de DPI (Campo estrico de 5 caracteres): ");
            Id = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(Id, out int IdValor) && Id.Length == 5)
            {
                Id = IdValor.ToString();
                break;
            }
            else
            {
                Console.WriteLine("El numero de ID debe ser un valor numerico (Campo estricto de 5 caracteres)");
            }
            Console.ReadKey();
        }
        return Id;
    }
    #endregion
    #region AccountAddress
    public string AccountAddresValidation()
    {
        string AccountAddress;
        while (true)
        {
            Console.Clear();
            Console.Write("Ingrese su direccion de residencia: ");
            AccountAddress = Console.ReadLine() ?? string.Empty;
            if (AccountAddress == "")
            {
                Console.WriteLine("Debe ingresar un valor.");
            }
            else
            {
                break;
            }
            Console.ReadKey();
        }
        return AccountAddress;
    }
    #endregion
    #region AccountPhoneNumber
    public string AccountPhoneNumberValidation()
    {
        string PhoneNumber;
        while (true)
        {
            Console.Clear();
            Console.Write("Ingrese su numero de telefono (Campo estrico de 8 caracteres): ");
            PhoneNumber = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(PhoneNumber, out int PhoneNumberValor) && PhoneNumber.Length == 8)
            {
                PhoneNumber = PhoneNumberValor.ToString();
                break;
            }
            else
            {
                Console.WriteLine("El numero de telefono debe ser un valor numerico (Campo estricto de 8 caracteres)");
            }
            Console.ReadKey();
        }
        return PhoneNumber;

    }
    #endregion
    #region AccountBalance
    public string AccountBalanceValidation(decimal amount, string[] AccountData)
    {
        BankAccount bankAccount = new BankAccount(AccountData);
        decimal balanceF = bankAccount.AccountCredit(amount);
        return balanceF.ToString();
    }
    #endregion
    #region NameBanks
    public string NameBanksValidation()
    {
        string nambeBanks;
        while (true)
        {
            Console.Clear();
            Console.Write("Ingrese el nombre de su banco: ");
            nambeBanks = Console.ReadLine() ?? string.Empty;
            if (nambeBanks == "")
            {
                Console.WriteLine("Debe ingresar un valor.");
            }
            else
            {
                break;
            }
            Console.ReadKey();
        }
        return nambeBanks;
    }
    #endregion
    #region Transfers
    public string AmountTransfers(string badges)
    {
        string amountTransfers;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ingrese la cantidad que desea transferir: ");
            amountTransfers = Console.ReadLine() ?? string.Empty;
            if (decimal.TryParse(amountTransfers, out decimal amountTransfersValor))
            {
                if (badges == "Quetzales")
                {
                    amountTransfers = amountTransfersValor.ToString();
                    break;
                }
                else if (badges == "Dolares")
                {
                    amountTransfers = (amountTransfersValor * 8).ToString();
                    break;
                }

            }
            else
            {
                Console.WriteLine("El ingreso debe ser un valor numerico");
            }
            Console.ReadKey();
        }
        return amountTransfers;
    }
    #endregion
    #region Badges
    public string BadgesValidation()
    {
        string badges;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("A continuacion ingrese los datos solicitados.");
            Console.WriteLine("1.Dolares.\n2.Quetzales.");
            Console.Write("Seleccione la divisa para la transaccion: ");
            badges = Console.ReadLine() ?? string.Empty;
            if (badges == "")
            {
                Console.WriteLine("Debe ingresar un valor");
                Console.ReadKey();
            }
            else
            {
                int.TryParse(badges, out int badgesInt);
                if (badgesInt > 0 && badgesInt < 5)
                {
                    badges = switchCase3(badgesInt);
                    break;
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es una opcion valida");
                    Console.ReadKey();
                }
            }
        }
        return badges;
    }
    public static string switchCase3(int badgesInt)
    {
        string badges;
        switch (badgesInt)
        {
            case 1:
                badges = "Dolares";
                break;

            case 2:
                badges = "Quetzales";
                break;

            default:
                Console.Clear();
                Console.WriteLine("Opcion invalida");
                Console.ReadKey();
                badges = "";
                break;
        }
        return badges;

    }

    #endregion

    #region Supplier
    public string switchCase4(int proveedorInt, string[] proveedores)
    {
        string proveedor;
        switch (proveedorInt)
        {
            case 1:
                proveedor = proveedores[proveedorInt - 1];
                break;
            case 2:
                proveedor = proveedores[proveedorInt - 1];
                break;
            case 3:
                proveedor = proveedores[proveedorInt - 1];
                break;
            default:
                Console.WriteLine("Opcion invalida");
                break;
        }
        return "";
    }
    #endregion


}