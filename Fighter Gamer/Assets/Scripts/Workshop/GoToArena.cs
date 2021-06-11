using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToArena : MonoBehaviour
{
    private GameObject statsHandler;
    public void Onclick()
    {
        statsHandler = GameObject.Find("StatsHandler");
        SceneManager.LoadScene(statsHandler.GetComponent<StatsHandler>().sceneNumber);
    }
}
