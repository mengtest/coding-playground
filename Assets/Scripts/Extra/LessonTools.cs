using UnityEngine;
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

    public static void MakeCoin(Vector3 position)
    {
        MakeCoin(position.x, position.y, position.z);
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

    public static GameObject MakeCube(float x, float y, float z, bool canMove = false)
    {
		return MakeShape(Shapes.cube, x, y, z, canMove, Color.blue, 1);
    }

    public static GameObject MakeCube(float x, float y, float z, float size, bool canMove = false)
    {
        return MakeShape(Shapes.cube, x, y, z, canMove, Color.blue, size);
    }

    public static GameObject MakeCube(Vector3 position, bool canMove, Color color, float size)
    {
        return MakeShape(Shapes.cube, position.x, position.y, position.z, canMove, color, size);
    }

    public static GameObject MakeCube(float x, float y, float z, bool canMove, Color color, float size)
    {
        return MakeShape(Shapes.cube, x, y, z, canMove, color, size);
    }

    //The code below is complicated. Examine it if you dare.
    private static List<Vector3> usedVoxelPoints;
    public static void MakeHalfCircle(Vector3 position, float radius, Color color)
    {
        //Note: rainbows are hyperbolas, not half circles! But this way makes the coding exercise much simpler.
        if (usedVoxelPoints == null)
            usedVoxelPoints = new List<Vector3>();

        float stepSize = Mathf.PI / radius / 8;

        for (float radians = 0; radians < Mathf.PI; radians += stepSize)
        {
            //Given that radians is somewhere between 0 and Pi (or 0 and 180 degrees) calculate the x and y.
            int x = Mathf.RoundToInt(Mathf.Cos(radians) * radius);
            int y = Mathf.RoundToInt(Mathf.Sin(radians) * radius);
            Vector3 newPoint = position + new Vector3(x, y, 0);

            //Only create a cube at that point if we've never created a cube there before.
            //This allows us to increment radians/degrees very slowly, slicing out very tiny slices of the circle.
            if (!usedVoxelPoints.Contains(newPoint))
            {
                usedVoxelPoints.Add(newPoint);
                LessonTools.MakeShape(Shapes.blankCube, newPoint, false, color, 1);
            }
        }
    }
}
