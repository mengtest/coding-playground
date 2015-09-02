using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class L1S6 : MonoBehaviour
{

	void Start ()
	{
		int height, xOffset, zOffset;

		//Sign #1
		height = 5;
		xOffset = -10;
		zOffset = 20;
		for (int j = 0; j < height; j++) {
			for (int i = j - height; i < height - j - 1; i++) {
				for (int k = j - height; k < height - j - 1; k++) {
					LessonTools.MakeCube (i + xOffset, j, k + zOffset, true, Color.red, 1);
				}
			}
		}

		//Sign #2
		height = 7;
		xOffset = 0;
		zOffset = 15;
		for (int j = 0; j < height; j++) {
			for (int i = 0; i < height - j; i++) {
				LessonTools.MakeCube (i + xOffset, j, 0 + zOffset, true, Color.yellow, 1);
			}
		}

		//Sign #3
		height = 4;
		xOffset = 10;
		zOffset = 15;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < height; j++) {
				for (int k = 0; k < height; k++) {
					LessonTools.MakeCube (i + xOffset, j, k + zOffset, true, Color.cyan, 1);
				}
			}
		}

		MakeRainbow ();
	}

	private void MakeRainbow ()
	{
		Color color;

		/* Extra challenge!
         * 
         * Did you notice the rainbow in the sky? Its colors are wrong though.
         * 
         * Look at the for loop below. Any code written inside it will happen six times.
         * The first time, radius equals 40. After that, radius equals 41, then 42, 43, 44, and 45.
         *      
         * Go to the internet and look at a picture of a rainbow. Can you make a good looking cube-rainbow?
         * The only thing you need to do is adjust the color according to the radius. Hint:
         * 
         */

		for (int radius = 40; radius < 46; radius++)
		{
			color = LessonTools.GetRandomColor();
			if (radius == 40)
				color = Color.magenta;
			if (radius == 41)
				color = Color.blue;
			if (radius == 42)
				color = Color.green;
			if (radius == 43)
				color = Color.yellow;
			if (radius == 44)
				color = new Color(1f, 0.5f, 0f);
			if (radius == 45)
				color = Color.red;
			LessonTools.MakeHalfCircle(new Vector3(0, 0, 20), radius, color);
		}
	}


}
