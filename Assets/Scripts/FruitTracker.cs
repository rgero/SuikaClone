using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTracker : MonoBehaviour
{
    // Start is called before the first frame update
    private int age = 0;
    void Start()
    {
        
    }
    
    public int getAge()
    {
        return age;
    }

    public void incrementAge()
    {
        age++;
    }
}
