using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IntegerInputField : MonoBehaviour
{
    public int currentValue;
    public InputField inputField;
    public Button upButton;
    public Button downButton;
    public UnityEvent<IntegerInputField, int, int> OnValueChanged = new UnityEvent<IntegerInputField, int, int>();

    void Start()
    {
        inputField.text = currentValue.ToString();
    }

    void OnValidate()
    {
        SetCurrentValueInternal(currentValue);
    }

    public void OnUpButtonClicked()
    {
        SetCurrentValueInternal(currentValue + 1);
    }

    public void OnDownButtonClicked()
    {
        SetCurrentValueInternal(currentValue - 1);
    }

    public void OnInputFieldSubmit()
    {
        try
        {
            int newValue = Int32.Parse(inputField.text);
            SetCurrentValueInternal(newValue);
        }
        catch (FormatException)
        {
            inputField.text = currentValue.ToString();
        }
    }

    private void SetCurrentValueInternal(int value)
    {
        currentValue = value;
        inputField.text = currentValue.ToString();
        OnValueChanged.Invoke(this, currentValue, value);
    }

    public void SetCurrentValue(int value)
    {
        currentValue = value;
        inputField.text = currentValue.ToString();
    }
}
