using UnityEngine;
using System.Collections;
using System;

public abstract class AOInteractiveObject : MonoBehaviour 
{
    public float radius = 3;
    public class Interaction
    {
        public float delay;
        public string title;
        public Action callback;
    }
    abstract public Interaction[] Interactions
    {
        get;
    }
}
