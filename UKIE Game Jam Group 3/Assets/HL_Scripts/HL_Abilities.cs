using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializePrivateVariables]


public class HL_Abilities : MonoBehaviour
{

    internal Camera camera;
    internal GameObject Curent_Character;
    internal GameObject Speed_Character;
    internal GameObject Movement_Character;
    internal GameObject Regen_Character;

    internal int HP_Increase;
    internal int Attack_Increase;
    internal int Range_Increase;

    internal bool bl_fireRate;
    internal bool bl_FireRateUsed;
    internal int FireRate_Increase;

    internal bool bl_movementUsed;
    internal bool bl_Movement;
    internal int MoveSpeed_Increase;

    internal bool bl_allowSelection;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
                if (objectHit.name == "Krispy" || objectHit.name == "McLatte" || objectHit.name == "Norty")
                {
                    Curent_Character = objectHit;
                    // turn off the raycasting as a character is selected
                    bl_allowSelection = false;
                }
            }
        }
        //--


    }

    // increase or decrese stats
    public void StatBuff_UP()
    {


    }
    public void StatBuff_Down()
    {


    }
    //--

    // triggers regen ability 
    public void Regen()
    {
        bl_allowSelection = true;
    }

    // triggers the fire rate increase ability
    public void FireRAte()
    {
        bl_fireRate = !bl_fireRate;
        if (bl_FireRateUsed == true)
        {
            Speed_Character.GetComponent<SM_PlayerController>().fl_attackSpeed -= FireRate_Increase;
            Speed_Character = null;
            bl_FireRateUsed = false;

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
            Movement_Character.GetComponent<SM_PlayerController>().fl_movementSpeed -= MoveSpeed_Increase;
            Movement_Character = null;
            bl_movementUsed = false;
        }
        else if (bl_movementUsed == false)
        {
            bl_allowSelection = true;

        }
    }

    // triggers AOE attack in range of selected character ability
    public void AOE_Attack()
    {
        bl_allowSelection = true;
    }


    void Apply_Buff()
    {
        if (bl_fireRate && Curent_Character != null)
        {
            if (bl_FireRateUsed == false)
            {
                Speed_Character = Curent_Character;
                Curent_Character.GetComponent<SM_PlayerController>().fl_attackSpeed += FireRate_Increase;
                bl_FireRateUsed = true;
                Curent_Character = null;
                print("apply the fire rate buff");
            }

        }
        if (bl_Movement && Curent_Character != null)
        {
            if (bl_movementUsed == false)
            {
                Movement_Character = Curent_Character;
                Curent_Character.GetComponent<SM_PlayerController>().fl_movementSpeed += MoveSpeed_Increase;
                bl_movementUsed = true;
                Curent_Character = null;
                print("apply move buff");
            }
        }

    }
}
