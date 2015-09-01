using UnityEngine;
using System.Collections;

public class L2S3 : MonoBehaviour
{
    AudioClip jumpSound;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("smw_jump");
        MakeRandomPlatforms();
    }

    void Update()
    {
        /*
         * Uh oh! We can't "Find" any "GameObject" called "unicorn"!
         * So when we try to talk about its "transform.position", we get a runtime error and
         * the rest of this "Update" section is cancelled.
         */ 

        GameObject.Find("unicorn").transform.position = new Vector3(1, 5, 10);

        //If you delete the "unicorn" line of code, it will no longer stop the code below from happening.
        if (Input.GetKeyDown(KeyCode.Space))
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
    }

    private void MakeRandomPlatforms()
    {
        //Extra challenge: this code makes the helix spiral of platforms. Adjust it in some way to make the level more fun.
        float radius = 20;
        float y = 0;
        for (float radians = 0; radians < Mathf.PI * 8; radians += Mathf.PI / 12)
        {
            float x = Mathf.Cos(radians) * (radius + Random.Range(-radius / 3, radius / 3));
            y += 2;
            float z = Mathf.Sin(radians) * (radius + Random.Range(-radius / 3, radius / 3));
            Vector3 position = new Vector3(x, y, z);

            GameObject newCube = MakeRandomPlatform(position);
            if (Random.Range(1, 5) == 1)
                MakeCoinsAbovePlatform(newCube);
        }
    }

    private GameObject MakeRandomPlatform(Vector3 position)
    {
        int max = RandInt(1, 15);
        Vector3 newScale = new Vector3(RandInt(1, max), RandInt(1, max / 5 + 1), RandInt(1, max));
        Shapes shape = Shapes.blankCube;
        Color color = LessonTools.GetRandomColor();
        GameObject newCube = LessonTools.MakeShape(shape, position, false, color, 1);
        newCube.transform.localScale = newScale;
        return newCube;
    }

    private void MakeCoinsAbovePlatform(GameObject platform)
    {
        int width = Mathf.RoundToInt(Mathf.Min(platform.transform.localScale.x, platform.transform.localScale.z));
        float height = platform.transform.localScale.y / 2 + 1;
        width = width > 3 ? 3 : width;
        for (int x = -width / 2; x < width; x++)
            for (int z = -width / 2; z < width; z++)
                LessonTools.MakeCoin(platform.transform.position + new Vector3(x, height, z));
    }

    private int RandInt(int min, int max)
    {
        return Mathf.RoundToInt(Random.Range(min, max));
    }
}
