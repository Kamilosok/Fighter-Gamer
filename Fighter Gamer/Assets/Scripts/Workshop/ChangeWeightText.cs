using TMPro;
using UnityEngine;

public class ChangeWeightText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Weight: " + statsHandler.GetComponent<StatsHandler>().Weight;
    }
    public void MaxText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Weight: Max";
    }
}
