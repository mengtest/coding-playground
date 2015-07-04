using UnityEngine;
using System.Collections;

public class RandomTree : MonoBehaviour
{
    private static GameObject[] treePrefabs;
    void Start()
    {
        if (treePrefabs == null)
        {
            treePrefabs = new GameObject[3];
            for (int i = 0; i < 3; i++)
                treePrefabs[i] = Resources.Load<GameObject>("trees/tree" + (i+1));
        }
        MakeRandomTree();
    }

    private void MakeRandomTree()
    {
        GameObject prefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
        float range = 1000;
        RaycastHit hitInfo;
        Vector3 origin = transform.position + new Vector3(0, range / 2, 0);
        Physics.Raycast(origin, Vector3.down, out hitInfo, range);
        if (hitInfo.collider != null)
        {
            GameObject newTree=            Instantiate(prefab, hitInfo.point, Quaternion.identity) as GameObject;
            float scale=Random.Range(0.7f,1.4f);
            newTree.transform.localScale = new Vector3(scale, scale, scale);
        }
        else
            Debug.LogError("Tried to make random tree but didn't find ground.");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(gameObject.transform.position, 0.4f);
        Gizmos.DrawCube(gameObject.transform.position-new Vector3(0,1,0),new Vector3(0.3f,2,0.3f));

    }
}
