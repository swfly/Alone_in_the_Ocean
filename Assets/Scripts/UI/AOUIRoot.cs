using UnityEngine;
using System.Collections;

public class AOUIRoot : MonoBehaviour
{
    static public AOUIRoot Instance
    {
        get;
        private set;
    }
    void Awake()
    {
        Instance = this;
    }
    public AOUIInteractionCountDown countDown;
}
