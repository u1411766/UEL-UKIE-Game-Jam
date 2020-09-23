using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class HL_Points_Dsiplay : MonoBehaviour {

    public GameObject points_Display;
    Text maximum_points;
    Text remaining_points;
    Text maximum_points_number;
    Text remaining_points_number;

	// Use this for initialization
	void Start () 
    {
        maximum_points = points_Display.transform.GetChild(0).GetComponent<Text>();
        remaining_points = points_Display.transform.GetChild(1).GetComponent<Text>();
        maximum_points_number = points_Display.transform.GetChild(2).GetComponent<Text>();
        remaining_points_number = points_Display.transform.GetChild(3).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
            //points_Display.SetActive(true);
            //maximum_points.text = "Maximum Points:";
            //remaining_points.text = "Remaining Points:";

	
    }
}
