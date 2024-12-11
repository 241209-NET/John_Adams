using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace MiniProjectWeek1;

class Program
{
    struct Player
    {
        int _health, _attack, _xp;
        string _name;

        public Player()
        {
            _health = 10;
            _attack = 1;
            _xp = 10;
            _name = "Bob";
        }
        public Player(string name)
        {
            _health = 10;
            _attack = 1;
            _xp = 10;
            _name = name;
        }
        public int Health {get {return _health;} set {_health = value;}}
        public int Attack {get {return _attack;} set {_attack = value;}}

        public int XP {get {return _xp;} set {_xp = value;}}
        public string Name {get {return _name;} set {_name = value;}}
    }

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
        int menuChoice, fightChoice, spendChoice;
        //Bool for testing exit
        bool run = true, fightrun = true, spendrunning = true;
        //String for answer parts
        string response = "";
        //Menu
        string[] mainMenu = { "1: Show Stats",
                  "2: Fight Next Enemy",
                  "3: Spend XP",
                  "4: Exit"};

        string[] fightMenu = { "1: Attack",
                  "2: Block",
                  "3: Run Away"};

        string[] xpMenu = { "1: Add 10 Health",
                  "2: Add 1 Attack",
                  "3: Exit"};

        ReadString("Enter your name: ", ref response);
        Player p = new Player(response);


        while (run)
        {
        ReadChoice("Choice: ", mainMenu, out menuChoice);
        switch (menuChoice)
        {
            case 1:
                Console.WriteLine($"Name: {p.Name} XP: {p.XP}\nHP: {p.Health} Attack: {p.Attack}");
                break;
            case 2:
                Console.Clear();
                fightrun = true;
                Enemy e = new Enemy();
                while(fightrun)
                {
                    Console.Clear();
                    Console.Write($"Name: {p.Name} XP: {p.XP}\t\t\tName: {e.Name} \nHP: {p.Health} Attack: {p.Attack}");
                    Console.WriteLine($"\t\tHP: {e.Health} Attack: {e.Attack}");
                    ReadChoice("Choice: ", fightMenu, out fightChoice);
                    switch(fightChoice)
                    {
                        case 1:
                            //Attack player takes damage
                            //Enemy Takes Damage
                            p.Health -= e.Attack;
                            e.Health -= p.Attack;
                           
                            //End fight
                            if(e.Health <= 0 && p.Health <= 0)
                            {
                                Console.WriteLine("You and the enemy both died! You finished with these stats:");
                                Console.WriteLine($"Name: {p.Name} XP: {p.XP}\nHP: {p.Health} Attack: {p.Attack}");
                                break;
                            }
                            if(e.Health <=0)
                            {
                                p.XP += e.XP;
                                Console.WriteLine($"You Won the fight! You have added {e.XP} XP!");
                                fightrun = false;
                            }
                            if(p.Health <= 0)
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
                break;
            case 3:
                Console.Clear();
                while(spendrunning)
                {
                    if(p.XP <= 0)
                    {
                        Console.WriteLine("You are out of XP");
                        spendrunning = false;
                    }
                    else
                    {
                        ReadChoice("Choice: ", xpMenu, out spendChoice);
                        switch(spendChoice)
                        {
                            case 1:
                                p.Health += 10;
                                Console.WriteLine("You have added 10 Health.");
                                break;
                            case 2:
                                p.Attack += 1;
                                Console.WriteLine("You have added 1 Attack.");
                                break;
                            case 3:
                                spendrunning = false;
                                break;
                        }
                    }
                }
                break;
            case 4:
                Console.Clear();
                run = false;
                break;
    }
}
    }

    public static int ReadInteger(string prompt, int min, int max)
    {
        int result = 0;
        Console.Write(prompt);
        while(!int.TryParse(Console.ReadLine(), out result) || (result<min || result>max))
        {
            Console.WriteLine("That is not a valid number. Please try again...");
            Console.Write(prompt);
        }

        return result;
    }
    public static void ReadString(string prompt, ref string? value)
    {
        Console.Write(prompt);
        value = Console.ReadLine();
        while (String.IsNullOrEmpty(value))
        {
            Console.WriteLine("The response can not be blank...");
            Console.Write(prompt);
            value= Console.ReadLine();
        }
    }
    public static void ReadChoice(string prompt, string[] options, out int selection)
    {
        selection = 0;
        foreach(string option in options)
        {
            Console.WriteLine(option);
        }
        Console.WriteLine();
        selection = ReadInteger(prompt, 1, options.Length);
    }
}
