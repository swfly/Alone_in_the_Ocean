using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AOUIInteractionCountDown : MonoBehaviour 
{
    public Image countDownImage;
    public Text contentText;

    float currentCount;
    float max;
    void Update()
    {
        if (currentCount > 0)
        {
            currentCount = Mathf.MoveTowards(currentCount, 0, Time.deltaTime);
            countDownImage.fillAmount = currentCount / max;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void BeginInteraction(float count, string title)
    {
        gameObject.SetActive(true);
        max = count;
        currentCount = max;
        contentText.text = title;
    }
}
