using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



    public abstract class Building
    {
        protected int xPoS, yPos, health, faction;
        protected string symbol;

        public Building()
        {

        }

        abstract public void Save();
        abstract public bool IsDestroyed();
        abstract public string ToString();
        abstract public void Fight(int attack);
        



    }

