using TMPro;
using UnityEngine;

public class ChangeMaxManaText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if(statsHandler==null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Max Mana: " + statsHandler.GetComponent<StatsHandler>().Mana;
    }
}
