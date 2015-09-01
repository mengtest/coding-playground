using UnityEngine;
using System.Collections;

public class L1S4 : MonoBehaviour {
	
	void Start () {
		float red, green, blue;
		Color color;

		//Cube #1
		red = 1;
		blue = 0;
		green = 0;
		color = new Color (red, green, blue);
		LessonTools.MakeCube (Secret.L1S5(), 10, 3, true, color, 2);

		//Cube #2
		red = 0;
		blue = 1;
		green = 1;
		color = new Color (red, green, blue);
		LessonTools.MakeCube (Secret.L1S5(), 10, 3, true, color, 2);

		//Cube #3
		red = 0.5f;
		blue = 0.5f;
		green = 0.5f;
		color = new Color (red, green, blue);
		LessonTools.MakeCube (Secret.L1S5(), 10, 3, true, color, 2);

		//Cube #4
		red = 0.5f;
		blue = 0;
		green = 0;
		color = new Color (red, green, blue);
		LessonTools.MakeCube (Secret.L1S5(), 10, 3, true, color, 2);

		//Cube #5
		red = 0.3f;
		blue = 0.3f;
		green = 1f;
		color = new Color (red, green, blue);
		LessonTools.MakeCube (Secret.L1S5(), 10, 3, true, color, 2);

		/* Extra challenge!
		 * 
		 * Can you make pink? Yellow? Black? White?
		 * 
		 * Try making up your own interesting colors.
		 * 
		 */
	}
}
