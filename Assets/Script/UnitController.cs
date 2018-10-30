using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour {

    public Text healthText;
    POE_RTS poe_rts;

	// Use this for initialization
	void Start () {
        healthText = (Text)GameObject.Find("Canvas").GetComponentInChildren<Text>();
        poe_rts = (POE_RTS)GameObject.Find("map").GetComponent<POE_RTS>();
		
	}

   
  

    
    private void OnMouseDown()
    {
        //bool Found = false;
        string information = "";

        int x = (int)this.transform.position.x;
        int y = (int)this.transform.position.y;

        foreach (Unit u in poe_rts.map.Units)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;

                if((m.XPos == x)&&(m.YPos == y))
                {
                    //Found = true;
                    information = m.ToString();
                }
            }
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Ranged_Unit m = (Ranged_Unit)u;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    //Found = true;
                    information = m.ToString();
                }
            }
            else if (u.GetType() == typeof(Fighter_Jets))
            {
                Fighter_Jets m = (Fighter_Jets)u;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    //Found = true;
                    information = m.ToString();
                }
            }
            else if (u.GetType() == typeof(Tank))
            {
                Tank m = (Tank)u;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    //Found = true;
                    information = m.ToString();
                }
            }
            else if (u.GetType() == typeof(Helicopter))
            {
                Helicopter m = (Helicopter)u;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    //Found = true;
                    information = m.ToString();
                }
            }
        }

        foreach (Building b in poe_rts.map.Buildings)
        {
            if (b.GetType() == typeof(FactoryBuilding))
            {
                FactoryBuilding m = (FactoryBuilding)b;

                if ((m.XPos == x) && (m.YPos == y))
                {
                      
                    information = m.ToString();
                }
            }
            else if (b.GetType() == typeof(ResourceBuilding))
            {
                ResourceBuilding m = (ResourceBuilding)b;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    
                    information = m.ToString();
                }
            }
            else if (b.GetType() == typeof(Field_Hospital))
            {
                Field_Hospital m = (Field_Hospital)b;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    
                    information = m.ToString();
                }
            }
            else if (b.GetType() == typeof(Weapon_Upgrade))
            {
                Weapon_Upgrade m = (Weapon_Upgrade)b;

                if ((m.XPos == x) && (m.YPos == y))
                {
                    
                    information = m.ToString();
                }
            }

            
            


        }

        

        healthText.text = information;

    }
}
