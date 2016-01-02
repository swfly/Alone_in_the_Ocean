using UnityEngine;
using System.Collections;
using System;

public abstract class AOGame : MonoBehaviour
{
    public static AOGame Instance
    {
        get;
        set;
    }
    public AOShipData PlayerData
    {
        get;
        protected set;
    }
    abstract public void StartInteraction(float cost, string title, Action callback);
    protected abstract AOShipData GenerateInitialData();
}
public class AOSingleGame : AOGame 
{
    [System.Serializable]
    public class InitialSettings
    {

        public int initialFood = 100;
        public int initialWater = 100;
        public int initialEnergy = 100;
        public int initialPopulation = 3000;
        [System.Serializable]
        public class InitialItem
        {
            public string id;
            public int amount;
        }
        public InitialItem[] initialItems;
    }
    [System.Serializable]
    public class ConditionSettings
    {
        public float foodReducePerSecond = .1f;
        public float waterReducePerSecond = .2f;
        public float energyReducePerSecond = .05f;
        public float panicDeltaPerSecond = 1;
        public float peopleDieSpeed = 3;
        public float birthSpeed = .1f;
    }
    public InitialSettings initialSettings;
    public ConditionSettings conditionSettings;
	// Use this for initialization
	void Start () 
    {
        Instance = this;
        PlayerData = GenerateInitialData();
	}
    protected override AOShipData GenerateInitialData()
    {
        AOShipData data = new AOShipData();
        data.Food = initialSettings.initialFood;
        data.Water = initialSettings.initialWater;
        data.Population = initialSettings.initialPopulation;
        data.Energy = initialSettings.initialEnergy;
        foreach (var a in initialSettings.initialItems)
        {
            var ie = new AOItemEntity();
            ie.amount = a.amount;
            ie.id = a.id;
            data.Items[ie.id] = ie;
        }
        return data;
    }

	
	// Update is called once per frame
	void Update ()
    {
        PlayerData.Food = Mathf.MoveTowards(PlayerData.Food, 0, conditionSettings.foodReducePerSecond * Time.deltaTime);
        PlayerData.Water = Mathf.MoveTowards(PlayerData.Water, 0, conditionSettings.waterReducePerSecond * Time.deltaTime);
        PlayerData.Energy = Mathf.MoveTowards(PlayerData.Energy, 0, conditionSettings.energyReducePerSecond * Time.deltaTime);

        if (PlayerData.Food < 20 || PlayerData.Water < 20)
        {
            PlayerData.Panic = Mathf.MoveTowards(PlayerData.Panic, 100, conditionSettings.panicDeltaPerSecond * Time.deltaTime);
        }
        else
        {
            PlayerData.Panic = Mathf.MoveTowards(PlayerData.Panic, 0, conditionSettings.panicDeltaPerSecond * Time.deltaTime);
        }
        if (PlayerData.Food <= 0 || PlayerData.Water <= 0)
        {
            PlayerData.Population = Mathf.MoveTowards(PlayerData.Population,
                0, conditionSettings.peopleDieSpeed * Time.deltaTime);
        }
        else
        {
            PlayerData.Population += conditionSettings.birthSpeed * Time.deltaTime;
        }
	}
    public override void StartInteraction(float cost, string title, Action callback)
    {
        AOUIRoot.Instance.countDown.BeginInteraction(cost, title);
        StartCoroutine(InteractionWithDelay(cost, callback));
    }
    IEnumerator InteractionWithDelay(float cost, Action callback)
    {
        yield return new WaitForSeconds(cost);
        callback();
        yield break;
    }
}
