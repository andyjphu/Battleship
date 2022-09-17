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
        public (int, int) cellXY = (0, 0);

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

    public Cell[,] cells = new Cell[8, 8] {                             //When converting from engine coords to table, subtract y by 7
        {new Cell("Enemy","E001L001",0) ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell("Player","P001L001",0) ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
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
    /* public void insertPointsGradient(int y, int processedX, int movementDesire)
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
     }*/

    /// <summary>
    /// Generates the desire of the AI to move into each tile
    /// </summary>
    public void generateAIDesire()
    {
        foreach (Cell cell in cells)
        {
            if (cell.owner != "Enemy")
            {
                cell.ai_points = 5;
            }
            if (cell.unit[0] == 'P')
            {
                cell.ai_points = 2;
            }
        }
        foreach (Cell cell in cells)
        {
            if (cell.ai_points == 0)
            {
                cell.ai_points = UnityEngine.Random.Range(0, 1); //TODO: ADD PROPER ALGORITHMN
            }
        }
    }

    /// <summary>
    /// This function converts from runtime y coordinate to array y coordinate
    /// </summary>
    /// <param name="y">the runtime unity coordinate Y</param>
    /// <returns></returns>
    public int gameToData(int y)
    {
        return (7 - y);
    }

    /// <summary>
    /// Moves the unit of name to a new position in the central database
    /// </summary>
    /// <param name="name">name of unit</param>
    /// <param name="newX">where the unit is trying to move with respect to X</param>
    /// <param name="newY">where the unit is trying to move with respect to Y</param>
    public void MoveUnitInRegistry(string name, int newX, int newY)
    {
        foreach (var c in cells)
        {
            if (c.unit == name)
            {
                c.unit = "None";
            }
            //print(cell.unit + cell);
        }

        Cell cell = cells[gameToData(newY), newX]; //This collection is ordered by Y from the top (0,0 is the bottom left tile on the real map but 7,0 is the bottom left tile in the data)
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
            Destroy(child.gameObject);//Delete Cells
            GameObject.Find("Player").GetComponent<Data>().selectedObjects = new List<GameObject>(); //Clear List of Selected Objects
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
        generateAIDesire();
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