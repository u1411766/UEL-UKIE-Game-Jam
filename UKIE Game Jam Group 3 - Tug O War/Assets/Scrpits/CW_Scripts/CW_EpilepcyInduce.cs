using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_EpilepcyInduce : MonoBehaviour 
{
    public Color colorStart = Color.green;
    public Color colorEnd = Color.blue;
    public float duration = 1.0F;
    public Renderer rend;
    
	// Use this for initialization
	void Start () 
    {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        ColourChange();
	}
    void ColourChange()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        
        
    }
}
