using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_EnemyExit : MonoBehaviour
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
        if (other.gameObject.tag == "Enemy")
        {
            SM_GameManager.in_LivesLeft--;
            Destroy(other.gameObject);
        }
        Debug.Log(other.gameObject.tag);
    }
}