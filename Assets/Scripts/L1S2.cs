using UnityEngine;
using System.Collections;

public class L1S2 : MonoBehaviour
{

    void Start()
    {
        //Question: here are three "for loops". Match up each for loop with its sign in the 3D world: A, B, or C.

        //for loop #1
        for (int x = 0; x < 4; x++)
        {
            LessonTools.MakeCube(x, 0, 2);
            LessonTools.MakeCube(x, 0, 3);
            LessonTools.MakeCube(x, 0, 4);
            LessonTools.MakeCube(x, 0, 5);
        }

        //for loop #2
        for (int x = 0; x < 4; x++)
        {
            for (int z = 0; z < 4; z++)
            {
                LessonTools.MakeCube(x, 3, z + 10);
            }
        }

        //for loop #3
        for (int x = 0; x < 12; x++)
        {
            for (int z = 0; z < 4; z++)
            {
                LessonTools.MakeCube(x + 6, 6, z + 10);
            }
        }


        /*
         * Extra challenge!
         * 
         * Did you notice the extra coins on the highest platform?
         * Your challenge is to change one number, just one number, in the code above.
         * If you change the right number, it will be much easier to get all the coins.
        */


        /*
         * Another extra challenge!
         * 
         * The following code makes something special in the sky. What is it?
        */

        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
                for (int z = 0; z < 4; z++)
                    LessonTools.MakeCube(x, y + 20, z);

    }
}
