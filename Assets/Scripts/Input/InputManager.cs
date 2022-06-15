using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputMode mode;


    public static InputManager instance;
    [SerializeField] KeyBindings keyBindings;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    
    public KeyCode GetKeyForAction(KeyBindingActions keyBindingActions)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in keyBindings.keyBindingChecks)
        {
            if (keyBindingCheck.KeyBindingActions == keyBindingActions)
            {
                return keyBindingCheck.KeyCode;
            }
        }
        return KeyCode.None;
    }

    public bool GetKeyUp(KeyBindingActions key)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in keyBindings.keyBindingChecks)
        {
            if (keyBindingCheck.KeyBindingActions == key)
            {
                return Input.GetKeyUp(keyBindingCheck.KeyCode);
            }
        }
        return false;
    }

    public bool GetKey(KeyBindingActions key)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in keyBindings.keyBindingChecks)
        {
            if (keyBindingCheck.KeyBindingActions == key)
            {
                return Input.GetKey(keyBindingCheck.KeyCode);
            }
        }
        return false;
    }

    public bool GetKeyDown(KeyBindingActions key)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in keyBindings.keyBindingChecks)
        {
            if (keyBindingCheck.KeyBindingActions == key)
            {
                return Input.GetKeyDown(keyBindingCheck.KeyCode);
            }
        }

        return false;
    }

    public void testMethod()
    {
        Debug.Log("test");
    }

        
}
