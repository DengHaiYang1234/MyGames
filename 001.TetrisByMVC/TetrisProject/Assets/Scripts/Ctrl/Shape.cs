using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private Ctrl ctrl; 

    private GameManager game

    private bool isPause = false;

    private float timer = 0;

    private float stepTime = 0.8f;

    private void Update()
    {
        if (isPause) return;
        timer += Time.deltaTime;
        if (timer > stepTime)
        {
            timer = 0;
            Fall();
        }
    }


    public void Init(Color color,Ctrl ctrl)
    {
        foreach (Transform t in transform)
        {
            if (t.tag == "Block")
            {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
        this.ctrl = ctrl;
    }

    public void Fall()
    {
        Vector3 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;

        if (ctrl.model.IsVaildMapPosition(this.transform) == false)
        {
            isPause = true;
        }

    }




}
