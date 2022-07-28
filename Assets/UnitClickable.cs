using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class UnitClickable : MonoBehaviour
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
        selected = !selected;
        //GameObject.Find("Player").GetComponent<Data>().selectedObjects =
        //selected == true? GameObject.Find("Player").GetComponent<Data>().selectedObjects.add(gameObject) : selected = true;
        if (selected)
        {
            if (data.ordersLeft > 0)
            {
                data.selectedObjects.Add(gameObject);
                if (data.selectedObjects.Count == 1)
                {
                    GameObject p1 = GameObject.Instantiate(GameObject.Find("PossibleMove"), transform.position + new Vector3(-1, 0), Quaternion.identity, transform);

                    GameObject p2 = GameObject.Instantiate(GameObject.Find("PossibleMove"), transform.position + new Vector3(0, 1), Quaternion.identity, transform);

                    GameObject p3 = GameObject.Instantiate(GameObject.Find("PossibleMove"), transform.position + new Vector3(1, 0), Quaternion.identity, transform);

                    GameObject p4 = GameObject.Instantiate(GameObject.Find("PossibleMove"), transform.position + new Vector3(0, -1), Quaternion.identity, transform);

                    possibleMoves.Add(p1);
                    possibleMoves.Add(p2);
                    possibleMoves.Add(p3);
                    possibleMoves.Add(p4);
                }
            }
            else
            {
                this.Invoke("OnMouseDown", 0.0f);
                data.SetConsoleDisplayMessage("You'll need to end your turn to get more orders");
            }
        }
        else
        {
            data.selectedObjects.
                Remove(gameObject);
            foreach (var p in possibleMoves)
            {
                Destroy(p);
            }
        }
        gameObject.GetComponent<SpriteRenderer>().color = originalColor - adjustB;
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