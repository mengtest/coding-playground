using UnityEngine;
using System.Collections;

public class L2S4 : MonoBehaviour
{
    private GameObject cursorCube;
    private GameObject player;
    private float clickRange = 10;
    private ArrayList occupiedCoordinates;

    void Start()
    {
        
        //You don't always need to understand code to fix it.

        //Generally, every line of code that does not start with "if" or "for" or "while"
        //must end with a semicolon ";". Not a colon ":" but a semicolon ";".

        //Exercise 1:
        //Delete the line "/*"
        //Delete the line "*/"
        //Read the four lines of code, and add a semicolon if needed.

        /*

        cursorCube = LessonTools.MakeCube(0, 0, 0, false, Color.white, 1)
        ParentChildFunctions.SetCollidersOfChildren(cursorCube, false, true);
        player = Camera.main.transform.gameObject
        occupiedCoordinates = new ArrayList()
    
         */


    }

    private void MakeCube(Vector3 position)
    {
        //Exercise 2:
        //Delete the line "/*"
        //Delete the line "*/"
        //Sometimes pieces of code are underlined in red. This usually means there
        //is a typo. Carefully read every letter of code here, and fix the typo!

        /*

        LessonTools.MakeCube(position, false, Colr.magenta, 1);
        occupiedCoordinates.Add(position);

        */

    }

    private bool CanPlaceBlockHere(Vector3 position)
    {
        //The computer can see a syntax error, but it cannot see logic errors.
        //Only a programmer can fix a logic error in a computer program.

        //We don't want to ever place blocks if the y coordinate is below the floor.

        //Exercise 3:
        //Right now, when position.y <= 0, we "return true".
        //This means that when a position is below the floor, CanPlaceBlockHere is true.
        //Fix the code so we "return false" when our position is below the floor.

        if (position.y <= 0)
            return true;

        if (Vector3.Distance(player.transform.position, position) < 2)
            return false;

        if (occupiedCoordinates.Contains(position))
            return false;

        return true;
    }

    private void DestroyLookedAtCube()
    {
        RaycastHit rayInfo;
        Vector3 origin = player.transform.position;
        Vector3 lookDirection = Camera.main.transform.forward;
        if (Physics.Raycast(origin, lookDirection, out rayInfo, clickRange))
            if (rayInfo.collider.gameObject.name.Contains("blank cube"))
                Destroy(rayInfo.collider.gameObject);
    }

    private Vector3 GetCursorCoordinates()
    {
        RaycastHit rayInfo;
        Vector3 origin = player.transform.position;
        Vector3 lookDirection = Camera.main.transform.forward;
        Vector3 result = Vector3.zero;
        if (Physics.Raycast(origin, lookDirection, out rayInfo, clickRange))
        {
            for (int i = 0; i < 3; i++)
                result[i] = Mathf.FloorToInt(rayInfo.point[i] + 0.45f + rayInfo.normal[i]);

            if (rayInfo.normal.x < -0.5)
                result.x++;
            if (rayInfo.normal.y < -0.5)
                result.y++;
            if (rayInfo.normal.z < -0.5)
                result.z++;
        }
        //This adjustment is because the cube's center is not at its base.
        return result - new Vector3(0, 0.5f, 0);
    }

    void Update()
    {
        //Every open bracket must eventually be followed by a matching closing bracket.
        //A bracket can be regular "( )" or curly "{ }".

        //Exercise 4:
        //Delete the line "/*"
        //Delete the line "*/"
        //Find a line of code where there are more open brackets "(" than closing brackets ")" and add the closing bracket.
        //Also, read my comment below and follow the instructions.

        /*

        Vector3 cursorCoordinates = GetCursorCoordinates();

        if (Input.GetMouseButtonDown(1)
            DestroyLookedAtCube();
        
        if (CanPlaceBlockHere(cursorCoordinates))
        {
            cursorCube.transform.position = cursorCoordinates;
            if (Input.GetMouseButtonDown(0))
                MakeCube(cursorCoordinates);
        
        
        //The "if" statement above started an open curly bracket "{" but never closed it.
        //Add a closing curly bracket "}" just before this comment.



        */
        
    }
}


//Extra challenge
//In the short method called "MakeCube", the color is always magenta.
//Why not change the color, or make it a random color? Or make it gradually darker?