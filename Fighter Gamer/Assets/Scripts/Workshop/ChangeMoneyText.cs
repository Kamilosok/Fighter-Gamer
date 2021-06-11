using TMPro;
using UnityEngine;

public class ChangeMoneyText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Money: " + statsHandler.GetComponent<StatsHandler>().Money;
    }
}
