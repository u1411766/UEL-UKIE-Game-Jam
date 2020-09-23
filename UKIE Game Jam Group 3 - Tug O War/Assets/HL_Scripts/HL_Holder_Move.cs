using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HL_Holder_Move : MonoBehaviour
{
    public RectTransform rTrans;
    public RectTransform Start_rTrans;
    public RectTransform NewTrans;

    public int Canvas_moveSpeed;
    public float speed;
    public bool show_Portrait;
    public bool hide_portrait;

    bool bl_move_panel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rTrans = (RectTransform)transform.GetComponent<RectTransform>();

        //--
        // move till bool is false
        if (show_Portrait == true)
        {
            hide_portrait = false;
            transform.position = Vector2.Lerp(transform.position, NewTrans.position, speed / 150);
        }

        if (hide_portrait == true)
        {
                transform.position = Vector2.Lerp(transform.position, Start_rTrans.position, speed / 150);

        }
        if(bl_move_panel)
        {
            transform.position = Vector2.Lerp(transform.position, NewTrans.position, speed / 150);
        }
        else if(bl_move_panel == false)
        {
            transform.position = Vector2.Lerp(transform.position, Start_rTrans.position, speed / 150);
        }


    }
    void Show_portrait()
    {
        show_Portrait = true;

    }
    void Hide_portrait()
    {
        hide_portrait = true;
        show_Portrait = false;
    }
   public  void PanelHide()
    {
        bl_move_panel = !bl_move_panel;
    }
}
