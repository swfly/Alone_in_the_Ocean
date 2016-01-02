using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class AOUIInteractionMenu : AutoLayoutMenu 
{

    public bool Showing
    {
        get;
        private set;
    }
    AOInteractiveObject targetObj;
    public static AOUIInteractionMenu Instance
    {
        get;
        set;
    }
    void Awake()
    {
        Instance = this;
    }
    void Clear()
    {
        Showing = false;
        GenerateButtons(0);
    }
    AOInteractiveObject.Interaction[] interactions;
    public void ShowInteractionMenu(AOInteractiveObject obj)
    {
        Showing = true;
        targetObj = obj;
        interactions = obj.Interactions;
        GenerateButtons(interactions.Length);

    }
    IEnumerator SafeClearMenu()
    {
        yield return new WaitForEndOfFrame();
        Clear();
        yield break;
    }
    protected override void ProcessButtonEntity(int index, GameObject button)
    {
        button.GetComponentInChildren<Text>().text = interactions[index].title;
        button.GetComponentInChildren<Button>().onClick.AddListener(() => 
        {
            AOGame.Instance.StartInteraction(interactions[index].delay, 
                interactions[index].title, interactions[index].callback);
            StartCoroutine(SafeClearMenu());
        });
    }
}
