using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int size_x = 20;
    public int size_y = 20;
    public int size_z = 20;
    public GameObject cell_prefab;
    public GameObject[,,] gridCells;
    int count = 0;

    void Awake()
    {
        gridCells = new GameObject[size_x, size_y, size_z];
        createGrid();
    }

    void Update()
    {
        for (int x = 0; x < size_x; x++)
        {
            for (int y = 0; y < size_y; y++)
            {
                for (int z = 0; z < size_z; z++)
                {
                    checkNeighbour(gridCells[x, y, z].GetComponent<Cell>().index);
                }
            }
        }
    }

    void createGrid()
    {
        for (int y = 0; y < size_y; y++)
        {
            for (int x = 0; x < size_x; x++)
            {
                for (int z = 0; z < size_z; z++)
                {
                    GameObject cell = Instantiate(cell_prefab, new Vector3(x, y, z), Quaternion.identity);
                    cell.transform.parent = this.transform;

                    //get attached script
                    Cell cellScript = cell.GetComponent<Cell>();

                    cellScript.index = new Vector3Int(x, y, z);
                    gridCells[x, y, z] = cell;
                }
            }
        }
    }

    void checkNeighbour(Vector3Int index)
    {
        count = 0;

        int x = index.x;
        int y = index.y;
        int z = index.z;

        if(x != 19)
            if(gridCells[x+1, y, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if(x != 0)
            if(gridCells[x-1, y, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if(y != 19)
            if(gridCells[x, y+1, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if(y != 0)
            if(gridCells[x, y-1, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if(z != 19)
            if(gridCells[x, y, z+1].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if(z != 0)
            if(gridCells[x, y, z-1].GetComponent<Cell>().state == State.ALIVE)
                count++;

        
        if(count == 4 || count == 3)
            gridCells[x, y, z].GetComponent<Cell>().resurrect();
        else
            gridCells[x, y, z].GetComponent<Cell>().kill();
    }
}
