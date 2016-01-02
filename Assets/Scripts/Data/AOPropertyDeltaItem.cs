using UnityEngine;
using System.Collections;

[System.Serializable]
public class AOPropertyDeltaItem : AOItem
{
    public float deltaFood;
    public float deltaWater;
    public float deltaEnergy;
    public float deltaPanic;
    public int deltaPopulation;
    public void Use(AOShipData data)
    {
        data.Food = Mathf.Clamp(data.Food + deltaFood, 0, 100);
        data.Water = Mathf.Clamp(data.Water + deltaWater, 0, 100);
        data.Energy = Mathf.Clamp(data.Energy + deltaEnergy, 0, 100);
        data.Panic = Mathf.Clamp(data.Panic + deltaPanic, 0, 100);
        data.Population = Mathf.Clamp(data.Population + deltaPopulation, 0, 10000);
    }
}
