using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static void LoadLevel(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
