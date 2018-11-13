using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPause = false; //游戏是否暂停

    private Shape currentShape = null;

    public Shape[] shapes;

    public Color[] colors;

    private Ctrl ctrl;

    private void Awake()
    {
        ctrl = GetComponent<Ctrl>();
    }

    private void Update()
    {
        if (isPause) return;
        if (currentShape == null)
        {
            SpawnShape();
        }
    }

    void SpawnShape()
    {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);

        currentShape = GameObject.Instantiate(shapes[index]);
        currentShape.Init(colors[indexColor], ctrl);

    }

    public void StartGame()
    {
        isPause = false;
    }

    public void PauseGame()
    {
        isPause = true;
    }

}
