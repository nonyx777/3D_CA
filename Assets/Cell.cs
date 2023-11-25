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
    void Awake()
    {
        rendererComponent = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rendererComponent.enabled = state == State.ALIVE;
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
