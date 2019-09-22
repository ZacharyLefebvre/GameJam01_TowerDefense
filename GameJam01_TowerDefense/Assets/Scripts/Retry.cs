using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // doit etre call depuis le bouton RETRY!!
    public void Restart()
    {
        SceneManager.LoadScene("TowerDefense");
        // if multiple scenes
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
