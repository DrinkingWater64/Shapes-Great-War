using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputModeChanger : MonoBehaviour
{


    [SerializeField] TextMatcher tm;

    void TurnOnOffTM()
    {
        tm.enabled = !tm.enabled;
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
        }
    }
}
