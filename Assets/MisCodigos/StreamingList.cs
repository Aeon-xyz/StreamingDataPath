using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class StreamingList : MonoBehaviour {

    public GameObject FlechaD;
    public GameObject FlechaI;


    public Image misPersonas;
    public int numP;
    public int indice;


    string imagesDirectory = "";
    public List<Sprite> sprites = new List<Sprite>();


    void Start()
    {


        numP = 0;

        imagesDirectory = Application.streamingAssetsPath + "/MisImagenes";
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(imagesDirectory);
        System.IO.FileInfo[] info = dir.GetFiles("*.jpg");

        string finalPath;
        WWW localFile;
        Texture texture;
        Sprite sprite;




        foreach (FileInfo fi in info)
        {

            string imageName = Path.GetFileName(fi.Name);

            finalPath = "file://" + Application.streamingAssetsPath + "/MisImagenes/" + imageName;
            localFile = new WWW(finalPath);



            texture = localFile.texture;
            sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            sprites.Add(sprite);

        }

        Debug.Log(sprites.Count);
        misPersonas.sprite = sprites[numP];
        FlechaD.SetActive(true);
        FlechaI.SetActive(false);


    }

    public void FDsumar()
    {

        numP = numP + 1;
        if (numP <= sprites.Count - 1)
        {
            misPersonas.sprite = sprites[numP];
            if (numP == sprites.Count - 1)
            {
                FlechaD.SetActive(false);
                FlechaI.SetActive(true);
            }
            else
            {
                FlechaD.SetActive(true);
                FlechaI.SetActive(true);
            }
        }
        else
        {
            numP = sprites.Count - 1;
            FlechaD.SetActive(false);
        }

    }



    public void FIrestar()

    {

        numP = numP - 1;
        if (numP <= sprites.Count - 1 && numP >= 0)
        {
            misPersonas.sprite = sprites[numP];
            if (numP == 0)
            {
                FlechaD.SetActive(true);
                FlechaI.SetActive(false);
            }
            else
            {
                FlechaD.SetActive(true);
                FlechaI.SetActive(true);
            }
        }
        else
        {
            numP = 0;
            FlechaI.SetActive(false);
        }

    }


}
