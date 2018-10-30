
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Text;


public class POE_RTS : MonoBehaviour {

    public GameObject blueFactory;
    public GameObject redFactory;
    public GameObject blueFighterJet;
    public GameObject redFighterJet;
    public GameObject blueHeli;
    public GameObject redHeli;
    public GameObject blueHospital;
    public GameObject redHospital;
    public GameObject blueMelee;
    public GameObject redMelee;
    public GameObject blueRanged;
    public GameObject redRanged;
    public GameObject redSource;
    public GameObject bluesource;
    public GameObject blueTank;
    public GameObject redTank;
    public GameObject blueUpgrade;
    public GameObject redUpgrade;
    public GameObject death;

    // Use this for initialization
    public Map map = new Map(20, 20, 20, 8);
    const int START_X = 20;
    const int START_Y = 20;
    const int SPACING = 20;
    const int SIZE = 20;
    System.Random r = new System.Random();
    

    void Start () {
        DisplayMap(); 
        

    }

    

    private void DisplayMap()
    {
        GameObject[] unitList= GameObject.FindGameObjectsWithTag("unit");

        foreach(GameObject g in unitList)
        {
            Destroy(g);
        }

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                
                Melee_Unit m = (Melee_Unit)u;
                
                if (m.Faction == 1)
                {
                    Instantiate(redMelee, new Vector2(m.XPos,m.YPos ), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueMelee, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end else
                if (m.IsDeath())
                {
                    Instantiate(death, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end if

               
            }//end if 
            else if (u.GetType() == typeof(Ranged_Unit))
            {
               
                Ranged_Unit m = (Ranged_Unit)u;

                if (m.Faction == 1)
                {
                    Instantiate(redRanged, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueRanged, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end else
                if (m.IsDeath())
                {
                    Instantiate(death, new Vector2(m.XPos, m.YPos), Quaternion.identity);

                }//end if
            }//end else if
            else if (u.GetType() == typeof(Tank))
            {
                
                Tank m = (Tank)u;

                if (m.Faction == 1)
                {
                    Instantiate(redTank, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueTank, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end else
                if (m.IsDeath())
                {
                    Instantiate(death, new Vector2(m.XPos, m.YPos), Quaternion.identity);

                }//end if
            }//end else if
            else if (u.GetType() == typeof(Helicopter))
            {
                
                Helicopter m = (Helicopter)u;

                if (m.Faction == 1)
                {
                    Instantiate(redHeli, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueHeli, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end else
                if (m.IsDeath())
                {
                    Instantiate(death, new Vector2(m.XPos, m.YPos), Quaternion.identity);

                }//end if
            }//else if
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                Fighter_Jets m = (Fighter_Jets)u;

                if (m.Faction == 1)
                {
                    Instantiate(redFighterJet, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueFighterJet, new Vector2(m.XPos, m.YPos), Quaternion.identity);
                }//end else
                if (m.IsDeath())
                {
                    Instantiate(death, new Vector2(m.XPos, m.YPos), Quaternion.identity);

                }//end if
            }//end else if



        }//end for each 

        foreach (Building b in map.Buildings)
        {
            if (b.GetType() == typeof(FactoryBuilding))
            {
                
                FactoryBuilding fb = (FactoryBuilding)b;

                if (fb.Faction == 1)
                {
                    Instantiate(redFactory, new Vector2(fb.XPos, fb.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueFactory, new Vector2(fb.XPos, fb.YPos), Quaternion.identity);
                }//end else
                if (fb.isDeath())
                {
                    Instantiate(death, new Vector2(fb.XPos, fb.YPos), Quaternion.identity);

                }//end if

            }//end if
            else if (b.GetType() == typeof(ResourceBuilding))
            {
                
                ResourceBuilding rb = (ResourceBuilding)b;

                if (rb.Faction == 1)
                {
                    Instantiate(redSource, new Vector2(rb.XPos, rb.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(bluesource, new Vector2(rb.XPos, rb.YPos), Quaternion.identity);
                }//end else
                if (rb.isDeath())
                {
                    Instantiate(death, new Vector2(rb.XPos, rb.YPos), Quaternion.identity);

                }
            }//end else if
            else if (b.GetType() == typeof(Field_Hospital))
            {
               
                Field_Hospital fh = (Field_Hospital)b;

                if (fh.Faction == 1)
                {
                    Instantiate(redHospital, new Vector2(fh.XPos, fh.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueHospital, new Vector2(fh.XPos, fh.YPos), Quaternion.identity);
                }//end else
                if (fh.isDeath())
                {
                    Instantiate(death, new Vector2(fh.XPos, fh.YPos), Quaternion.identity);

                }
            }//end else if
            else if (b.GetType() == typeof(Weapon_Upgrade))
            {
                
                Weapon_Upgrade wu = (Weapon_Upgrade)b;

                if(wu.Faction == 1)
                {
                    Instantiate(redUpgrade, new Vector2(wu.XPos, wu.YPos), Quaternion.identity);
                }//end if
                else
                {
                    Instantiate(blueUpgrade, new Vector2(wu.XPos, wu.YPos), Quaternion.identity);
                }//end else
                if (wu.isDeath())
                {
                    Instantiate(death, new Vector2(wu.XPos, wu.YPos), Quaternion.identity);

                }//end if
            }//end else if



        }//end foreach
    }// creates new buttons for every unit and building saved in the arrays. each button is made to match the type of unit or building it is by changing colours and letters displayed on it.

    private void UpdateMap()
    {
        int distancebuild;
        foreach (Building b in map.Buildings)
        {
            if (b.GetType() == typeof(ResourceBuilding))
            {
                ResourceBuilding rb = (ResourceBuilding)b;
                foreach (Unit e in map.Units)
                {
                    if (e.GetType() == typeof(Melee_Unit))
                    {
                        Melee_Unit m = (Melee_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Ranged_Unit))
                    {
                        Ranged_Unit m = (Ranged_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Fighter_Jets))
                    {
                        Fighter_Jets m = (Fighter_Jets)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Helicopter))
                    {
                        Helicopter m = (Helicopter)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Tank))
                    {
                        Tank m = (Tank)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }


                }


            }
            else if (b.GetType() == typeof(FactoryBuilding))
            {
                FactoryBuilding rb = (FactoryBuilding)b;
                foreach (Unit e in map.Units)
                {
                    if (e.GetType() == typeof(Melee_Unit))
                    {
                        Melee_Unit m = (Melee_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Ranged_Unit))
                    {
                        Ranged_Unit m = (Ranged_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Fighter_Jets))
                    {
                        Fighter_Jets m = (Fighter_Jets)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Helicopter))
                    {
                        Helicopter m = (Helicopter)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Tank))
                    {
                        Tank m = (Tank)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }


                }


            }
            if (b.GetType() == typeof(Field_Hospital))
            {
                Field_Hospital rb = (Field_Hospital)b;
                foreach (Unit e in map.Units)
                {
                    if (e.GetType() == typeof(Melee_Unit))
                    {
                        Melee_Unit m = (Melee_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Ranged_Unit))
                    {
                        Ranged_Unit m = (Ranged_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Fighter_Jets))
                    {
                        Fighter_Jets m = (Fighter_Jets)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Helicopter))
                    {
                        Helicopter m = (Helicopter)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Tank))
                    {
                        Tank m = (Tank)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }


                }


            }
            if (b.GetType() == typeof(Weapon_Upgrade))
            {
                Weapon_Upgrade rb = (Weapon_Upgrade)b;
                foreach (Unit e in map.Units)
                {
                    if (e.GetType() == typeof(Melee_Unit))
                    {
                        Melee_Unit m = (Melee_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Ranged_Unit))
                    {
                        Ranged_Unit m = (Ranged_Unit)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Fighter_Jets))
                    {
                        Fighter_Jets m = (Fighter_Jets)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Helicopter))
                    {
                        Helicopter m = (Helicopter)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }
                    else if (e.GetType() == typeof(Tank))
                    {
                        Tank m = (Tank)e;


                        distancebuild = Math.Abs(rb.XPos - m.XPos) + Math.Abs(rb.YPos - m.YPos);

                        if (distancebuild <= m.AttackRange)
                        {
                            rb.Fight(m.Attack);
                        }

                    }


                }


            }
        }

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;
                
                if (m.Health < 25)
                {
                    switch (r.Next(0, 4))
                    {
                        case 0: m.MovePos(Direction.North); break;
                        case 1: m.MovePos(Direction.East); break;
                        case 2: m.MovePos(Direction.South); break;
                        case 3: m.MovePos(Direction.West); break;
                    }//end switch
                }//end if
                else
                {
                    bool inCombat = false;
                    foreach (Unit e in map.Units)
                    {

                        if (m.WithinRange(e))
                        {
                            m.Fight(e);
                            inCombat = true;
                        }//end if
                    }//end foreach
                    if (!inCombat)
                    {
                        Unit c = m.NearestUnit(map.Units);
                        m.MovePos(m.DirectionTo(c));
                    }//end if
                }//end else


            }//end if
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Ranged_Unit m = (Ranged_Unit)u;
                if (m.IsDeath())
                {
                    m.Symbol = "D";

                }//end if
                if (m.Health < 25)
                {
                    switch (r.Next(0, 4))
                    {
                        case 0: m.MovePos(Direction.North); break;
                        case 1: m.MovePos(Direction.East); break;
                        case 2: m.MovePos(Direction.South); break;
                        case 3: m.MovePos(Direction.West); break;
                    }//end switch
                }//end if
                else
                {
                    bool inCombat = false;
                    foreach (Unit e in map.Units)
                    {

                        if (m.WithinRange(e))
                        {
                            m.Fight(e);
                            inCombat = true;
                        }//end if 
                    }//end foreach
                    if (!inCombat)
                    {
                        Unit c = m.NearestUnit(map.Units);
                        m.MovePos(m.DirectionTo(c));
                    }//end if
                }//end else


            }//end else if 
            else if (u.GetType() == typeof(Tank))
            {
                Tank m = (Tank)u;
                if (m.IsDeath())
                {
                    m.Symbol = "D";

                }//end if
                if (m.Health < 25)
                {
                    switch (r.Next(0, 4))
                    {
                        case 0: m.MovePos(Direction.North); break;
                        case 1: m.MovePos(Direction.East); break;
                        case 2: m.MovePos(Direction.South); break;
                        case 3: m.MovePos(Direction.West); break;
                    }//end switch
                }//end if
                else
                {
                    bool inCombat = false;
                    foreach (Unit e in map.Units)
                    {

                        if (m.WithinRange(e))
                        {
                            m.Fight(e);
                            inCombat = true;
                        }//end if
                    }//end foreach
                    if (!inCombat)
                    {
                        Unit c = m.NearestUnit(map.Units);
                        m.MovePos(m.DirectionTo(c));
                    }//end if
                }//end else


            }//end else if
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                Fighter_Jets m = (Fighter_Jets)u;
                if (m.IsDeath())
                {
                    m.Symbol = "D";

                }//end if
                if (m.Health < 25)
                {
                    switch (r.Next(0, 4))
                    {
                        case 0: m.MovePos(Direction.North); break;
                        case 1: m.MovePos(Direction.East); break;
                        case 2: m.MovePos(Direction.South); break;
                        case 3: m.MovePos(Direction.West); break;
                    }//end switch
                }//end if
                else
                {
                    bool inCombat = false;
                    foreach (Unit e in map.Units)
                    {

                        if (m.WithinRange(e))
                        {
                            m.Fight(e);
                            inCombat = true;
                        }//end if
                    }//end foreach
                    if (!inCombat)
                    {
                        Unit c = m.NearestUnit(map.Units);
                        m.MovePos(m.DirectionTo(c));
                    }//end if
                }//end else


            }//end else if
            else if (u.GetType() == typeof(Helicopter))
            {
                Helicopter m = (Helicopter)u;
                if (m.IsDeath())
                {
                    m.Symbol = "D";

                }//end if
                if (m.Health < 25)
                {
                    switch (r.Next(0, 4))
                    {
                        case 0: m.MovePos(Direction.North); break;
                        case 1: m.MovePos(Direction.East); break;
                        case 2: m.MovePos(Direction.South); break;
                        case 3: m.MovePos(Direction.West); break;
                    }//end switch
                }//end if
                else
                {
                    bool inCombat = false;
                    foreach (Unit e in map.Units)
                    {

                        if (m.WithinRange(e))
                        {
                            m.Fight(e);
                            inCombat = true;
                        }//end if
                    }//end foreach
                    if (!inCombat)
                    {
                        Unit c = m.NearestUnit(map.Units);
                        m.MovePos(m.DirectionTo(c));
                    }//end if
                }//end else


            }//end else if
        }//end foreach
    }// updates the map by chaging values of units. calls movement methods and fight methods to change values in order for the map to change.

    // Update is called once per frame

    int turnCount= 0;
    void Update () {

        if (PauseScript.gameIsPaused == false)
        {
            turnCount++;
            if ((turnCount % 10) == 0)
            {
                UpdateMap();
                DisplayMap();

            }

        }
            

        
        




    }

    public void SaveAll()
    {
        StreamWriter rstrm = File.CreateText("RangedUnit.txt");
        rstrm.Flush();
        rstrm.Close();
        StreamWriter mstrm = File.CreateText("MeleeUnit.txt");
        mstrm.Flush();
        mstrm.Close();
        StreamWriter ttrm = File.CreateText("Tank.txt");
        ttrm.Flush();
        ttrm.Close();
        StreamWriter htrm = File.CreateText("Helicopter.txt");
        htrm.Flush();
        htrm.Close();
        StreamWriter fjrm = File.CreateText("Fighter_Jets.txt");
        fjrm.Flush();
        fjrm.Close();
        StreamWriter fbstrm = File.CreateText("FactoryBuilding.txt");
        fbstrm.Flush();
        fbstrm.Close();
        StreamWriter rbstrm = File.CreateText("ResourceBuilding.txt");
        rbstrm.Flush();
        rbstrm.Close();
        StreamWriter fhstrm = File.CreateText("Field_Hospital.txt");
        fhstrm.Flush();
        fhstrm.Close();
        StreamWriter wustrm = File.CreateText("Weapon_Upgrade.txt");
        wustrm.Flush();
        wustrm.Close();

        foreach (Unit u in map.Units)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;

                m.Save();
            }//end if
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Ranged_Unit m = (Ranged_Unit)u;

                m.Save();

            }//end else
            else if (u.GetType() == typeof(Tank))
            {
                Tank m = (Tank)u;

                m.Save();

            }//end else
            else if (u.GetType() == typeof(Helicopter))
            {
                Helicopter m = (Helicopter)u;

                m.Save();

            }//end else
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                Fighter_Jets m = (Fighter_Jets)u;

                m.Save();

            }//end else



        }//end foreach
        foreach (Building b in map.Buildings)
        {
            if (b.GetType() == typeof(FactoryBuilding))
            {
                FactoryBuilding f = (FactoryBuilding)b;

                f.Save();
            }//end if
            else if (b.GetType() == typeof(ResourceBuilding))
            {
                ResourceBuilding r = (ResourceBuilding)b;

                r.Save();

            }//end else
            else if (b.GetType() == typeof(Field_Hospital))
            {
                Field_Hospital r = (Field_Hospital)b;

                r.Save();

            }//end else
            else if (b.GetType() == typeof(Weapon_Upgrade))
            {
                Weapon_Upgrade r = (Weapon_Upgrade)b;

                r.Save();

            }//end else



        }//end foreach
    }

    public void LoadAll()
    {
        map.Read(20,8);
        DisplayMap(); 
    }
}
