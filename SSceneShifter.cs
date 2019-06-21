using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSceneShifter : MonoBehaviour
{
    // Start is called before the first frame update
    public void ShiftScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }
}
