using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    int size_x = 30;
    int size_y = 30;
    int size_z = 30;
    public GameObject cell_prefab;
    public static GameObject[,,] gridCells;

    void Awake()
    {
        gridCells = new GameObject[size_x, size_y, size_z];
        createGrid();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            resetGrid();

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

                    //index == id
                    cellScript.index = new Vector3Int(x, y, z);

                    //cell state
                    if (x == 10 && y == 10 && z == 10)
                        cellScript.state = State.ALIVE;


                    gridCells[x, y, z] = cell;
                }
            }
        }
    }

    void resetGrid()
    {
        for (int y = 0; y < size_y; y++)
        {
            for (int x = 0; x < size_x; x++)
            {
                for (int z = 0; z < size_z; z++)
                {
                    if(x == 10 & y == 10 && z == 10)
                        gridCells[x, y, z].GetComponent<Cell>().state = State.ALIVE;
                    else
                        gridCells[x, y, z].GetComponent<Cell>().state = State.DEAD;
                }
            }
        }
    }
}
