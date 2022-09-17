using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Data data;

    public MapData mapData;
    private int originalX, originalY;

    private void Start()
    {
        originalX = (int)gameObject.transform.position.x;
        originalY = (int)gameObject.transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void moveEnemy()
    {
        try
        {
            for (int i = 0; i < 4; i++)
            {
                //mapData.cells[]
            }
        }
        catch (System.IndexOutOfRangeException)
        {
            throw;
        }
        //mapData.MoveUnitInRegistry(gameObject.name, )
    }
}