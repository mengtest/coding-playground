using UnityEngine;
using System.Collections;

public class Lesson1 : MonoBehaviour
{

    void Start()
    {
        //When you see two slashes at the start of the line like this: "//" it means the computer will ignore this line.
        //Lines starting with two slashes are called comments.

        float size = 0.8f;

        //Question: here are three "for loops". Match up each for loop with its sign in the 3D world: A, B, or C.

        //for loop #1
        for (int i = 0; i < 3; i++)
            LessonStuff.MakeCube(i, 0, 10, size);

        //for loop #2
        for (int i = 0; i < 10; i++)
            LessonStuff.MakeCube(i, 0, 5, size);

        //for loop #3
        for (int i = 0; i < 10; i++)
            LessonStuff.MakeCube(i, i, 15, size);


        /*
         * Extra challenge!
         * 
         * Did you notice the vertical column of coins high up in the sky?
         * Your challenge is to change one number, just one number, in the code above.
         * If you change the right number, you will be able to get all the coins.
        */

    }
}
