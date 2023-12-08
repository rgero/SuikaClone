using System;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public static MouseTracker Instance { get; private set; }

    public GameObject wall;
    private GameObject nextPiece;
    public Transform parentContainer;
    public List<GameObject> availableFruitToSpawn;

    private SpriteRenderer spriteRenderer;
    private float xOffset;
    private float xOffsetStart;
    private bool canPlace;

    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one MouseTracker! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        canPlace = true;
        float thickness = wall.transform.localScale.x / 2;
        xOffsetStart = Math.Abs(wall.transform.position.x) - thickness;

        chooseRandomFruit();
        calculateClamp();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, -xOffset, xOffset);
        mousePosition.y = 170f;
        mousePosition.z = 0;
        transform.position = mousePosition;
        
        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            LaunchFruit(this.transform);
        }

    }

    void calculateClamp()
    {
        this.xOffset = xOffsetStart - nextPiece.transform.localScale.x;
    }

    private void LaunchFruit(Transform mousePosition)
    {
        this.parentContainer.GetComponent<FruitTracker>().incrementAge();
        GameObject newObject = Instantiate(nextPiece, parentContainer);
        newObject.transform.position = mousePosition.position;
        
        chooseRandomFruit();
    }

    private void chooseRandomFruit()
    {
        nextPiece = availableFruitToSpawn[UnityEngine.Random.Range(0, availableFruitToSpawn.Count)];
        processFruitSprite();
    }

    private void processFruitSprite()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = nextPiece.GetComponent<SpriteRenderer>().sprite;
        spriteRenderer.color = nextPiece.GetComponent<SpriteRenderer>().color;
        this.transform.localScale = nextPiece.transform.localScale;
        calculateClamp();
    }

    public void setCanPlace(bool newValue)
    {
        this.canPlace = newValue;
    }
}
