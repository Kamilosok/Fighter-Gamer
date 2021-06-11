using TMPro;
using UnityEngine;

public class ChangeArmorText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Armor: " + statsHandler.GetComponent<StatsHandler>().Armor;
    }
}
