using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HL_NPC_Attack : MonoBehaviour {
    // base statsw of character
    public int int_Character_HP;
    public int int_Character_Attack;
    public float fl_Attack_Speed;
    public float fl_move_Speed;


     // targets and other objects 
    public GameObject go_targer;
    public string str_tag;

    // distence calculation

    public float fl_engage_distance;
    public float fL_attack_distance;


    // positions relevent 
    private Vector3 V3_Start_Position;
    public Vector3 V3_Current_Position;


	// Use this for initialization
	void Start () 
    {
        V3_Start_Position = transform.position;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        // always keep track of NPc curent position.
        V3_Current_Position = transform.position;	
	
    
    
    
    }
}
