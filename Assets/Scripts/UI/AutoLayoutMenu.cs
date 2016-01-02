using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

abstract public class AutoLayoutMenu : MonoBehaviour {

    public GameObject buttonPrefab;
    
    HashSet<GameObject> generatedButtons = new HashSet<GameObject>();
    public void GenerateButtons(int buttonNumber)
    {
        foreach (var g in generatedButtons)
        {
            Destroy(g);
        }
        generatedButtons.Clear();
        for (int i = 0; i < buttonNumber; i++)
        {
            var button = Instantiate(buttonPrefab) as GameObject;
            button.SetActive(true);
            button.transform.SetParent(buttonPrefab.transform.parent);
            button.transform.localScale = Vector3.one;
            button.transform.localEulerAngles = new Vector3();
            button.transform.localPosition = new Vector3();
            ProcessButtonEntity(i, button);
            generatedButtons.Add(button);
        }
    }
    protected abstract void ProcessButtonEntity(int index, GameObject button);
}
