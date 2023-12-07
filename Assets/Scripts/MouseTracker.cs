using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public GameObject nextPiece;
    public Transform parentContainer;
    public List<GameObject> fruitList;

    private SpriteRenderer spriteRenderer;
    private float xOffset;
    private float xOffsetStart = 60f;


    // Start is called before the first frame update
    void Start()
    {
        chooseRandomFruit();
        this.xOffset = xOffsetStart - nextPiece.transform.localScale.x / 2 - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, -xOffset, xOffset);
        mousePosition.y = 95f;
        mousePosition.z = 0;
        transform.position = mousePosition;
        
        if (Input.GetMouseButtonDown(0))
        {
            LaunchFruit(this.transform);
        }

    }

    private void LaunchFruit(Transform mousePosition)
    {
        GameObject newObject = Instantiate(nextPiece, parentContainer);
        newObject.transform.position = mousePosition.position;

        this.parentContainer.GetComponent<FruitTracker>().incrementAge();

        chooseRandomFruit();
    }

    private void chooseRandomFruit()
    {
        nextPiece = fruitList[UnityEngine.Random.Range(0, fruitList.Count)];
        processFruitSprite();
    }

    private void processFruitSprite()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = nextPiece.GetComponent<SpriteRenderer>().sprite;
        spriteRenderer.color = nextPiece.GetComponent<SpriteRenderer>().color;
        this.transform.localScale = nextPiece.transform.localScale;
        this.xOffset = xOffsetStart - nextPiece.transform.localScale.x / 2 - 0.5f; // Wall Thickness is 1.
    }
}
