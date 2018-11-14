using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPause = true; //游戏是否暂停

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
        int index = Random.Range(0, shapes.Length - 1);

        int indexColor = Random.Range(0, colors.Length - 1);

        currentShape = GameObject.Instantiate(shapes[index]);

        currentShape.Init(colors[indexColor], ctrl,this);
    }

    public void StartGame()
    {
        isPause = false;
        if (currentShape != null)
            currentShape.Resume();
    }

    public void PauseGame()
    {
        isPause = true;
        if (currentShape != null)
            currentShape.Pause();
    }

    public void FallDown()
    {
        currentShape = null;
    }

}
