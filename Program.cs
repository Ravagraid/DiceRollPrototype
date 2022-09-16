// See https://aka.ms/new-console-template for more information
DiceRollPrototype.DicePool d = new();
Console.WriteLine("Please enter the number of dice:");
int dicenum = Convert.ToInt16(Console.ReadLine());
d.RollPool(dicenum,1);
PrintResults();

void PrintResults() {
    string[] ResultName = new string[] {"Blanks", "Counters", "Heavy Counters",
                                        "Hits", "Heavy Hits", "Exploding Hits" };
    Console.Write("\n\n");
    //Loop through Dictionary to display results
    Console.WriteLine("Results from dice pool");
    foreach (var item in d.Results) {
        Console.WriteLine($"{ResultName[item.Key - 1] + ":",-18}{item.Value}");
        //Loop through Exploding Dictionary for Ex Dice results
        if (item.Key == 6) {
            Console.WriteLine("\nResults from Exploding Hits.");
            for (int i = 0; i < 3; i++) {
                Console.WriteLine($"{ResultName[i + 3] + ":",-18}{d.ExResults[i + 4]}");
            }
            //Display total hits
            Console.WriteLine($"\nTotal Hits: {d.TotalHits,7}");
            Console.WriteLine(d.Sustained(d.Results));
        }
    }
}
//Notes: Need to account for the following scenarios
//NORMAL: 10.005729 
//SUSTAINED / HOMING: 11.663932 
//FUSILLADE / SUSTAINED AND HOMING: 13.333718 
//DEVASTATING: 11.999949
//NORMAL_VS_OBSCURED: 8.33679
//FUSILLADE / SUSTAINED AND HOMING_VS_OBSCURED: 11.112327
//SUSTAINED / HOMING_VS_OBSCURED: 12.500344
//DEVASTATING_VS_OBSCURED: 8.332204