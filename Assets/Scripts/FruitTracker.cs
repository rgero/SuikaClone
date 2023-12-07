using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTracker : MonoBehaviour
{
    // Start is called before the first frame update
    private int age = 0;
    public List<GameObject> fruitTiers;
    
    public int getAge()
    {
        return age;
    }

    public void incrementAge()
    {
        age++;
    }

    public GameObject getNextFruit(GameObject targetFruit)
    {
        int fruitIndex = fruitTiers.FindIndex(x => x.name == targetFruit.name);

        Debug.Log(fruitIndex);

        if (fruitIndex + 1 < fruitTiers.Count)
        {
            return fruitTiers[fruitIndex + 1];
        }
        return null;
    }
}
