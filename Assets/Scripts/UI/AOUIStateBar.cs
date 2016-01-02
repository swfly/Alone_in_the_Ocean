using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AOUIStateBar : MonoBehaviour {
    public Text populationText;
    public Slider food;
    public Slider water;
    public Slider panic;
    public Slider energy;
	// Update is called once per frame
	void Update () 
    {
        populationText.text = ((int)AOGame.Instance.PlayerData.Population).ToString();
        food.value = AOGame.Instance.PlayerData.Food / 100;
        water.value = AOGame.Instance.PlayerData.Water / 100;
        panic.value = AOGame.Instance.PlayerData.Panic / 100;
        energy.value = AOGame.Instance.PlayerData.Energy / 100;
	}
}
