using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject enemyObject;
    private IEnumerator coroutine;
    private float cooldownSeconds;
    private float manaCost;
    private bool ready;
    private void Start()
    {
        cooldownSeconds = 2;
        manaCost = 0.5f;
        ready = true;
        playerObject = GameObject.Find("Hero");
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        coroutine = Cooldown(cooldownSeconds);
    }
    private void OnMouseDown()
    {
        if (enemyObject != null && ready && playerObject.GetComponent<HeroManaHandler>().Mana-manaCost>=0)
        {
            ready = false;
            playerObject.GetComponent<HeroManaHandler>().ManaHandler(manaCost);
            Vector2 dashDirection = new Vector2(enemyObject.transform.position.x, enemyObject.transform.position.y) - playerObject.GetComponent<Rigidbody2D>().position;
            playerObject.GetComponent<Rigidbody2D>().AddForce(dashDirection * 100 * playerObject.GetComponent<Rigidbody2D>().mass);
            coroutine = Cooldown(cooldownSeconds);
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator Cooldown(float time)
    {
        float counter = -time;
        while (true)
        {
            if (counter == 0)
            {
                ready = true;
                StopCoroutine(coroutine);
            }
            transform.GetComponentInChildren<Slider>().value = counter + cooldownSeconds;
            counter += 1;
            yield return new WaitForSeconds(1);
        }
    }

}
