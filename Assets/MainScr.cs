using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScr : MonoBehaviour
{
    public bool running = false;
    Vector2 c;
    Vector2 z;

    public Vector2 stepSize = new Vector2(0.1f,0.1f);
    public int iterations = 100;

    public Vector2 realSpace = new Vector2(-1, 1);
    public Vector2 complexSpace = new Vector2(-1, 1);

    public List<Vector3> set;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CalculateSet()
    {
        set = new List<Vector3>();

        for(c.y = complexSpace.x; c.y < complexSpace.y; c.y += stepSize.y)
        {
            for(c.x = realSpace.x; c.x < realSpace.y; c.x += stepSize.x)
            {
                z  = Vector2.zero;
                int i = 0;

                for (int j = 0; j < iterations; j++)
                {
                    Vector2 newZ = Vector2.zero;
                    newZ.x = Mathf.Pow(z.x, 2) - Mathf.Pow(z.y, 2) + c.x;//Parte real(x)
                    newZ.y = 2*(z.x*z.y) + c.y;//Parte Imaginaria(yi)

                    z = newZ;

                    i = j;

                    if (Mathf.Pow(z.x, 2) + Mathf.Pow(z.y, 2) > 4)
                    {
                        j += iterations;
                    }
                }

                //Debug.Log("c: " + c + " | z: " + z + " sqrt: "+ Mathf.Sqrt(Mathf.Pow(z.x, 2) + Mathf.Pow(z.y, 2)) + " | i: " + i);
                set.Add(new Vector3(Mathf.Sqrt(Mathf.Pow(c.x, 2) + Mathf.Pow(c.y, 2)), Mathf.Sqrt(Mathf.Pow(z.x, 2) + Mathf.Pow(z.y, 2)), i));
            }
            
        }
    }
}
