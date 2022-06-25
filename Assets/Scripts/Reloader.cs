using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Reloader : MonoBehaviour
{
    public UnityEvent BeforeReload;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        BeforeReload?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
