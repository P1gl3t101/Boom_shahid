using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickStart()
    {//91fb7b69c7f12f046d7ed1ce1ef4a1dca84ff628ea6be194
              Market();
        SceneManager.LoadScene(1);
    }

    public void OnClickNextLevel()
    {
      //  Market();
        SceneManager.LoadScene(2);
    }
    
    public void OnClickNextLevel3()
    {
      //  Market();
        SceneManager.LoadScene(3);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

   private void Market( ) {
       // Appodeal.disableNetwork((string)network, (adTypes)startepp);
        string appKey = "aff5dd4343909e599a1f2e52db155098c1ce7d950c62d14a";
        Appodeal.disableNetwork("startapp");
        Appodeal.disableNetwork("inmobi");
        Appodeal.disableNetwork("ogury");
        Appodeal.disableNetwork("adcolony"); 
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL);
        Appodeal.show(Appodeal.INTERSTITIAL);
    }
}