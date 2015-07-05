﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Shapes
{
    cube, sphere, cone, pyramid, tetrahedron, torus, blankCube
}

public class LessonTools : MonoBehaviour
{
    private static Dictionary<Shapes, GameObject> prefabs;
    private static GameObject coinPrefab;
    private static GameObject shapeContainer;

    private static int makeCount;

    private static Dictionary<Shapes, GameObject> GetPrefabs()
    {
        if (prefabs == null)
        {
            prefabs = new Dictionary<Shapes, GameObject>();
            AddPrefab(Shapes.cube, "shapes/cube");
            AddPrefab(Shapes.sphere, "shapes/sphere");
            AddPrefab(Shapes.cone, "shapes/cone");
            AddPrefab(Shapes.pyramid, "shapes/pyramid");
            AddPrefab(Shapes.tetrahedron, "shapes/tetrahedron");
            AddPrefab(Shapes.torus, "shapes/torus");
            AddPrefab(Shapes.blankCube, "shapes/blank cube");
        }
        return prefabs;
    }

    public static void MakeCoin(float x, float y, float z)
    {
        if (coinPrefab == null)
            coinPrefab = Resources.Load<GameObject>("coin");

        GameObject coin = Instantiate(coinPrefab) as GameObject;
        coin.transform.position = new Vector3(x, y, z);
    }

    private static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public static Shapes GetRandomShape()
    {
        return GetRandomEnum<Shapes>();
    }

    public static Color GetRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        //make grey/sludge colors less likely
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            if (Random.Range(0, 10) > 1)
            {
                int a = Random.Range(0, 3);
                if (a == 0)
                    r = 0;
                if (a == 1)
                    g = 0;
                if (a == 2)
                    b = 0;
            }
        }

        return new Color(r, g, b);
    }

    private static void AddPrefab(Shapes shape, string path)
    {

        GameObject prefab = Resources.Load<GameObject>(path);
        prefabs.Add(shape, prefab);
    }

    private static GameObject GetPrefab(Shapes thing)
    {
        return GetPrefabs()[thing];
    }

    public static GameObject MakeShape(Shapes shape, Vector3 position, bool canMove, Color color, float size)
    {
        return MakeShape(shape, position.x, position.y, position.z, canMove, color, size);
    }

    public static GameObject MakeShape(Shapes shape, float x, float y, float z, bool canMove, Color color, float size)
    {
        makeCount++;
        if (shapeContainer == null)
            shapeContainer = new GameObject("shape container");

        GameObject newShape = Instantiate(GetPrefab(shape)) as GameObject;
        newShape.transform.position = new Vector3(x, y, z);
        newShape.transform.parent = shapeContainer.transform;
        newShape.name = GetPrefab(shape).name + " " + makeCount;

        if (canMove)
            newShape.AddComponent<Rigidbody>();
        newShape.GetComponent<Renderer>().material.color = color;
        newShape.transform.localScale = new Vector3(size, size, size);

        return newShape;
    }

    public static void MakeCube(float x, float y, float z)
    {
        MakeShape(Shapes.cube, x, y, z, true, Color.blue, 1);
    }

    public static void MakeCube(float x, float y, float z, float size)
    {
        MakeShape(Shapes.cube, x, y, z, false, Color.blue, size);
    }

    public static void MakeCube(Vector3 position, bool canMove, Color color, float size)
    {
        MakeShape(Shapes.cube, position.x, position.y, position.z, canMove, color, size);
    }

    public static void MakeCube(float x, float y, float z, bool canMove, Color color, float size)
    {
        MakeShape(Shapes.cube, x, y, z, canMove, color, size);
    }
}
