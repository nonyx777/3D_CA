using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.Android;

public enum State
{
    ALIVE,
    DEAD
}

public class Cell : MonoBehaviour
{
    private Renderer rendererComponent;
    public State state;
    public Vector3Int index;
    int count;
    GridManager gridManager;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        rendererComponent = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkNeighbour(gridManager.gridCells);

        rendererComponent.enabled = state == State.ALIVE;
    }

    //TODO: implement this core function
    void checkNeighbour(GameObject[,,] gridCells)
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
            resurrect();
        else
            kill();        
    }

    void resurrect()
    {
        state = State.ALIVE;
    }
    void kill()
    {
        state = State.DEAD;
    }
}
