using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


    public class Tank : Unit
    {
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }

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


        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }


        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }


        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
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

        public override void MovePos(Direction d)
        {
            switch (d)
            {
                case Direction.North:
                    {

                        YPos -= Speed;
                        if (YPos < 1)
                        {
                            YPos += Speed;
                        }

                        break;
                    }//end case
                case Direction.East:
                    {
                        XPos += Speed;
                        if (XPos > 20)
                        {
                            XPos -= Speed;
                        }
                        break;
                    }//end case
                case Direction.South:
                    {
                        YPos += Speed;
                        if (YPos > 20)
                        {
                            YPos -= Speed;
                        }
                        break;
                    }//end case
                case Direction.West:
                    {
                        XPos -= Speed;
                        if (XPos < 1)
                        {
                            XPos += Speed;
                        }
                        break;
                    }//end case
            }//end switch 

        } //// works out new x and y positions //Changed to make sure no units leave square 

        public override void Fight(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Health -= ((Melee_Unit)u).Attack;
            }// end if
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Health -= ((Ranged_Unit)u).Attack;
            }//end else if
            else if (u.GetType() == typeof(Tank))
            {
                Health -= ((Tank)u).Attack;
            }//end else if
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                Health -= ((Fighter_Jets)u).Attack;
            }//end else if
            else if (u.GetType() == typeof(Helicopter))
            {
                Health -= ((Helicopter)u).Attack;
            }//end else if

        } // works out new health value

        public override bool WithinRange(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                if (DistanceTo(u) <= AttackRange)
                {
                    return true;
                }//end if
                else
                {
                    return false;
                }//end else
            }//end if
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                if (DistanceTo(u) <= AttackRange)
                {
                    return true;
                }//end if
                else
                {
                    return false;
                }//end else
            }//end else if
            else if (u.GetType() == typeof(Tank))
            {
                if (DistanceTo(u) <= AttackRange)
                {
                    return true;
                }//end if
                else
                {
                    return false;
                }//end else
            }//end else if
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                if (DistanceTo(u) <= AttackRange)
                {
                    return true;
                }//end if
                else
                {
                    return false;
                }//end else

            }//end else if
            else if (u.GetType() == typeof(Helicopter))
            {
                if (DistanceTo(u) <= AttackRange)
                {
                    return true;
                }//end if
                else
                {
                    return false;
                }//end else

            }//end else if
            return false;


        }//works out if an object is close enough for attack

        public override Unit NearestUnit(Unit[] units)
        {
            Unit closest = this;
            int closestDistance = 50;
            foreach (Unit u in units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    if (!(((Melee_Unit)u).Faction == Faction))
                    {
                        if (DistanceTo((Melee_Unit)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Melee_Unit)u);
                        }//end if
                    }//end if



                }//end if
                else if (u.GetType() == typeof(Ranged_Unit))
                {
                    if (!(((Melee_Unit)u).Faction == Faction))
                    {
                        if (DistanceTo((Ranged_Unit)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Ranged_Unit)u);
                        }//end if
                    }
                }//end else if
                else if (u.GetType() == typeof(Tank))
                {
                    if (!(((Tank)u).Faction == Faction))
                    {
                        if (DistanceTo((Tank)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Tank)u);
                        }//end if
                    }
                }//end else if
                else if (u.GetType() == typeof(Fighter_Jets))
                {
                    if (!(((Fighter_Jets)u).Faction == Faction))
                    {
                        if (DistanceTo((Fighter_Jets)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Fighter_Jets)u);
                        }//end if
                    }
                }//end else if
                else if (u.GetType() == typeof(Helicopter))
                {
                    if (!(((Helicopter)u).Faction == Faction))
                    {
                        if (DistanceTo((Helicopter)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Helicopter)u);
                        }//end if
                    }
                }//end else if

            }//end foreach
            return closest;

        }//works out closest unit


        public override bool IsDeath()
        {

            if (Health <= 0)
            {
                return true;


            }//end if
            else
            {
                return false;
            }//end else
        }//works out if an object is out of health

        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;
            }//end if
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Ranged_Unit m = (Ranged_Unit)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;
            }//end else if
            else if (u.GetType() == typeof(Tank))
            {
                Tank m = (Tank)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;
            }//end else
            else if (u.GetType() == typeof(Helicopter))
            {
                Helicopter m = (Helicopter)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;
            }//end else
            else
            {
                Fighter_Jets m = (Fighter_Jets)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;
            }//end else
        }//works out distance from one unit to another

        public Tank(string name, int y, int x, int hp, int attack, int range, int speed, int faction, string symbol)
        {
            Name = name;
            XPos = x;
            YPos = y;
            Health = hp;
            Speed = speed;
            AttackRange = range;
            Attack = attack;
            Faction = faction;
            Symbol = symbol;
        }//constructor 

        

        public override string ToString()
        {
              return "HP: " + Health;
        }// to string

        public Direction DirectionTo(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;
                if (m.XPos < XPos)
                {
                    return Direction.North;

                }//end if
                else if (m.XPos > XPos)
                {
                    return Direction.South;
                }//end else if
                else if (m.YPos < YPos)
                {
                    return Direction.West;
                }//end else if
                else
                {
                    return Direction.East;

                }//end else
            }//end if

            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Ranged_Unit m = (Ranged_Unit)u;
                if (m.XPos < XPos)
                {
                    return Direction.North;

                }//end if
                else if (m.XPos > XPos)
                {
                    return Direction.South;
                }//end else if
                else if (m.YPos < YPos)
                {
                    return Direction.West;
                }//end else if
                else
                {
                    return Direction.East;

                }//end else
            }//end else if
            else if (u.GetType() == typeof(Tank))
            {
                Tank m = (Tank)u;
                if (m.XPos < XPos)
                {
                    return Direction.North;

                }//end if
                else if (m.XPos > XPos)
                {
                    return Direction.South;
                }//end else if
                else if (m.YPos < YPos)
                {
                    return Direction.West;
                }//end else if
                else
                {
                    return Direction.East;

                }//end else
            }//end else if
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                Fighter_Jets m = (Fighter_Jets)u;
                if (m.XPos < XPos)
                {
                    return Direction.North;

                }//end if
                else if (m.XPos > XPos)
                {
                    return Direction.South;
                }//end else if
                else if (m.YPos < YPos)
                {
                    return Direction.West;
                }//end else if
                else
                {
                    return Direction.East;

                }//end else
            }//end else if
            else
            {
                Helicopter m = (Helicopter)u;
                if (m.XPos < XPos)
                {
                    return Direction.North;

                }//end if
                else if (m.XPos > XPos)
                {
                    return Direction.South;
                }//end else if
                else if (m.YPos < YPos)
                {
                    return Direction.West;
                }//end else if
                else
                {
                    return Direction.East;

                }//end else
            }//end else if

        }// works out direction of movement 

        public override void Save()
        {
            using (StreamWriter sw = new StreamWriter("Tank.txt", true))
            {
                try
                {
                    sw.WriteLine(ToString());

                }//end try
                catch
                {
                    //MessageBox.Show("file does not exist.");


                }//end catch

            }//end using







        }// writes information of object to textfile
    }

