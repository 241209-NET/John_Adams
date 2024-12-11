using System.Security.Cryptography;
using Microsoft.VisualBasic;


namespace MiniProjectWeek1;

class Program
{
    struct Enemy
    {
        int _health, _attack, _xp;
        string _name;
        List<string> names = ["Slime", "Ork", "Goblin", "Bear", "Wolf"];
        Random rand = new Random();
        public Enemy()
        {
            _health = rand.Next(1,15);
            _attack = rand.Next(1,5);
            _xp = rand.Next(1,5);
            _name = names[rand.Next(names.Capacity)];
        }
        public int Health {get {return _health;} set {_health = value;}}
        public int Attack {get {return _attack;} set {_attack = value;}}

        public int XP {get {return _xp;} set {_xp = value;}}
        public string Name {get {return _name;} set {_name = value;}}
    }
    static void Main(string[] args)
    {
        int menuChoice;
        //Bool for testing exit
        bool run = true;
        //String for answer parts
        string response = "";
        //Menu
        string[] mainMenu = { "1: Show Stats",
                  "2: Fight Next Enemy",
                  "3: Spend XP",
                  "4: Exit"};

        Utilities.ReadString("Enter your name: ", ref response!);
        Player p = new(response!);
        while (run)
        {
            Utilities.ReadChoice("Choice: ", mainMenu, out menuChoice);
            switch (menuChoice)
            {
                case 1:
                    Utilities.ShowStats(p);
                    break;
                case 2:
                    Fight(true, p, ref run);
                    break;
                case 3:
                    SpendXP(true, p);
                    break;
                case 4:
                    Console.Clear();
                    run = false;
                    break;
            }
        }
    }

    static void Fight(bool fightrun, Player p, ref bool run)
    {
        Console.Clear();
        int fightChoice;
        string[] fightMenu = { "1: Attack",
                  "2: Block",
                  "3: Run Away"};
        fightrun = true;
        Enemy e = new Enemy();
        while (fightrun)
        {
            Console.Clear();
            Console.Write($"Name: {p.Name} XP: {p.XP}\t\t\tName: {e.Name} \nHP: {p.Health} Attack: {p.Attack}");
            Console.WriteLine($"\t\tHP: {e.Health} Attack: {e.Attack}");
            Utilities.ReadChoice("Choice: ", fightMenu, out fightChoice);
            switch (fightChoice)
            {
                case 1:
                    //Attack player takes damage
                    //Enemy Takes Damage
                    p.Health -= e.Attack;
                    e.Health -= p.Attack;

                    //End fight
                    if (e.Health <= 0 && p.Health <= 0)
                    {
                        Console.WriteLine("You and the enemy both died! You finished with these stats:");
                        Console.WriteLine($"Name: {p.Name} XP: {p.XP}\nHP: {p.Health} Attack: {p.Attack}");
                        break;
                    }
                    if (e.Health <= 0)
                    {
                        p.XP += e.XP;
                        Console.WriteLine($"You Won the fight! You have added {e.XP} XP!");
                        fightrun = false;
                    }
                    if (p.Health <= 0)
                    {
                        Console.WriteLine("You died! You finished with these stats:");
                        Console.WriteLine($"Name: {p.Name} XP: {p.XP}\nHP: {p.Health} Attack: {p.Attack}");
                        fightrun = false;
                        run = false;
                    }
                    break;
                case 2:
                    //Player does not take damage
                    Console.WriteLine("You blocked the attack.");
                    break;
                case 3:
                    Console.Clear();
                    fightrun = false;
                    break;
            }
        }
    }

    static void SpendXP(bool spendrunning, Player p)
    {
        string[] xpMenu = { "1: Add 10 Health",
                  "2: Add 1 Attack",
                  "3: Exit"};
        int spendChoice;
        Console.Clear();
        spendrunning = true;
        while (spendrunning)
        {
            if (p.XP <= 0)
            {
                Console.WriteLine("You are out of XP");
                spendrunning = false;
            }
            else
            {
                Utilities.ReadChoice("Choice: ", xpMenu, out spendChoice);
                switch (spendChoice)
                {
                    case 1:
                        p.Health += 10;
                        p.XP -= 1;
                        Console.WriteLine("You have added 10 Health.");
                        break;
                    case 2:
                        p.Attack += 1;
                        p.XP -= 1;
                        Console.WriteLine("You have added 1 Attack.");
                        break;
                    case 3:
                        spendrunning = false;
                        break;
                }
            }
        }
    }

    
}
