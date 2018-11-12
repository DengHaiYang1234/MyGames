using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState {

    private void Awake()
    {
        stateID = StateID.Menu;
    }
}
