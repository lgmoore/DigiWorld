/*using System;
namespace DigiWorld
{
    public class CommandProcessor
    {
        private Shop _shop;
        private Player _player;

        public Shop DigimonStore
        {
            get
            {
                return _shop;
            }
        }

        public CommandProcessor(Player player)
        {
            _shop = new Shop();
            _player = player;
        }
        public string Execute(string[] text)
        {
            switch (text[0])
            {
                case "view":
                    return View(text);
                case "inspect":
                    return Inspect(text);
                case "buy":
                case "purchase":
                    return Buy(text);
                case "digivolve":
                    return Digivolve(text);
                case "battle":
                    return Battle(text);
                default:
                    return "Unknown Command";
            }
        }

        public string View(string[] text)
        {
            switch (text[1])
            {
                case "shop":
                    return DigimonStore.PrintShopList();
                case "me":
                case "player":
                    return _player.PrintPlayerDetails();
                case "digimon":
                case "collection":
                    return _player.PrintDigimonCollection();
                default:
                    return "Unknown Command";
            }
        }

        public string Inspect(string[] text)
        {
            if (text.Length != 3)
            {
                return "What would you like to inspect?";
            }
            List<Digimon> targetList;
            switch (text[1])
            {
                case "shop":
                    targetList = DigimonStore.ShopList;
                    break;
                case "my":
                case "digimon":
                    targetList = _player.DigimonCollection;
                    break;
                default:
                    return "Unknown Command";
            }
            Digimon? digimon = FindDigimon(targetList, text[2]);
            if (digimon == null)
            {
                return "Digimon not found";
            }
            else
            {
                string details = digimon.FullDetails;
                if (text[1] == "shop")
                {
                    details += "\tCost: " + digimon.Cost + "C";
                }
                return details;
            }
        }

        public static Digimon? FindDigimon(List<Digimon> list, string key)
        {
            List<Digimon> foundDigimon = list.Where(digimon => digimon.Name.Equals(key)).ToList();

            if (foundDigimon.Count > 1)
            {
                while (true)
                {
                    Console.WriteLine("Which " + key + "?");
                    foreach (Digimon d in foundDigimon)
                    {
                        Console.WriteLine("#" + (foundDigimon.IndexOf(d) + 1) + " - " + d.Name + " " + d.ShortStats);
                    }
                    string? input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        continue;
                    }
                    if (input == "exit" || input == "cancel")
                    {
                        return null;
                    }
                    input = input.Replace("#", string.Empty);
                    int i = int.Parse(input);
                    if (foundDigimon[i - 1] == null)
                    {
                        Console.WriteLine("Unknown input");
                        continue;
                    }
                    else
                    {
                        return foundDigimon[i - 1];
                    }
                }
            }
            else
            {
                if (foundDigimon.Count == 1)
                {
                    return foundDigimon.First();
                }
                return null;
            }
        }

        public string Buy(string[] text)
        {
            Digimon? digimon = FindDigimon(DigimonStore.ShopList, text[1]);
            if (digimon == null)
            {
                return "Digimon not found";
            }
            else
            {
                if (digimon.Cost > _player.Coins)
                {
                    return "You cannot afford that Digimon\nYou have " + _player.Coins + "C";
                }
                _player.DigimonCollection.Add(digimon);
                _player.Coins -= digimon.Cost;

                string answer = Program.PromptInput("Would you like to name your " + digimon.Name + "?");
                if (answer == "y" || answer == "yes")
                {
                    digimon.Name = Program.PromptInput(digimon.Name + " name:");
                }

                return digimon.LongName + " purchased for " + digimon.Cost + "C\n" + digimon.Name + " added to your collection";
            }
        }

        public string Digivolve(string[] text)
        {
            Digimon? digimon = FindDigimon(_player.DigimonCollection, text[1]);
            if (digimon == null)
            {
                return "Digimon not found";
            }
            else
            {
                int cost = digimon.DigivolutionCost;
                if (cost > _player.Energy)
                {
                    return "You do not have enough Energy to Digivolve that Digimon\nYou have " + _player.Energy + " Energy";
                }
                return digimon.Digivolve(_player);
            }
        }

        public string Battle(string[] text)
        {
            if (text.Length < 2)
            {
                return "What would you like to battle? eg. random, digimon name, level 1";
            }

            Digimon? targetDigimon;
            Digimon? myDigimon;

            switch (text[1])
            {
                case "random":
                    Species speciesToGenerate;
                    if (text.Length > 2 && int.TryParse(text[2], out int rank))
                    {
                        if (rank > 4 || rank < 1)
                        {
                            return "Rank number must be 1 to 4";
                        }
                        speciesToGenerate = SpeciesLibrary.Instance.GetRandomSpecies(rank);
                    }
                    else
                    {
                        // Generate a random digimon of rank 1-3
                        speciesToGenerate = SpeciesLibrary.Instance.GetRandomSpecies((new Random()).Next(1, 3));
                    }
                    targetDigimon = speciesToGenerate.GenerateDigimon();
                    break;
                default:
                    targetDigimon = FindDigimon(_player.DigimonCollection, text[1]);
                    break;
            }
            if (targetDigimon == null)
            {
                return "Target not found";
            }

            Console.WriteLine(_player.PrintDigimonCollection());
            while (true)
            {
                string? input = Program.PromptInput("Select a Digimon");
                if (input == "exit" || input == "cancel")
                {
                    return "";
                }
                myDigimon = FindDigimon(_player.DigimonCollection, input);
                if (myDigimon == null)
                {
                    Console.WriteLine("Digimon not found");
                }
                else
                {
                    break;
                }
            }

            Battle battle = new Battle(myDigimon, targetDigimon);
            int battleResult = battle.Init();
            switch (battleResult)
            {
                case 1:
                    Console.WriteLine(myDigimon.LongName + " was victorious!");

                    // Handle battle rewards
                    switch (text[1])
                    {
                        case "random":
                            int coins = targetDigimon.Species.Rank * 2;
                            _player.Coins += coins;
                            ++_player.Victories;
                            ++myDigimon.Victories;
                            return "You won " + coins + " coins!";
                        default:
                            return "";
                    }
                case 2:
                    return myDigimon.LongName + " was defeated by " + targetDigimon.LongName;
                case 3:
                    Console.WriteLine("Battle was a draw. No Digimon won.");
                    _player.Coins += 1;
                    return "You won a coin";
                case 0:
                default:
                    return "Abort. Error occurred in battle.";
            }
        }
    }
}*/