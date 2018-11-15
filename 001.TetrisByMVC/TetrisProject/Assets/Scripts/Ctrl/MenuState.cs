using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartBtuuonClick, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowMenu();
        ctrl.cameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideMenu();
    }

    public void OnStartButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.StartBtuuonClick);
    }

    public void OnRankButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        ctrl.view.ShowRankUI(ctrl.model.HighScore,ctrl.model.Score,ctrl.model.NumberScore);
    }

    public void OnDestroyButtonClick()
    {
        ctrl.model.ClearData();
        OnRankButtonClick();
    }

    public void OnRestartButtonClick()
    {
        ctrl.model.Restart();
        ctrl.gameManager.ClearShape();
        fsm.PerformTransition(Transition.StartBtuuonClick);
    }
}
