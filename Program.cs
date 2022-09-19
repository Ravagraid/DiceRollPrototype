// See https://aka.ms/new-console-template for more information
DiceRollPrototype.ResultGenerator rg = new DiceRollPrototype.ResultGenerator();

string[] ModifierChoices = new string[] { "1 - Normal" };    

string modifier = "Normal";
Console.WriteLine("Guide: For results with special rules enabled, type one of the following numbers;");
if (Console.ReadKey().Key == ConsoleKey.Enter) {
    modifier = "Normal";
} else {
    Console.ReadLine();
}
Console.WriteLine("Please enter the number of dice:");
int dicenum = Convert.ToInt16(Console.ReadLine());

rg.RollPool(dicenum);
rg.ModifierChecker(modifier);