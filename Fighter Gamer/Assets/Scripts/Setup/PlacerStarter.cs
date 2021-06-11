using UnityEngine;

public class PlacerStarter : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Hero");
        GameObject clone=Instantiate(player,transform);
        clone.transform.SetPositionAndRotation(transform.position, new Quaternion());
        for (int i = 0; i < clone.transform.childCount; i++)
        {
            if(clone.transform.GetChild(i).GetComponent<Spin>()!=null)
                clone.transform.GetChild(i).GetComponent<Spin>().enabled = false;
        }
        Destroy(clone.GetComponent<Rigidbody2D>());
        Destroy(clone.GetComponent<CircleCollider2D>());
        Destroy(clone.GetComponent<BounceOffEnemy>());
        Destroy(clone.GetComponent<HeroDamageHandler>());
        Destroy(clone.GetComponent<HeroManaHandler>());
        Destroy(clone.GetComponent<Braking>());
        clone.SetActive(false);
    }
    private void OnMouseDown()
    {
        player.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        GameObject[] ToDestroy = GameObject.FindGameObjectsWithTag("ToDestroy");
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] Weapons = GameObject.FindGameObjectsWithTag("Weapon");
        player.GetComponent<CircleCollider2D>().enabled = true;
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].gameObject.GetComponent<EnemyAI>().enabled = true;
            Enemies[i].gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].gameObject.GetComponent<Spin>().enabled = true;
        }
        for (int i = 0; i < ToDestroy.Length; i++)
        {
            Destroy(ToDestroy[i]);
        }
    }
    private void OnMouseEnter()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
