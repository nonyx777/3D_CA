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

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkNeighbour();
        
        rendererComponent.enabled = state == State.ALIVE;
    }

    void checkNeighbour()
    {
        count = 0;

        int x = index.x;
        int y = index.y;
        int z = index.z;

        if (x != 29)
            if (GridManager.gridCells[x + 1, y, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (x != 0)
            if (GridManager.gridCells[x - 1, y, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (y != 29)
            if (GridManager.gridCells[x, y + 1, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (y != 0)
            if (GridManager.gridCells[x, y - 1, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (z != 29)
            if (GridManager.gridCells[x, y, z + 1].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (z != 0)
            if (GridManager.gridCells[x, y, z - 1].GetComponent<Cell>().state == State.ALIVE)
                count++;


        if (count == 3)
            resurrect();
        else
            kill();
    }

    public void resurrect()
    {
        state = State.ALIVE;
    }
    public void kill()
    {
        state = State.DEAD;
    }
}
