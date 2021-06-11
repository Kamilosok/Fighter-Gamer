using UnityEngine;

public class AbilityBarHider : MonoBehaviour
{
    [System.NonSerialized]
    public  GameObject abilityBar;
    private void Start()
    {
        abilityBar=GameObject.Find("Ability_Bar");
        if (abilityBar != null)
            abilityBar.SetActive(false);
        else
            abilityBar = transform.parent.GetChild(0).GetComponent<AbilityBarHider>().abilityBar;
    }
    private void OnMouseDown()
    {
            abilityBar.SetActive(true);
    }
}
