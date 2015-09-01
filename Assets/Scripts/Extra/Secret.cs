using UnityEngine;
using System.Collections;

//For challenges where students must match up code with a sign in game, eventually it's easier just to look at coordinates to "cheat".
//This obfuscates the coordinates. Students that are competent enough to cheat anyway probably deserve to.

public static class Secret {

	private static int[] a = new int[5]{-10,5,10,-5,0};
	private static int aCounter=0;

	public static int L1S5(){
		int result = a [aCounter];
		aCounter = (aCounter + 1) % a.Length;
		return result;
	}
}
