using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    int size_x = 20;
    int size_y = 20;
    int size_z = 20;
    public GameObject cell_prefab;
    public static GameObject[,,] gridCells;

    //cell colors
    [SerializeField] private Color grey = Color.grey;
    [SerializeField] private Color white = Color.white;
    [SerializeField] private Color yellow = Color.yellow;
    [SerializeField] private Color red = Color.red;

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
                    //get renderer component
                    Renderer renderer = cell.GetComponent<Renderer>();

                    //index == id
                    cellScript.index = new Vector3Int(x, y, z);
                    //assign color
                    renderer.material.color = assignColor(ref cellScript.index);


                    //cell state
                    if (x == 19 && y == 19 && z == 19)
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
                    if (x == 19 && y == 19 && z == 19)
                        gridCells[x, y, z].GetComponent<Cell>().state = State.ALIVE;
                    else
                        gridCells[x, y, z].GetComponent<Cell>().state = State.DEAD;
                }
            }
        }
    }

    Color assignColor(ref Vector3Int index)
    {
        if (index.x <= 15 && index.y <= 15 && index.z <= 15)
            return red;
        if (index.x <= 18 && index.y <= 18 && index.z <= 18)
            return yellow;
        if (index.x <= 19 && index.y <= 19 && index.z <= 19)
            return white;

        return grey;
    }
}
