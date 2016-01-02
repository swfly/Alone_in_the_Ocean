using UnityEngine;
using System.Collections;

public class AOShipController : MonoBehaviour {
    public AOShip ship;
    public GameObject signPrefab;
	// Update is called once per frame
	void Update () 
    {
        if (FindObjectOfType<ExclusiveWindow>())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var inter = hit.collider.GetComponent<AOInteractiveObject>();
                if (inter)
                {
                    if (!AOUIInteractionMenu.Instance.Showing)
                        ship.GoToInteractWith(inter);
                }
                else if(hit.collider.CompareTag("Water"))
                {
                    ship.MoveTo(hit.point);
                    var a = Instantiate(signPrefab, hit.point, Quaternion.identity) as GameObject;
                    Destroy(a, 3);
                }
            }

        }
	}
}
