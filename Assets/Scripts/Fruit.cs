using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int pointTotal;
    public int age;
    public AudioSource audioSource;

    private string fruitName = string.Empty;
    private FruitTracker tracker;

    public void Awake()
    {
        tracker = this.transform.parent.gameObject.GetComponent<FruitTracker>();
        this.age = tracker.getAge();
        this.fruitName = this.gameObject.name.Split('(')[0];
        this.gameObject.name = this.fruitName;

        this.audioSource = this.GetComponent<AudioSource>();
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
                GameObject nextFruitPrefab = tracker.getNextFruit(this.gameObject);

                if (nextFruitPrefab == null)
                {
                    Debug.Log("There's no fruit higher than this");
                    return;
                }

                this.gameObject.SetActive(false);
                collision.gameObject.SetActive(false);

                this.tracker.incrementAge();
                GameObject nextFruit = Instantiate(nextFruitPrefab, this.transform.parent);
                nextFruit.transform.position = collision.GetContact(0).point;
                nextFruit.GetComponent<AudioSource>().Play();
                
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
               
            }
        }
    }
}
