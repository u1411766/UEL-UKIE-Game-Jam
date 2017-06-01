using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_BuffLight : MonoBehaviour {
    public Light buffLight;
    public Light selectLight;
    public SM_ApplyBuffs buffTracker;
    // Use this for initialization
    void Start () {
        buffTracker = GameObject.Find("GameManager").GetComponent<SM_ApplyBuffs>();
	}
	
	// Update is called once per frame
	void Update () {
        if (buffTracker.bl_buffActive == false)
        {
            buffLight.enabled = false;
        }
	}
}
