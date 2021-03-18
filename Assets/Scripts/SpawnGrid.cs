using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class SpawnGrid : MonoBehaviour
{
    public static int height = 20;
    public static int width = 5;
    [ShowInInspector]public static Transform[,] grid = new Transform[width, height];
    public Rigidbody rbCube;

    private void Start()
    {
       
    }

    private void FixedUpdate()
    {
       CheckForLines();
       AddToGrid();
    }
    void  AddToGrid()
    {
        foreach(Transform cube in GetComponentsInChildren<Transform>())
        {
            int roundedX = Mathf.RoundToInt(cube.transform.position.x);
            int roundedZ = Mathf.RoundToInt(cube.transform.position.z);
            
            if(cube.transform.position.z >= 0 && cube.gameObject.name == "Grid(Clone)")
                grid[roundedX, roundedZ] = cube;
            if(cube.transform.position.z >= 0 && cube.gameObject.name == "Cube(Clone)" && rbCube.velocity.z < 0.5)
            {
                grid[roundedX, roundedZ] = cube;
            }
        }
    } 

    void CheckForLines()
    {
        for(int i = height -1;i >= 0; i--)
        {
            if (isRowFull(i))
            {
                DeleteLine(i);
            }
        }
    }

    public  bool isRowFull(int y)
    {
        for (int x = 0; x < 5; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

  

    void DeleteLine(int i)
    {
        for (int j = 0; j < 5; j++)
        {
            Destroy(grid[j, i].transform.gameObject);
            grid[j, i] = null;
        }
    }
}