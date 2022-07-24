using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public GameObject ownedTile;
    public GameObject soldier;

    //public GameObject map;   deprecated

    //
    public class Cell
    {
        public string owner = "None", unit = "None";
        public int development = 0;

        public Cell(string _owner = "None", string _unit = "None", int _development = 0)
        {
            owner = _owner; //Player or Enemy
            unit = _unit;
            development = _development;
        }
    }

    public Cell[,] cells = new Cell[8, 8] {
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell("Player","Soldier0",0) ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        };

    public void spawnTile(int x, int y)
    {
        GameObject obj = Instantiate(ownedTile, new Vector3(x, y, -1), Quaternion.identity);

        obj.transform.SetParent(gameObject.transform);
    }

    public void MoveUnitInRegistry(string name, int newX, int newY)
    {
        Cell cell = cells[newX, 7 - newY];
        foreach (var c in cells)
        {
            if (c.unit == name)
            {
                c.unit = "None";
            }
            //print(cell.unit + cell);
        }

        cell.unit = name;
        if (cell.owner != "Player")
        {
            cell.owner = "Player";
            spawnTile(newX, newY);
        }//print(cells[newX, 7 - newY].unit);
    }

    public void RegenerateMap()
    {
        //Delete Cells
        //  TODO: refactor this for performance
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child);
        }

        //Create Cells
        int i = 0, j = 0;
        foreach (var cell in cells)
        {
            if (i > 7)
            {
                i = 0;
                j++;
            }
            if (cell.owner == "Player")
            {
                spawnTile(i, 7 - j);
                //GameObject obj = Instantiate(ownedTile, new Vector3(i, 7 - j, -1), Quaternion.identity);
                //obj.transform.SetParent(gameObject.transform);
            }
            if (cell.unit != "None")
            {
                GameObject obj = Instantiate(soldier, new Vector3(i, 7 - j, -2), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.name = cell.unit;
            }

            print("Updated Map");
            i++;
        }
    }

    private void OnDrawGizmos()
    {
        //RegenerateMap();
    }

    private void Start()
    {
        RegenerateMap();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}