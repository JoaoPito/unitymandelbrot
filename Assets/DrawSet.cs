using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DrawSet : MonoBehaviour
{
    public Texture2D setTexture;
    public RawImage targetObj;

    public List<Color> colorList = new List<Color>();
    public Vector2 textureSize = new Vector2(512,512);

    public MainScr mainScr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawButton()
    {
        Vector2 stepSize = new Vector2( (Mathf.Abs(mainScr.realSpace.x) + Mathf.Abs(mainScr.realSpace.y)) / textureSize.x, 
                                        (Mathf.Abs(mainScr.complexSpace.x) + Mathf.Abs(mainScr.complexSpace.y)) / textureSize.y);
        mainScr.stepSize = stepSize;

        mainScr.CalculateSet();
        StartDrawing();
    }

    public void StartDrawing()
    {
        colorList = new List<Color>();
        //textureSize.x = Mathf.Sqrt(mainScr.set.Count);
        //textureSize.y = Mathf.Sqrt(mainScr.set.Count);

        Texture2D tex = new Texture2D(Mathf.FloorToInt(textureSize.x), Mathf.FloorToInt(textureSize.y));

        for (int i = 0; i < mainScr.set.Count; i++)
        {
            if (mainScr.set[i].y < 2)
            {
                colorList.Add(new Color(mainScr.set[i].y / 2,0,0));
            }
            else colorList.Add(new Color((mainScr.set[i].z / mainScr.iterations)+0.1f, (mainScr.set[i].z / mainScr.iterations)/2, 1));
        }


        for(int y = 0; y < textureSize.y; y++)
        {
            for (int x = 0; x < textureSize.x; x++)
            {
                tex.SetPixel(x, y, colorList[x + (y* Mathf.FloorToInt(textureSize.x))]);                
            }
        }

        tex.Apply();
        setTexture = tex;
        byte[] bytes = tex.EncodeToPNG();
        //Object.Destroy(tex);

        File.WriteAllBytes(Application.dataPath + "/../Assets/SavedScreen.png", bytes);

        targetObj.texture = tex;
    }
}
