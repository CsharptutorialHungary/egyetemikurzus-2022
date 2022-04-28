using Szalloda.UI;
using Szalloda.AppBack;
using Szalloda.Data;

InitData.InitializeData();

AppUI.Welcome();
// használhatjuk a validator-t, de string-eknél nem szükséges.
// string username = Validator.Convert<string>("username");
string username = Utility.GetUserInput("username");
Console.WriteLine(username);

// hides the password
System.Console.Write("password: ");
string password = null;
while (true)
{
    var key = System.Console.ReadKey(true);
    if (key.Key == ConsoleKey.Enter)
        break;
    password += key.KeyChar;
}
