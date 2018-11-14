using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public const int MAX_ROWS = 23;
    public const int MAX_COLUMNS = 10;

    private Transform[,] map = new Transform[MAX_COLUMNS, MAX_ROWS];


    private int currentRow = 0;

    /// <summary>
    /// 检测是否在有效位置
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool IsVaildMapPosition(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            
            if (!IsInsideMap(pos)) return false;

            //该位置已经有Block
            if (map[(int) pos.x, (int) pos.y] != null) return false;
        }

        return true;
    }

    /// <summary>
    /// 是否在地图内
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool IsInsideMap(Vector2 pos)
    {
        return pos.x >= 0 && pos.x <= MAX_COLUMNS - 1 && pos.y >= 0; 
    }

    /// <summary>
    /// 放置Block
    /// </summary>
    /// <param name="t"></param>
    public void PlaceShape(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int) pos.x, (int) pos.y] = child;
            RecordCurretRowNumber((int)pos.y);
            CheckMapByRow((int)pos.y);
        }

        //CheckMap();
    }

    /// <summary>
    /// 记录当前的最大行数
    /// </summary>
    /// <param name="row"></param>
    private void RecordCurretRowNumber(int row)
    {
        currentRow = currentRow > row ? currentRow : row;
    }

    /// <summary>
    /// 检测当前放下的这个Block所占的几行是否已满
    /// </summary>
    /// <param name="row"></param>
    private void CheckMapByRow(int row)
    {
        bool isFull = CheckIsRowFull(row);
        if (isFull)
        {
            DeleteRow(row);
            MoveDownRowsAbove(row + 1);
        }
    }


    /// <summary>
    /// 检查地图是否需要消除
    /// </summary>
    private void CheckMap()
    {
        for (int i = 0; i < MAX_ROWS; i++)
        {
            bool isFull =  CheckIsRowFull(i);
            if (isFull)
            {
                DeleteRow(i);
                MoveDownRowsAbove(i + 1);
                i--;
            }
        }
    }


    /// <summary>
    /// 检测该行的每列是否已满
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    private bool CheckIsRowFull(int row)
    {
        //每列
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] == null) return false;
        }
        return true;
    }

    /// <summary>
    /// 删除该行的每列元素
    /// </summary>
    /// <param name="row"></param>
    private void DeleteRow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            Destroy(map[i, row].gameObject);
            map[i, row] = null;
        }
    }


    /// <summary>
    /// 将前一行及以上全部移下来
    /// </summary>
    /// <param name="row"></param>
    private void MoveDownRowsAbove(int row)
    {
        for (int i = row; i <= currentRow; i++)
        {
            MoveDownRow(i);
        }
        currentRow = currentRow - 1;
    }

    private void MoveDownRow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] != null)
            {
                map[i, row - 1] = map[i, row];
                map[i, row] = null;
                map[i, row - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

}
