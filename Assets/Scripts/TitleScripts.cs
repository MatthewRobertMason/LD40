using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScripts : MonoBehaviour
{
    public GameObject splashScreen = null;

    public void clearSplashScreen()
    {
        splashScreen.SetActive(false);
    }

    public void showSplashScreen()
    {
        splashScreen.SetActive(true);
    }
}
