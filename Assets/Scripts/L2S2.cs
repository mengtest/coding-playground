using UnityEngine;
using System.Collections;

public class L2S2 : MonoBehaviour
{

    void Start()
    {
        //Every variable (every letter) is going to evaluate to true or false.

        bool a = 5 > 7;
        bool b = false;
        bool c = true && false;
        bool d = (false || false) && true;
        bool e = 3000 < 2000;
        bool f = Color.green == Color.black;
        bool g = 1 > 2 || 2 > 3 || 3 > 4;
        bool h = 1 < 2 && 2 < 3 && 3 < 4;
        bool i = false || 1337 < -3;
        bool j = true == false;
        bool k = !true;
        bool l = !(5 > 3);
        bool m = !(1 == 1);
        bool n = 2 + 2 == 5;
        bool o = (true || false) && ((true && true) && false);
        bool p = 1 + 1 - 1 + 1 - 1 == 1;
        bool q = !(2 + 2 == 4);
        bool r = Color.cyan == Color.cyan && false;

        /*
         * Only two variables above have the value "true". All the others have the value "false".
         * 
         * Question: which two variables are true?
         * 
         * In the lines of code below, change the letters "a" and "b" to the two variables that are true.
         * If you run your code and a rainbow appears, then you got the correct answer.
         */

        if (a||true)
            MakeRainbow();

        if (b)
            MakeCoinsAboveRainbow();
    }

    private void MakeCoinsAboveRainbow()
    {
        //This finds the highest spots on the rainbow and makes a coin just above that.

        //It does this by starting at a point very high in the sky, and moving downward until it hits something (the rainbow).
        //If you're feeling brave, do an internet search for "unity physics raycast" for more info!

        for (int i = -50; i < 50; i++)
        {
            Vector3 origin = new Vector3(i, 100, 30);

            RaycastHit hitInfo;
            if (Physics.Raycast(origin, Vector3.down, out hitInfo, 1000))
            {
                Vector3 coinPosition = hitInfo.point + new Vector3(0, 1, 0);
                LessonTools.MakeCoin(coinPosition);
            }
        }
    }

    private void MakeRainbow()
    {
        //Extra challenge! Make the rainbow bigger, or smaller. Does the color still work? How could you fix it?
        for (int radius = 50; radius < 56; radius++)
        {
            Color color = Color.black;

            if (radius == 50)
                color = Color.magenta;
            if (radius == 51)
                color = Color.blue;
            if (radius == 52)
                color = Color.green;
            if (radius == 53)
                color = Color.yellow;
            if (radius == 54)
                color = new Color(1f, 0.4f, 0f);
            if (radius == 55)
                color = Color.red;

            LessonTools.MakeHalfCircle(new Vector3(0, -5, 30), radius, color);
        }
    }
}
