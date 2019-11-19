using UnityEngine.SceneManagement;
using UnityEngine;

public class move : MonoBehaviour
{
    // private object videoPlayer;


    public void Skip() {

        SceneManager.LoadScene(1);
    }

    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = true;
        
        videoPlayer.Play();
      
    }

   
    // Update is called once per frame
    void Update()
    {
         
    }
}
