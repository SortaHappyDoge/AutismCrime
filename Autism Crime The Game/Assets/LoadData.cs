using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus;

public class LoadData : MonoBehaviour
{
    
    public NavMeshPlus.Components.NavMeshSurface surface;
    public Collider2D map;

    private void Start()
    {
        surface.BuildNavMesh();
        map.isTrigger = true;
    }
}
