using UnityEngine;
using System.Collections;

public class AOShip : AOInteractiveObject
{
    public float speed = 5;

    float currentSpeed;
    
	// Use this for initialization
	void Start ()
    {
        getWaterInteraction = new Interaction();
        getWaterInteraction.callback = GetWater;
        getWaterInteraction.delay = 3;
        getWaterInteraction.title = "Purify Water";
	}

    Vector3 target;

    bool goForInteraction;
    AOInteractiveObject interactionTarget;
    public void MoveTo(Vector3 targetPosition)
    {
        goForInteraction = false;
        target = targetPosition;
    }
    public void GoToInteractWith(AOInteractiveObject obj)
    {
        goForInteraction = true;
        interactionTarget = obj;
    }
	// Update is called once per frame
	void FixedUpdate () 
    {
        Vector3 pointTo = target - transform.position;
        float distance = 5;
        if (goForInteraction)
        {
            pointTo = interactionTarget.transform.position - transform.position;
            distance += interactionTarget.radius;
        }
        pointTo.y = 0;
        if (pointTo.magnitude > distance)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(pointTo),
                60 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            if (goForInteraction)
            {
                target = transform.position;
                goForInteraction = false;
                ShowInteractionUI();
            }
        }
	}

    void ShowInteractionUI()
    {
        AOUIInteractionMenu.Instance.ShowInteractionMenu(interactionTarget);
    }

    public override AOInteractiveObject.Interaction[] Interactions
    {
        get { return new Interaction[] { getWaterInteraction }; }
    }
    Interaction getWaterInteraction;

    public string waterId = "water01";
    public float waterCostEnergy = 5;
    void GetWater()
    {
        if (AOGame.Instance.PlayerData.Energy < waterCostEnergy)
            return;
        AOItemEntity ie = new AOItemEntity();
        ie.amount = 1;
        ie.id = waterId;
        AOGame.Instance.PlayerData.GetItem(ie);
        AOGame.Instance.PlayerData.Energy = Mathf.MoveTowards(AOGame.Instance.PlayerData.Energy,
            0, waterCostEnergy);
    }
}
