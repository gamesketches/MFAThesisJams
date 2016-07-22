using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void ReStartScene() {
        SceneManager.LoadScene(0);
    }
}
