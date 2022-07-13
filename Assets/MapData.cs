using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public class Cell
    {
        public string owner = "None", unit = "None";
        public int development = 0;

        public Cell(string _owner = "None", string _unit = "None", int _development = 0)
        {
            owner = _owner;
            unit = _unit;
            development = _development;
        }
    }

    public Cell[,] cells = new Cell[8, 8] {
        {new Cell("Player") ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell() ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        {new Cell("Player") ,new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell(),new Cell()},
        };

    // Start is called before the first frame update
    private void Start()
    {
        print(cells[0, 8].owner);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}