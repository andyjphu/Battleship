using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TileClickable : MonoBehaviour
{
    private Color originalColor;
    public Color adjustA = new Color((45.0f / 255.0f), 45.0f / 255.0f, 45.0f / 255.0f, 0.0f);
    public Color adjustB = new Color(69.0f / 255.0f, 69.0f / 255.0f, 69.0f / 255.0f, 0.0f);

    //int a = 0;
    //jint b = 1;
    public bool selected = false;

    private List<GameObject> possibleMoves = new List<GameObject>();
    public Data data;

    // Start is called before the first frame update
    private void Start()
    {
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        data = GameObject.Find("Player").GetComponent<Data>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor - adjustA;
    }

    private void OnMouseDown()
    {
        if (data.inSelectMode)
        {
            selected = !selected;
            //GameObject.Find("Player").GetComponent<Data>().selectedObjects =
            //selected == true? GameObject.Find("Player").GetComponent<Data>().selectedObjects.add(gameObject) : selected = true;
            if (selected)
            {
                data.selectedObjects.Add(gameObject);
            }
            else
            {
                data.selectedObjects.Remove(gameObject);
            }
            gameObject.GetComponent<SpriteRenderer>().color = originalColor - adjustB;
        }
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = originalColor - (adjustA * 2);
        }
    }

    private void ToggleSelected()
    {
    }
}