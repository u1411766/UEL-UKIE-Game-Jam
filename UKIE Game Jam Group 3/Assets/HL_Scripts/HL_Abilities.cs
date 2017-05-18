using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializePrivateVariables]


public class HL_Abilities : MonoBehaviour {

    internal int int_MaxbuffPoints;
    internal int int_AbailablebuffPoints;

    internal Camera camera;
    internal GameObject Curent_Character;
    internal GameObject Speed_Character;
    internal GameObject Movement_Character;
    internal GameObject AOE_Character;

    internal GameObject Character_1;
    internal GameObject Character_2;
    internal GameObject Character_3;

    internal GameObject Character_buffing;

    internal bool bl_fireRate;
    internal bool bl_FireRateUsed;
    internal int FireRate_Increase;

    internal bool bl_movementUsed;
    internal bool bl_Movement;
    internal int MoveSpeed_Increase;

    internal bool bl_allowSelection;

    internal bool bl_AOE;
    internal bool bl_AOE_Used;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        Apply_Buff();
        if (bl_allowSelection == true && Input.GetMouseButtonDown(1))
        {
            bl_allowSelection = false;
            Curent_Character = null;
        }


        // if a portrait is clicked it will allow the following function
        if (bl_allowSelection == true && Input.GetMouseButtonDown(0))
        {
          RaycastHit hit;
          Ray ray = camera.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(ray, out hit))
          {
              GameObject objectHit = hit.transform.gameObject;
              // checks the object hit tag or name of we change it and if it is one of the main characters alocate it as the curent character.
              if (objectHit.name == "" || objectHit.name == "" || objectHit.name == "")
              {
                  Curent_Character = objectHit;
                  // turn off the raycasting as a character is selected
                  bl_allowSelection = false;
              }
          }
        }
        //--
	}

    // find the apropriate character to apply the buff for.

    public void ApplyCharacter_1()
    {
        if (Character_1 != null)
        {
            Character_buffing = Character_1;
        }
    }
    public void ApplyCharacter_2()
    {
        if (Character_2 != null)
        {
            Character_buffing = Character_2;
        }
    }
    public void ApplyCharacter_3()
    {
             if (Character_3 != null)
        {
        Character_buffing = Character_3;
    }
    }
    //--

    // increase or decrese stats
    public void StatBuff_UP()
    {
        if (Character_buffing != null && int_AbailablebuffPoints != 0)
        {
            Character_buffing.GetComponent<HL_ApplyBuff>().int_buffsApplyed += 1;
            Character_buffing.GetComponent<HL_ApplyBuff>().bl_applyChanges = true;
            int_AbailablebuffPoints--;
            Character_buffing = null;
        }
    }
    public void StatBuff_Down()
    {
        if (Character_buffing != null && int_AbailablebuffPoints != 10)
        {
            Character_buffing.GetComponent<HL_ApplyBuff>().int_buffsApplyed -= 1;
            Character_buffing.GetComponent<HL_ApplyBuff>().bl_applyChanges = true;
            int_AbailablebuffPoints++;
            Character_buffing = null;
        }
    }
    //--

    // triggers the fire rate increase ability
    public void FireRAte()
    {
        bl_fireRate = !bl_fireRate;
        if (bl_FireRateUsed == true)
        {
            Speed_Character.GetComponent<SM_PlayerController>().fl_attackSpeed -= FireRate_Increase;
            int_AbailablebuffPoints++;
            bl_FireRateUsed = false;
            Speed_Character = null;

        }
        else if (bl_FireRateUsed == false)
        {
        bl_allowSelection = true;
        }
    }


    // triggers movement speed increase ability
    public void MovementSpeed()
    {
        bl_Movement = !bl_Movement;
        if (bl_movementUsed == true)
        {
            Speed_Character.GetComponent<SM_PlayerController>().fl_movementSpeed -= MoveSpeed_Increase;
            bl_movementUsed = false;
            int_AbailablebuffPoints++;
            
            Movement_Character = null;
        }
        else if (bl_movementUsed == false)
        {
            bl_allowSelection = true;
        }
    }

    // triggers AOE attack in range of selected character ability
    public void AOE_Attack()
    {
        bl_AOE = !bl_AOE;
        if (bl_AOE_Used == true)
        {
            bl_AOE_Used = false;
            int_AbailablebuffPoints++;
            //Curent_Character.GetComponent<SM_PlayerShoot>(). = false;

            AOE_Character = null;
        }
        else if (bl_AOE_Used == false)
        {
            bl_allowSelection = true;
        }
    }


    void Apply_Buff()
    {
        if (bl_fireRate && Curent_Character != null)
        {
            if (bl_FireRateUsed == false)
            {
                Speed_Character = Curent_Character;
                Curent_Character.GetComponent<SM_PlayerController>().fl_attackSpeed += FireRate_Increase;
                int_AbailablebuffPoints--;
                bl_FireRateUsed = true;
                Curent_Character = null;
            }

        }
        if (bl_Movement && Curent_Character != null)
        {
            if (bl_movementUsed == false)
            {
                Movement_Character = Curent_Character;
                Curent_Character.GetComponent<SM_PlayerController>().fl_movementSpeed += MoveSpeed_Increase;
                int_AbailablebuffPoints--;
                bl_movementUsed = true;
                Curent_Character = null;
            }
        }

        if (bl_AOE && Curent_Character != null)
        {
            if (bl_AOE_Used == false)
            {
                bl_AOE_Used = Curent_Character;
                int_AbailablebuffPoints--;
                // send aoe information to the character for damage 


                //  Curent_Character.GetComponent<SM_PlayerShoot>(). = true;

                bl_movementUsed = true;
                Curent_Character = null;
            }


        }

    }
}
