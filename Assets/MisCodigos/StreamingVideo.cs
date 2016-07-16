using UnityEngine;
using System.Collections;

public class StreamingVideo : MonoBehaviour {

    public MeshRenderer meshRenderer;
  
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(loadAndPlay());
    }

    IEnumerator loadAndPlay()
    {
        WWW diskMovieDir = new WWW("file://" + Application.streamingAssetsPath + "/MisVideos/glitch.ogv");

      
        while (!diskMovieDir.isDone)
        {
            yield return null;
        }

       
        MovieTexture movieToPlay = diskMovieDir.movie;

    
        MeshRenderer ren = meshRenderer;
        ren.material.mainTexture = movieToPlay;

        movieToPlay.Play();
    }

}
