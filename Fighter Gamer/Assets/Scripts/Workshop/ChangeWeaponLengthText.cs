using TMPro;
using UnityEngine;

public class ChangeWeaponLengthText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Length: " + statsHandler.GetComponent<StatsHandler>().WeaponLength;
    }
    public void MaxText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Length: Max";
    }
}
