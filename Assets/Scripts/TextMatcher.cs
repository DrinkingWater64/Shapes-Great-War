using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextMatcher: MonoBehaviour 
{

    public event Action TextMatched;
    [SerializeField] TextMeshProUGUI textBox;

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
        textBox.text = _currentText;
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
            textBox.text = _remainingText;
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
        if (_remainingText.Length == 0)
        {

        TextMatched();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetTextMatcher()
    {
        _currentText = string.Empty;
        _remainingText = String.Empty;
        textBox.text = _currentText;
    }



}
