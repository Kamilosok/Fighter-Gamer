using TMPro;
using UnityEngine;

public class ChangeWeaponTypeText : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[3];
    private GameObject statsHandler;
    private GameObject hero;
    public void ChangeText()
    {
        if (statsHandler == null)
            statsHandler = GameObject.Find("StatsHandler");
        if (hero == null)
            hero = GameObject.Find("Hero");

        if (statsHandler.GetComponent<StatsHandler>().WeaponType == 1)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Type: Spear ";
            for (int i = 0; i < hero.transform.childCount; i++)
            {
                hero.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
        }
        else
        if (statsHandler.GetComponent<StatsHandler>().WeaponType == 2)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Type: Sword ";
            for (int i = 0; i < hero.transform.childCount; i++)
            {
                hero.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites[1];
                if (hero.transform.GetChild(i).gameObject.GetComponent<PolygonCollider2D>() == null)
                {
                    hero.transform.GetChild(i).gameObject.AddComponent<PolygonCollider2D>();
                    hero.transform.GetChild(i).GetComponent<PolygonCollider2D>().isTrigger = true;
                    Destroy(hero.transform.GetChild(i).GetComponent<BoxCollider2D>());
                }
            }
        }
        else
        if(statsHandler.GetComponent<StatsHandler>().WeaponType == 3)
        {     
            gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Type: Axe ";
            for (int i = 0; i < hero.transform.childCount; i++)
            {
                hero.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites[2];
                Destroy(hero.transform.GetChild(i).gameObject.GetComponent<PolygonCollider2D>());
                hero.transform.GetChild(i).gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
    }
    public void MaxText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Weapon Type: Best";
    }
}
