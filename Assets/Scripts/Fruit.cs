using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private string fruitName = string.Empty;
    public int age;
    public GameObject nextFruitPrefab;

    public void Awake()
    {
        this.age = this.transform.parent.gameObject.GetComponent<FruitTracker>().getAge();
    }

    public void setName(string name)
    {
        this.fruitName = name;
    }

    bool isSame(Fruit other)
    {
        if (other == null)
            return false;

        if (this.fruitName == other.fruitName)
        {
            return true;
        }

        return false;
    }

    bool isOlder(Fruit other)
    {
        return this.age > other.age;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fruit newFruit = collision.gameObject.GetComponent<Fruit>();
        if (newFruit == null)
            return;
    
        if (isSame(newFruit))
        {
            // Check the Age 
            if(isOlder(newFruit))
            {
                this.gameObject.SetActive(false);
                collision.gameObject.SetActive(false);

                // Get the Mid Distance
                Vector3 midDistance = this.transform.position + ((this.transform.position - collision.transform.position) / 2);
                GameObject nextFruit = Instantiate(nextFruitPrefab, this.transform.parent);
                nextFruit.transform.position = midDistance;

                Destroy(collision.gameObject);
                Destroy(this.gameObject);
               
            }
        }
    }
}
