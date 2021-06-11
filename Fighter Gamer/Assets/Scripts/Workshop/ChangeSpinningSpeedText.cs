using TMPro;
using UnityEngine;

public class ChangeSpinningSpeedText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Spinning Speed: " + statsHandler.GetComponent<StatsHandler>().SpeedOfSpin;
    }
}
