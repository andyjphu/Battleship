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
        public int development = 0, ai_points = 0;
        public bool gradiented = false;

        public Cell(string _owner = "None", string _unit = "None", int _development = 0, int _ai_point = 0)
        {
            owner = _owner; //Player or Enemy
            unit = _unit;
            development = _development;
            ai_points = _ai_point;
        }

        public override string ToString()
        {
            return owner + " " + unit + " " + development.ToString() + " " + ai_points.ToString();
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
        {new Cell("Player","PlayerSoldier0",0) ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        };

    public void spawnFriendlyTile(int x, int y)
    {
        //print("SP CALLED");
        GameObject obj = Instantiate(ownedTile, new Vector3(x, y, -1), Quaternion.identity);

        obj.transform.SetParent(gameObject.transform);
    }

    public void spawnFriendlySoldier(int x, int y, string name)
    {
        GameObject obj = Instantiate(soldier, new Vector3(x, y, -2), Quaternion.identity);
        obj.transform.SetParent(gameObject.transform);
        obj.name = name;
    }

    //y = 3, x=3
    public void insertPointsGradient(int y, int processedX, int movementDesire)
    {
        try
        {
            if (cells[y, processedX].gradiented == false)
            {
            }

            insertPointsGradient(y + 1)
        }
        catch (IndexOutOfRangeException)
        {
            throw;
        }
    }

    public void MoveUnitInRegistry(string name, int newX, int newY)
    {
        Cell cell = cells[7 - newY, newX];
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
            spawnFriendlyTile(newX, newY);
        }//print(cells[newX, 7 - newY].unit);
    }

    public void RegenerateMap()
    {
        //Delete Cells
        //  TODO: refactor this for performance
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
            GameObject.Find("Player").GetComponent<Data>().selectedObjects = new List<GameObject>();
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
                spawnFriendlyTile(i, 7 - j);
                try
                {
                }
                catch (IndexOutOfRangeException)
                {
                    throw;
                }
                //GameObject obj = Instantiate(ownedTile, new Vector3(i, 7 - j, -1), Quaternion.identity);
                //obj.transform.SetParent(gameObject.transform);
            }
            if (cell.unit.Contains("Player"))
            {
                spawnFriendlySoldier(i, 7 - j, cell.unit);
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
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            RegenerateMap();
            foreach (Cell cell in cells)
            {
                //print(cell.owner);
            }
        }
    }
}