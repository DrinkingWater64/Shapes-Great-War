using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputModeChanger : MonoBehaviour
{

    [SerializeField] Canvas tmc;
    [SerializeField] TextMatcher tm;

    void TurnOnOffTM()
    {
        tm.enabled = !tm.enabled;
    }

    void TurnOnOffTMC()
    {
        tmc.enabled = !tmc.enabled;
    }

    void Update()
    {
        if (InputManager.instance.GetKeyDown(KeyBindingActions.Mode))
        {
            if (InputManager.instance.mode == InputMode.COMMAND)
            {
                InputManager.instance.mode = InputMode.INSERT;
            }
            else
            {
                InputManager.instance.mode = InputMode.COMMAND;
            }
            TurnOnOffTM();
            TurnOnOffTMC();
        }
    }
}
