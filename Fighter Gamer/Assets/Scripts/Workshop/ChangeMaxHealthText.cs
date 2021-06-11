using TMPro;
using UnityEngine;

public class ChangeMaxHealthText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Max Health: " + statsHandler.GetComponent<StatsHandler>().Health;
    }
}
