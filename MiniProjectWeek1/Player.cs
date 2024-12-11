using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectWeek1
{
    internal class Player
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
        public int Health { get { return _health; } set { _health = value; } }
        public int Attack { get { return _attack; } set { _attack = value; } }

        public int XP { get { return _xp; } set { _xp = value; } }
        public string Name { get { return _name; } set { _name = value; } }
    }
}
