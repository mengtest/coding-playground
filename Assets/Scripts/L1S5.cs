using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class L1S5 : MonoBehaviour
{

    void Start()
    {
        float xOffset, zOffset, count;
        float red, green, blue;
        bool canMove = true;

        //These are the cubes for sign A.
        count = 10;
        xOffset = -7f;
        zOffset = -6;
        for (float y = 0; y < count; y++)
        {
            red = y / count;
            green = 0;
            blue = 0;

            Color color = new Color(red, green, blue);
            LessonTools.MakeCube(xOffset, y, zOffset, canMove, color, 1);
        }

        //These are the cubes for sign B.
        count = 10;
        xOffset = 7f;
        zOffset = -6;
        for (float y = 0; y < count; y++)
        {
            red = y / count;
            red = 1 - red;
            green = 0;
            blue = 0;

            Color color = new Color(red, green, blue);
            LessonTools.MakeCube(xOffset, y, zOffset, canMove, color, 1);
        }

        //These are the cubes for sign C.
        count = 7;
        xOffset = -10.5f;
        zOffset = 8;
        for (float x = 0; x < count; x++)
        {
            for (float y = 0; y < count; y++)
            {
                red = y / count;
                green = y / count;
                green = 1 - green;
                blue = 1;

                Color color = new Color(red, green, blue);
                LessonTools.MakeCube(x + xOffset, y, zOffset, canMove, color, 1);
            }
        }

        //These are the cubes for sign D.
        count = 10;
        xOffset = 4.5f;
        zOffset = 8;
        for (float x = 0; x < count; x++)
        {
            for (float y = 0; y < count; y++)
            {
                red = x / count;
                green = x / count;
                blue = 1;

                Color color = new Color(red, green, blue);
                LessonTools.MakeCube(x + xOffset, y, zOffset, canMove, color, 1);
            }
        }

        /*
         * Extra challenge!
         * 
         * What is the most interesting color pattern you can make?
         * 
         * Try replacing a line like "green = 0" with something more interesting, like "green = y / count".
         * 
         */
    }
}
