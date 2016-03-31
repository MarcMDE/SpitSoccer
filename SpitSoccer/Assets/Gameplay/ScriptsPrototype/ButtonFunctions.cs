using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour 
{
    public void LevelReset ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("ButtonClicked");
    }
}
