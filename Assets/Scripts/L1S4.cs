using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class L1S4 : MonoBehaviour
{

    void Start()
    {
        float xOffset, zOffset, size;
        bool canMove = true;

        //These are the cubes for sign A.
        size = 10;
        xOffset = -7f;
        zOffset = -6;
        for (float y = 0; y < size; y++)
        {
            float red = y / size;
            float green = 0;
            float blue = 0;

            Color color = new Color(red, green, blue);
            LessonTools.MakeCube(xOffset, y, zOffset, canMove, color, 1);
        }

        //These are the cubes for sign B.
        size = 10;
        xOffset = 7f;
        zOffset = -6;
        for (float y = 0; y < size; y++)
        {
            float red = y / size;
            red = 1 - red;
            float green = 0;
            float blue = 0;

            Color color = new Color(red, green, blue);
            LessonTools.MakeCube(xOffset, y, zOffset, canMove, color, 1);
        }

        //These are the cubes for sign C.
        size = 7;
        xOffset = -10.5f;
        zOffset = 8;
        for (float x = 0; x < size; x++)
        {
            for (float y = 0; y < size; y++)
            {
                float red = y / size;
                float green = y / size;
                green = 1 - green;
                float blue = 1;

                Color color = new Color(red, green, blue);
                LessonTools.MakeCube(x + xOffset, y, zOffset, canMove, color, 1);
            }
        }

        //These are the cubes for sign D.
        size = 10;
        xOffset = 4.5f;
        zOffset = 8;
        for (float x = 0; x < size; x++)
        {
            for (float y = 0; y < size; y++)
            {
                float red = x / size;
                float green = x / size;
                float blue = 1;

                Color color = new Color(red, green, blue);
                LessonTools.MakeCube(x + xOffset, y, zOffset, canMove, color, 1);
            }
        }
    }
}
