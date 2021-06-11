using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public float damage;
    public float weaponType=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroDamageHandler>() != null && GetComponentInParent<HeroDamageHandler>() == null) 
        {
            collision.gameObject.GetComponent<HeroDamageHandler>().DamageHandler(damage);
        }
        if (collision.gameObject.GetComponent<EnemyDamageHandler>() != null && GetComponentInParent<EnemyDamageHandler>() == null) 
        {
            collision.gameObject.GetComponent<EnemyDamageHandler>().DamageHandler(damage);
        }
    }
}
