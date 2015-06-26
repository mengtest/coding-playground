using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MakeableThings{
	cube,sphere,coin
}

public class LessonStuff : MonoBehaviour
{
	private static Dictionary<MakeableThings,GameObject> prefabs;
	private static int makeCount;

	private static Dictionary<MakeableThings,GameObject> GetPrefabs(){
		if (prefabs==null){
			prefabs=new Dictionary<MakeableThings, GameObject>();
			AddPrefab (MakeableThings.cube,"Cube");
			AddPrefab(MakeableThings.sphere,"Sphere");
            AddPrefab(MakeableThings.coin, "coin");
		}
		return prefabs;
	}

	private static void AddPrefab(MakeableThings shape,string path){

		GameObject prefab = Resources.Load<GameObject> (path);
		prefabs.Add (shape, prefab);
	}

    private static GameObject GetPrefab(MakeableThings thing)
    {
		return GetPrefabs () [thing];
    }

	public static GameObject MakeShape(MakeableThings thing, float x, float y, float z, bool isFalling, Color color, float size){
		makeCount++;

		GameObject newShape = Instantiate(GetPrefab (thing)) as GameObject;
		newShape.transform.position = new Vector3(x, y, z);
		newShape.name = GetPrefab (thing).name+" " + makeCount;
		
		if (isFalling)
			newShape.AddComponent<Rigidbody>();
		newShape.GetComponent<Renderer>().material.color = color;
		newShape.transform.localScale = new Vector3(size, size, size);

		return newShape;
	}

    public static void MakeCube(float x, float y, float z)
    {
		MakeShape(MakeableThings.cube,x, y, z, true, Color.blue, 1);
    }

	public static void MakeCube(float x, float y, float z, float size)
	{
		MakeShape(MakeableThings.cube,x, y, z, false, Color.blue, size);
	}
	
	public static void MakeCube(float x, float y, float z, bool isFalling, Color color, float size)
    {
		MakeShape(MakeableThings.cube,x, y, z, isFalling, color, size);
    }
}
