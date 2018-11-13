using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class View : MonoBehaviour
{
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private GameObject restartBtn;

    private void Start()
    {
        logoName = transform.Find("Canvas/LogoName") as RectTransform;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        restartBtn = menuUI.transform.Find("Button_Restart").gameObject;
    }

    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-90f, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(27.3f, 0.5f);
    }


    public void HideMenu()
    {

        logoName.DOAnchorPosY(50f, 0.5f).OnComplete(delegate
        {
            logoName.gameObject.SetActive(false);
        });


        menuUI.DOAnchorPosY(-30.5f, 0.5f).OnComplete(delegate ()
        {
            menuUI.gameObject.SetActive(false);
        });
        
    }

    public void ShowGameUI()
    {
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-100f, 0.5f);
    }

    public void HideGameUI()
    {
        gameUI.DOAnchorPosY(100f, 0.5f).OnComplete(delegate ()
        {
            gameUI.gameObject.SetActive(false);
        });
    }

    public void ShowRestartButton()
    {
        restartBtn.gameObject.SetActive(true);
    }

}
