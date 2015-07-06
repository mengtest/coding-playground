using UnityEngine;
using System.Collections;

public class L1S3 : MonoBehaviour
{

    void Start()
    {
        float xOffset, zOffset;
        bool canMove = true;
        Color color;
        int chessWidth = 8;

        //This is the chessboard for sign A.
        xOffset = -10.5f;
        zOffset = -6;
        for (int x = 0; x < chessWidth; x++)
        {
            for (int z = 0; z < chessWidth; z++)
            {

                if (IsNumberDivisibleByThree(x))
                {
                    color = Color.red;
                }
                else
                {
                    color = Color.white;
                }

                LessonTools.MakeCube(x + xOffset, 0, z + zOffset, canMove, color, 1);
            }
        }

        //This is the chessboard for sign B.
        xOffset = 4.5f;
        zOffset = -6;
        for (int x = 0; x < chessWidth; x++)
        {
            for (int z = 0; z < chessWidth; z++)
            {

                if (IsNumberEven(x) || IsNumberEven(z))
                {
                    color = Color.green;
                }
                else
                {
                    color = Color.yellow;
                }

                LessonTools.MakeCube(x + xOffset, 0, z + zOffset, canMove, color, 1);
            }
        }

        //This is the chessboard for sign C.
        xOffset = -10.5f;
        zOffset = 8;
        for (int x = 0; x < chessWidth; x++)
        {
            for (int z = 0; z < chessWidth; z++)
            {

                if (x + z > 7)
                {
                    color = Color.cyan;
                }
                else
                {
                    color = Color.blue;
                }

                LessonTools.MakeCube(x + xOffset, 0, z + zOffset, canMove, color, 1);
            }
        }

        //This is the chessboard for sign D.
        xOffset = 4.5f;
        zOffset = 8;
        for (int x = 0; x < chessWidth; x++)
        {
            for (int z = 0; z < chessWidth; z++)
            {

                if (x == 0 || x > 3)
                {
                    if (IsNumberEven(z))
                    {
                        color = Color.magenta;
                    }
                    else
                    {
                        color = Color.red;
                    }
                }
                else
                {
                    color = Color.grey;
                }

                LessonTools.MakeCube(x + xOffset, 0, z + zOffset, canMove, color, 1);
            }
        }


        /*
         * Extra challenge!
         * 
         * Change the code above to make a smiley face out of yellow and black cubes.
         * You can make the grid larger than 8 by 8 if you like.
         * 
         *          :)
         * 
         * This may be useful for the challenge... You can write things like this:
         * 
         *      if ((x==3 && z==6) || (x==6 && z==6))
         * 
         * This will be true for the coordinates (3,6) and (6,6). So if the square is black
         * under this condition, you will draw two eyes!
        */
    }

    bool IsNumberOdd(int number)
    {
        return !IsNumberEven(number);
    }

    bool IsNumberEven(int number)
    {
        return number % 2 == 0;
    }

    bool IsNumberDivisibleByThree(int number)
    {
        return number % 3 == 0;
    }

    bool IsNumberDivisibleByFour(int number)
    {
        return number % 4 == 0;
    }

    bool IsNumberDivisibleBy(int number, int divisor)
    {
        return number % divisor == 0;
    }
}
