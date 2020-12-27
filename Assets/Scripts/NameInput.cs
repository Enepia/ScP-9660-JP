using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    private InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = this.GetComponent<InputField>();
    }

    public string InputTextReturn()
    {
        return inputField.text;
    }
}
