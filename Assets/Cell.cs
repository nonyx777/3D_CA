using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.Android;

public enum State
{
    DEAD,
    ALIVE
}

public class Cell : MonoBehaviour
{
    private Renderer rendererComponent;
    public State state;
    public Vector3Int index;
    int count;
    int size = 19;

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rendererComponent.enabled = state == State.ALIVE;
        checkNeighbour();
    }

    void checkNeighbour()
    {
        count = 0;

        int x = index.x;
        int y = index.y;
        int z = index.z;

        if (x != size)
            if (GridManager.gridCells[x + 1, y, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (x != 0)
            if (GridManager.gridCells[x - 1, y, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (y != size)
            if (GridManager.gridCells[x, y + 1, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (y != 0)
            if (GridManager.gridCells[x, y - 1, z].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (z != size)
            if (GridManager.gridCells[x, y, z + 1].GetComponent<Cell>().state == State.ALIVE)
                count++;
        if (z != 0)
            if (GridManager.gridCells[x, y, z - 1].GetComponent<Cell>().state == State.ALIVE)
                count++;


        if (count == 1 || count == 3)
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
