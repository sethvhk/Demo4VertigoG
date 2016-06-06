using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    public void PlayAgain()
    {
        Debug.Log("reset!");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
