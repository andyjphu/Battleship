using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Clickable : MonoBehaviour
{
    private Color originalColor;
    public Color adjustA = new Color((45.0f / 255.0f), 45.0f / 255.0f, 45.0f / 255.0f, 0.0f);
    public Color adjustB = new Color(69.0f / 255.0f, 69.0f / 255.0f, 69.0f / 255.0f, 0.0f);

    private bool selected = false; 
    // Start is called before the first frame update
    void Start()
    {
        originalColor =
        gameObject.GetComponent<SpriteRenderer>().color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor - adjustA;
    }
    private void OnMouseDown()
    {
        print(selected);
        selected = !selected;
        gameObject.GetComponent<SpriteRenderer>().color = originalColor  - adjustB;
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {

            gameObject.GetComponent<SpriteRenderer>().color = originalColor;

        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().color = originalColor - (adjustA/2);

        }
    }

    void ToggleSelected()
    {

    }
}
