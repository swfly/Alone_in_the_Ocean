using UnityEngine;
using System.Collections;
using System;

public class AOFishZone : AOInteractiveObject 
{
    public float time = 5;
    void Start()
    {
        interaction = new Interaction();
        interaction.callback = Fishing;
        interaction.delay = time;
        interaction.title = "Fishing";
    }
    Interaction interaction;
    public override AOInteractiveObject.Interaction[] Interactions
    {
        get { return new Interaction[] { interaction }; }
    }
    public string item;
    public int amount = 1;
    void Fishing()
    {
        AOItemEntity ie = new AOItemEntity();
        ie.id = item;
        ie.amount = amount;
        AOGame.Instance.PlayerData.GetItem(ie);
        Destroy(gameObject);
    }

}
