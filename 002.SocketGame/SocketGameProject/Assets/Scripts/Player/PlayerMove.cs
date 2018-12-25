using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 3;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //移动   世界坐标中移动
        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime,Space.World);
        //转向
        transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
        //动画
        float res = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
        anim.SetFloat("Forward", res);
    }

}
