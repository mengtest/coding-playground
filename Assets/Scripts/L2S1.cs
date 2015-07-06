using UnityEngine;
using System.Collections;

public class L2S1 : MonoBehaviour
{

    void Start()
    {
        Shapes noemie = Shapes.cone;
        Shapes gabrielle = Shapes.tetrahedron;
        Shapes sarah = Shapes.pyramid;
        Shapes laurence = Shapes.torus;
        Shapes lea = Shapes.sphere;

        int william = -7;
        int jeremy = 7;
        int thomas = -20;
        int xavier = -25;
        int olivier = 2;

        bool cat = true;
        bool dog = false;

        Color shrek = Color.green;
        Color hellboy = Color.red;
        Color avatar = Color.blue;

        float tiny = 0.5f;
        float medium = 1.35f;
        float jumbo = 2.2f;

        //Question: here we used "MakeShape" four times. Match up each with its sign in the 3D world: A, B, C, or D.

        //MakeShape(shape, x, y, z, canMove, color, size)

        //MakeShape #1
        LessonTools.MakeShape(noemie, william, olivier, xavier, dog, shrek, tiny);

        //MakeShape #2
        LessonTools.MakeShape(noemie, jeremy, olivier, thomas, cat, hellboy, jumbo);

        //MakeShape #3
        LessonTools.MakeShape(sarah, william, olivier, thomas, dog, avatar, tiny);

        //MakeShape #4
        LessonTools.MakeShape(laurence, jeremy, olivier, xavier, cat, hellboy, medium);

        /*
         * Extra challenge!
         * 
         * Will these lines of code work?
         * Try to figure it out, then uncomment the line of code to find out.
         * To uncomment a line, just delete the "//" part.
         * What happens if "MakeShape" needs a shape, but we give it an integer instead?
         */


        //LessonTools.MakeShape(gabrielle, 5, 20, 5, dog, avatar, jumbo);

        //LessonTools.MakeShape(gabrielle, 5, 30, 5, true, Color.magenta, 5);

        //LessonTools.MakeShape(12, 5, 30, 5, true, Color.magenta, 5);


    }

    void Awake()
    {
        MakeRandomShapes();
    }

    private void MakeRandomShapes()
    {
        //this makes all the random shapes that appear far in front of the player.
        int width = 8;
        int spacing = 4;
        int zOffset = 0;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < width; z++)
            {
                Shapes shape = LessonTools.GetRandomShape();
                Color color = LessonTools.GetRandomColor();
                Vector3 position = transform.position + new Vector3(x * spacing - width * spacing / 2, 20, z * spacing + zOffset);
                LessonTools.MakeShape(LessonTools.GetRandomShape(), position, true, color, 1);
            }
        }
    }
}
