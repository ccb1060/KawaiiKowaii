using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EatingTimer : MonoBehaviour
{
    //List of sprites to rotate through
    //0 - red, 1 - orange, 2 - yellow, 3 - green
    public Sprite[] spriteList;

    //Current image index
    [SerializeField] private int currentImage = 0;

    [SerializeField] SpriteRenderer spriteComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spriteComponent = GetComponent<SpriteRenderer>();
        spriteComponent.sprite = spriteList[3];

        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Changes the image to the one at the specified index
    public void ChangeImage(int index)
    {
        Debug.Log("Changing the image to index " + index);
        spriteComponent = GetComponent<SpriteRenderer>();

        spriteComponent.sprite = spriteList[index];
        currentImage = index; 
    }
    public void HideTimer()
    {
        GetComponent<GameObject>().SetActive(false);
    }

    public void ShowTimer()
    {
        GetComponent<GameObject>().SetActive(true);
    }

    //Resets timer to 0 and changes the image
    public void ResetTimer()
    {
        currentImage = 0;
        ChangeImage(0); 
    }
}
