using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : Fruit
{
    // Start is called before the first frame update
    void Awake()
    {
        setName("Grape");
        base.Awake();
    }
}
