using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HL_Camera_Movement : MonoBehaviour
{
    public static HL_Camera_Movement instance;

    public float MaxXvalue;
    public float MaxZvalue;
    public float MaxValue;

    public float fl_top_max;
    public float fl_bot_max;


    public int int_camMovementSpeed;

     public float HorSpeed = 40;
    public float VertSpeed = 40;
    public float Cam_rot_speed = 80;

    public Transform camera;
    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CamStartGame();
        CamGameControls();

    }

    void CamGameControls()
    {
        Vector3 pos = transform.position;
        //--
        // this sets the position and rotation of the camera holder and camera childed to the holder.

        float horisontal = Input.GetAxis("Horizontal") * HorSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * VertSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Rotation");

        

        transform.Translate(Vector3.forward * vertical);
        transform.Translate(Vector3.right * horisontal);

        // allows movement only if u are between a certain point preventing map loss during play
        if (transform.position.x > MaxXvalue)
        {
            transform.position = new Vector3(MaxValue, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -MaxXvalue)
        {
            transform.position = new Vector3(-MaxValue, transform.position.y, transform.position.z);
        }
        if (transform.position.z > fl_top_max)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, fl_top_max);
        }
        if (transform.position.z < fl_bot_max)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, fl_bot_max);
        }

        // manages rotation
        if (rotation != 0)
        {
            transform.Rotate(Vector3.up, rotation * Cam_rot_speed * Time.deltaTime, Space.World);
        }
    }
    //--
    // camera movement on buttons WASD or arrow


    void CamStartGame()
    {
        // this area can determine where the camera will be positioned at the start of the game
        // curentley triggered in update but it can and should be moved to an aproptiate area.


        //gameObject.transform.position = new Vector3(-0.05f, 18.48f, 0.13f);
        //gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

        //if (set_Cam == true)
        //{
        //    //transform.rotation = Quaternion.Euler(90, 0, 0);
        //    transform.position = new Vector3(-0.61f, 16.5f, -14f);

        //    set_Cam = false;
        //}
    }



}
