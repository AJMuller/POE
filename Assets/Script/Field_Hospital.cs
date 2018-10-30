using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


    public class Field_Hospital : Building
    {
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }



        public int XPos
        {
            get { return base.xPoS; }
            set { base.xPoS = value; }
        }


        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }

        public int Faction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }


        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }



        private int HealPerGameTick;

        public int healPerGameTick
        {
            get { return HealPerGameTick; }
            set { HealPerGameTick = value; }
        }



        void HealingCloseUnits()
        {

        }


        public Field_Hospital(int health, int xPos, int yPos, int faction, string symbol)
        {
            Health = health;
            XPos = xPos;
            YPos = yPos;
            Faction = faction;
            Symbol = symbol;


        }// constructor

        public override void Fight(int attack)
        {
            Health -= attack;


        } // works out new health value

        

        public override bool IsDestroyed()
        {
            if (health > 0)
            {
                return true;
            }//end if
            else
            {
                return false;
            }//end else

        }// checks if health is 0 or below 

        public override string ToString()
        {
             return "HP: " + Health;
        }// creates a string

        public override void Save()
        {

            using (StreamWriter rbsw = new StreamWriter("Field_Hospital.txt", true))
            {
                try
                {

                    rbsw.WriteLine(ToString());

                }//end try
                catch //(Exception e)
                {
                   // MessageBox.Show(("Exception: " + e.Message));

                }//end catch

            }//end using

        }// writes information of object to textfile


    }

