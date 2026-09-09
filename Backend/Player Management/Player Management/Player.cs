using System;
using System.Collections.Generic;
using System.Text;

namespace Player_Management
{
    internal class Player
    {
        int jerseyno;
        string name;
        int match;
        int run;
        int wicket;

        public int JerseyNo
        {
            get { return jerseyno; }
            set { jerseyno = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Match
        {
            get { return match; }
            set { match = value; }
        }

        public int Run
        {
            get { return run; }
            set { run = value; }
        }

        public int Wicket
        {
            get { return wicket; }
            set { wicket = value; }
        }

        public Player()
        {
        }
        public Player(int jerseyno, string name, int match, int run, int wicket)
        {
            this.jerseyno = jerseyno;
            this.name = name;
            this.match = match;
            this.run = run;
            this.wicket = wicket;
        }


    }
}
