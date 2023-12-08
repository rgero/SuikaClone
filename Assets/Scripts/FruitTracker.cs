using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTracker : MonoBehaviour
{
    public static FruitTracker Instance { get; private set; }


    public List<GameObject> fruitTiers;
    private int age = 0;
    
    private int scoreConstant = 2;

    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one FruitTracker! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
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
        if (fruitIndex + 1 < fruitTiers.Count)
        {
            return fruitTiers[fruitIndex + 1];
        }
        return null;
    }

    public int getFruitValue(GameObject targetFruit)
    {
        int fruitIndex = fruitTiers.FindIndex(x => x.name == targetFruit.name);
        if (fruitIndex == -1)
        {
            return -1;
        }

        return (fruitIndex + 1) * scoreConstant; // Offset for index
    }
}
