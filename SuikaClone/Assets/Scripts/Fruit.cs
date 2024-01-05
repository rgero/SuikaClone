using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int pointTotal;
    public int age;
    public AudioSource audioSource;
    private string fruitName = string.Empty;
    private float placedCooldown;
    private bool isPlaced;

    public void Start()
    {
        this.age = FruitTracker.Instance.getAge();
        this.fruitName = this.gameObject.name.Split('(')[0];
        this.gameObject.name = this.fruitName;
        this.pointTotal = FruitTracker.Instance.getFruitValue(this.gameObject);

        this.audioSource = this.GetComponent<AudioSource>();

        placedCooldown = 5.0f;
        isPlaced = false;
    }

    void Update()
    {
        if (isPlaced) return;

        placedCooldown -= Time.deltaTime;
        if (placedCooldown <= 0.0f)
        {
            isPlaced = true;
        }
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
                GameObject nextFruitPrefab = FruitTracker.Instance.getNextFruit(this.gameObject);

                if (nextFruitPrefab == null)
                {
                    Debug.Log("There's no fruit higher than this");
                    return;
                }

                this.gameObject.SetActive(false);
                collision.gameObject.SetActive(false);

                FruitTracker.Instance.incrementAge();
                GameObject nextFruit = Instantiate(nextFruitPrefab, this.transform.parent);
                nextFruit.transform.position = collision.GetContact(0).point;
                nextFruit.GetComponent<AudioSource>().Play();

                // Increment score.
                ScoreContainer.Instance.incrementScore(this.pointTotal);
                
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
               
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        // Check if it's the death plane
        if (other.gameObject.tag == "DeathPlane" && isPlaced)
        {
            Debug.Log("GAME OVER");
            ScoreContainer.Instance.hasDied();
            // Process the end game logic here.
        }    
    }
}
