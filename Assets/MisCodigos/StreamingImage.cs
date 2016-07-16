using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class StreamingImage : MonoBehaviour {

    public GameObject FlechaD;
    public GameObject FlechaI;
    public Image misPersonas;
    public int numP;
    public int indice;
    public System.IO.FileInfo[] info;
    public Sprite sprite;
    string imagesDirectory = "";



    void Start()
    {


        numP = 0;

        imagesDirectory = Application.streamingAssetsPath + "/MisImagenes";
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(imagesDirectory);
        info = dir.GetFiles("*.jpg");

        creasprite(numP);

        misPersonas.sprite = sprite;
        FlechaD.SetActive(true);
        FlechaI.SetActive(false);


    }

    public void FDsumar()
    {

        numP = numP + 1;


        if (numP <= info.Length - 1)
        {
            creasprite(numP);
            misPersonas.sprite = sprite;
            if (numP == info.Length - 1)
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
            numP = info.Length - 1;
            FlechaD.SetActive(false);
        }

    }



    public void FIrestar()

    {

        numP = numP - 1;

      

        if (numP <= info.Length - 1 && numP >= 0)
        {
            creasprite(numP);
            misPersonas.sprite = sprite;
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


    public void creasprite(int indice)
    {
        string finalPath;
        WWW localFile;
        Texture texture;

        string imageName = Path.GetFileName(info[indice].Name);

        finalPath = "file://" + Application.streamingAssetsPath + "/MisImagenes/" + imageName;
        localFile = new WWW(finalPath);



        texture = localFile.texture;
        sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

    }

}
