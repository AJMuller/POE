using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


    public class Map
    {
        Random r = new Random();
        private Unit[] units;



        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }

        private Building[] buildings;

        public Building[] Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }



        public Map(int maxX, int maxY, int numUnits, int numBuildings)
        {
            units = new Unit[numUnits];
            int count = 0;
            for (int i = 0; i < numUnits / 5; i++) // creates 
            {


                Melee_Unit m = new Melee_Unit("knight", r.Next(0, maxX),
                    r.Next(0, maxY),
                    100,
                    r.Next(5, 10),
                        1,
                        1,
                        i % 2,
                        "M");
                units[count] = m;
                count++;

                Ranged_Unit ranged = new Ranged_Unit("knight", r.Next(0, maxX),
                   r.Next(0, maxY),
                    100,
                    r.Next(5, 10),
                        1,
                        1,
                        i % 2,
                        "R");
                units[count] = ranged;
                count++;

                Tank t = new Tank("Cruiser", r.Next(0, maxX),
                   r.Next(0, maxY),
                    100,
                    r.Next(10, 20),
                        1,
                        1,
                        i % 2,
                        "T");
                units[count] = t;
                count++;

                Helicopter h = new Helicopter("Boeing", r.Next(0, maxX),
                   r.Next(0, maxY),
                    100,
                    r.Next(10, 20),
                        1,
                        1,
                        i % 2,
                        "H");
                units[count] = h;
                count++;

                Fighter_Jets f = new Fighter_Jets("Boeing", r.Next(0, maxX),
                   r.Next(0, maxY),
                    100,
                    r.Next(10, 20),
                        1,
                        1,
                        i % 2,
                        "J");
                units[count] = f;
                count++;



            }//end for

            count = 0;
            buildings = new Building[numBuildings];
            for (int i = 0; i < numBuildings / 4; i++)
            {
                FactoryBuilding fb = new FactoryBuilding
                    (100, r.Next(0, maxX), r.Next(0, maxY), i % 2, "F");

                buildings[count] = fb;
                count++;

                ResourceBuilding rb = new ResourceBuilding
                    (100, r.Next(0, maxX), r.Next(0, maxY), i % 2, "S");

                buildings[count] = rb;
                count++;

                Field_Hospital fh = new Field_Hospital
                    (100, r.Next(0, maxX), r.Next(0, maxY), i % 2, "+");

                buildings[count] = fh;
                count++;

                Weapon_Upgrade wu = new Weapon_Upgrade
                    (100, r.Next(0, maxX), r.Next(0, maxY), i % 2, "^^");

                buildings[count] = wu;
                count++;

            }//end for










        }//makes objects and generates values for these objects

        public void Read(int numUnits, int numBuildings)
        {
            int counter = 0;



            string[] stringArray = File.ReadAllLines("MeleeUnit.txt");
            units = new Unit[numUnits];

            foreach (string line in stringArray)
            {
                if (line != "")
                {

                    Melee_Unit m = new Melee_Unit(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[6]),
                    Convert.ToInt32(line.Split(',')[5]),
                    Convert.ToInt32(line.Split(',')[4]),
                    Convert.ToInt32(line.Split(',')[7]),
                    line.Split(',')[8]);
                    counter++;
                    units[counter - 1] = m;

                }//end if



            }//end foreach


            string[] rstringArray = File.ReadAllLines("RangedUnit.txt");

            foreach (string line in rstringArray)
            {
                if (line != "")
                {


                    Ranged_Unit m = new Ranged_Unit(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[6]),
                    Convert.ToInt32(line.Split(',')[5]),
                    Convert.ToInt32(line.Split(',')[4]),
                    Convert.ToInt32(line.Split(',')[7]),
                    line.Split(',')[8]);
                    counter++;
                    units[counter - 1] = m;
                } //end if 

            }// end foreach

            string[] TtringArray = File.ReadAllLines("Tank.txt");

            foreach (string line in TtringArray)
            {
                if (line != "")
                {


                    Tank m = new Tank(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[6]),
                    Convert.ToInt32(line.Split(',')[5]),
                    Convert.ToInt32(line.Split(',')[4]),
                    Convert.ToInt32(line.Split(',')[7]),
                    line.Split(',')[8]);
                    counter++;
                    units[counter - 1] = m;
                } //end if 

            }// end foreach

            string[] hstringArray = File.ReadAllLines("Helicopter.txt");

            foreach (string line in hstringArray)
            {
                if (line != "")
                {


                    Helicopter m = new Helicopter(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[6]),
                    Convert.ToInt32(line.Split(',')[5]),
                    Convert.ToInt32(line.Split(',')[4]),
                    Convert.ToInt32(line.Split(',')[7]),
                    line.Split(',')[8]);
                    counter++;
                    units[counter - 1] = m;
                } //end if 

            }// end foreach

            string[] fjstringArray = File.ReadAllLines("Fighter_Jets.txt");

            foreach (string line in fjstringArray)
            {
                if (line != "")
                {


                    Fighter_Jets m = new Fighter_Jets(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[6]),
                    Convert.ToInt32(line.Split(',')[5]),
                    Convert.ToInt32(line.Split(',')[4]),
                    Convert.ToInt32(line.Split(',')[7]),
                    line.Split(',')[8]);
                    counter++;
                    units[counter - 1] = m;
                } //end if 

            }// end foreach



            int bcounter = 0;
            string[] fbstringArray = File.ReadAllLines("FactoryBuilding.txt");
            buildings = new Building[numBuildings];
            foreach (string line in fbstringArray)
            {
                if (line != "")
                {

                    FactoryBuilding m = new FactoryBuilding(Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[4]),
                    line.Split(',')[5]);

                    bcounter++;
                    buildings[bcounter - 1] = m;
                } //end if   

            }//end foreach


            string[] rbstringArray = File.ReadAllLines("ResourceBuilding.txt");


            foreach (string line in rbstringArray)
            {
                if (line != "")
                {


                    ResourceBuilding m = new ResourceBuilding(Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[4]),
                    line.Split(',')[5]);

                    bcounter++;
                    buildings[bcounter - 1] = m;
                }   //end if

            } //end foreach

            string[] fhstringArray = File.ReadAllLines("Field_Hospital.txt");


            foreach (string line in fhstringArray)
            {
                if (line != "")
                {


                    Field_Hospital m = new Field_Hospital(Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[4]),
                    line.Split(',')[5]);

                    bcounter++;
                    buildings[bcounter - 1] = m;
                }   //end if

            } //end foreach

            string[] wustringArray = File.ReadAllLines("Weapon_Upgrade.txt");


            foreach (string line in wustringArray)
            {
                if (line != "")
                {


                    Weapon_Upgrade m = new Weapon_Upgrade(Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[4]),
                    line.Split(',')[5]);

                    bcounter++;
                    buildings[bcounter - 1] = m;
                }   //end if

            } //end foreach




        } // reads from textfile and creates objects with the values from the textfile


    }

