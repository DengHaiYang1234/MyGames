﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTools
{
    /// <summary>
    /// 位置转换
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Vector3 Parse(string str)
    {
        string[] strs = str.Split(',');
        float x = float.Parse(strs[0]);
        float y = float.Parse(strs[1]);
        float z = float.Parse(strs[2]);
        return new Vector3(x, y, z);
    }

}
