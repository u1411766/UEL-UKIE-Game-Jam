using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializePrivateVariables]
public class SM_Disco : MonoBehaviour 
{
    GameObject go_chosenFloor;
    int selectedFloor;

    Material materialOne;
    Material materialTwo;
    float fl_timetoChange;

    [Header("Don't Edit")]
    float timer = 2f;
    string objectTag;
    GameObject[] go_floors;
    // Use this for initialization 
    void Start()
    {
        go_floors = GameObject.FindGameObjectsWithTag(objectTag);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SwitchColors();
    }

    public void SwitchColors()
    {
        timer -= Time.deltaTime;

        foreach (GameObject item in go_floors)
        {
            selectedFloor = Random.Range(0, go_floors.Length);
            if (timer <= 0)
            {
                go_chosenFloor = go_floors[selectedFloor];
                timer = fl_timetoChange;
            }

            if (go_chosenFloor)
            {
                Renderer rend = go_chosenFloor.gameObject.GetComponent<Renderer>();
                rend.material = materialOne;

                Renderer rend2 = item.gameObject.GetComponent<Renderer>();
                rend2.material = materialTwo;
            }
        }
    }
}
