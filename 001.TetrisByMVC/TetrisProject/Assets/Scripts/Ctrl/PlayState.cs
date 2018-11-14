using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState {

    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowGameUI();
        ctrl.cameraManager.ZoomIn();
        ctrl.gameManager.StartGame();
    }

    public void OnPauseButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideGameUI();
        ctrl.view.ShowRestartButton();
        ctrl.gameManager.PauseGame();
    }
}
