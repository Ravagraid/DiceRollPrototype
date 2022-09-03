// See https://aka.ms/new-console-template for more information
DiceRolePrototype.DiceRoller d = new();

Console.WriteLine("Enter the number of dice:");
int num = Convert.ToInt16(Console.ReadLine());
Console.WriteLine($"Normal Hits:    {Indent(11)}{d.Roll(num,1)}");
Console.WriteLine($"With Sustained Or Homing: {Indent(1)}{d.Roll(num,2)}");
Console.WriteLine($"With Fusillade: {Indent(11)}{d.Roll(num,3)}");
Console.WriteLine("Press any key to close the program.");
Console.ReadKey();

static string Indent(int count) {
    return "".PadLeft(count);
}
//Notes: Need to account for the following scenarios
//NORMAL: 10.005729  - Done
//SUSTAINED / HOMING: 11.663932 - Done
//FUSILLADE / SUSTAINED AND HOMING: 13.333718 - Done
//DEVASTATING: 11.999949
//NORMAL_VS_OBSCURED: 8.33679
//FUSILLADE / SUSTAINED AND HOMING_VS_OBSCURED: 11.112327
//SUSTAINED / HOMING_VS_OBSCURED: 12.500344
//DEVASTATING_VS_OBSCURED: 8.332204