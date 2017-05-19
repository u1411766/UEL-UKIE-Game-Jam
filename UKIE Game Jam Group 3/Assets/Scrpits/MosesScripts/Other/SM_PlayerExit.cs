using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_PlayerExit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Krispy(Clone)")
        {
            SM_GameManager.in_KrispySaved++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == "Norty(Clone)")
        {
            SM_GameManager.in_NortySaved++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == "McLatte(Clone)")
        {
            SM_GameManager.in_McLatteSaved++;
            Destroy(other.gameObject);
        }
        //Debug.Log(col.gameObject.name);
    }
}
