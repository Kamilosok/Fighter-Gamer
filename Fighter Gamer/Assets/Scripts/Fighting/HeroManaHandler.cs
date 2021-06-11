using UnityEngine.UI;
using UnityEngine;

public class HeroManaHandler : MonoBehaviour
{
    public float Mana;
    [System.NonSerialized]
    public GameObject Bar;
    public void ManaHandler(float cost)
    {
        Mana -= cost;
        ChangeBar();
    }
    private void ChangeBar()
    {
        Bar.transform.GetChild(0).GetComponent<Slider>().value = Mana;
    }
    private void SetBar()
    {
        if (Bar != null)
        {
            Bar.transform.GetChild(0).GetComponent<Slider>().maxValue = Mana;
            Bar.transform.GetChild(0).GetComponent<Slider>().value = Mana;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        Invoke(nameof(SetBar), 0.1f);
    }
}
