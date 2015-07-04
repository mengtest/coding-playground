using UnityEngine;
using System.Collections;

public class L1S2 : MonoBehaviour
{

    void Start()
    {
        float cubeSize = 1;

        //Question: here are three "for loops". Match up each for loop with its sign in the 3D world: A, B, or C.

        //for loop #1
        for (int i = 0; i < 4; i++)
        {
            LessonTools.MakeCube(i, 0, 2, cubeSize);
            LessonTools.MakeCube(i, 0, 3, cubeSize);
            LessonTools.MakeCube(i, 0, 4, cubeSize);
            LessonTools.MakeCube(i, 0, 5, cubeSize);
        }

        //for loop #2
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                LessonTools.MakeCube(i, 3, j + 10, cubeSize);
            }
        }

        //for loop #3
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                LessonTools.MakeCube(i + 6, 6, j + 10, cubeSize);
            }
        }


        /*
         * Extra challenge!
         * 
         * Did you notice the extra coins on the highest platform?
         * Your challenge is to change one number, just one number, in the code above.
         * If you change the right number, it will be much easier to get all the coins.
        */

    }
}
