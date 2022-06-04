using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMatcher: MonoBehaviour 
{
    string _currentText = string.Empty;
    string _remainingText = string.Empty;

    string _test = "gogo";

    private void Awake()
    {

    }

    void Start()
    {
        {
            SetCurrentText(_test);
        }
    }

   
    void Update()
    {
        CheckLetter();
    }

    public void SetCurrentText(string newText)
    {
        _currentText = newText;
        _remainingText = _currentText;
        Debug.Log("current text: "+_currentText);
    }
    
    
    void CheckLetter()
    {
        if (Input.anyKeyDown && _remainingText.Length != 0)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                Debug.Log(keysPressed);
                EnterLetter(keysPressed);
            }
            Debug.Log("rem text: "+_remainingText);
        }
    }

    void SetRemainingText(string newText)
    {
        _remainingText = newText;
    }


    void EnterLetter(string inputLetter)
    {
        if (IsCorrectLetter(inputLetter))
        {
            RemoveLetter();
            if (IsTextComplete())
            {
                Debug.Log("complete");
            }
        }
    }

    bool IsCorrectLetter(string inputLetter)
    {
        return _remainingText[0] == inputLetter[0];
    }

    void RemoveLetter()
    {
        string newString = _remainingText.Remove(0, 1);
        SetRemainingText(newString);
    }

    bool IsTextComplete()
    {
        return _remainingText.Length == 0;
    }



}

