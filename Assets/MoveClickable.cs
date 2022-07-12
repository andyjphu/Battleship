using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MoveClickable : MonoBehaviour
{
    private Color originalColor;
    public Color adjustA = new Color((45.0f/255.0f), 45.0f/255.0f, 45.0f/255.0f,0.0f);
    public Color adjustB = new Color(69.0f/255.0f, 69.0f/255.0f, 69.0f/255.0f,0.0f);
    Collider2D[] touching;
    //private bool selected = false; 
    // Start is called before the first frame update
    void Start()
    {
        originalColor =
        gameObject.GetComponent<SpriteRenderer>().color;

        //gameObject.GetComponent<BoxCollider2D>().OverlapCollider(null, touching);
        //if(!gameObject.GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("BackGrid").GetComponent<BoxCollider2D>())) {

        if (gameObject.name != "PossibleMove")
        {
            if (transform.position.x > 7 || transform.position.x < 0 || transform.position.y > 7 || transform.position.y < 0)
            {
                Destroy(gameObject);

            }
        }
        //}
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

        gameObject.GetComponent<SpriteRenderer>().color = originalColor  - adjustB;

    }

    private void OnMouseUpAsButton()
    {
        if (GameObject.Find("Player").GetComponent<Data>().selectedObjects.Count == 1)
        {
            GameObject.Find("Player").GetComponent<Data>().selectedObjects[0].transform.position = gameObject.transform.position;
            GetComponentInParent<UnitClickable>().Invoke("OnMouseDown",0.0f);
            GameObject.Find("Player").GetComponent<Data>().AdjustOrdersLeft(-1);
//            GetComponentInParent<UnitClickable>().selected = false;
//          GameObject.Find("Player").GetComponent<Data>().selectedObjects.Clear();
        }
    }
    private void OnMouseExit()
    {
 

            gameObject.GetComponent<SpriteRenderer>().color = originalColor;

 
 
    }

    void ToggleSelected()
    {

    }
}
