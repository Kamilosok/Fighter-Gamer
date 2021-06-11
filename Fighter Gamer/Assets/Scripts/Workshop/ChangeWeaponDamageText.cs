using TMPro;
using UnityEngine;

public class ChangeWeaponDamageText : MonoBehaviour
{
    private GameObject statsHandler;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Damage: " + statsHandler.GetComponent<StatsHandler>().WeaponDamage;
    }
}
