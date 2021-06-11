using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    private GameObject playerObject;
    private bool ready;
    private IEnumerator coroutine;
    private int cooldownSeconds;
    private float manaCost;
    private float scaleIncreaser;
    private void Start()
    {
        manaCost = 2f;
        scaleIncreaser = 2;
        cooldownSeconds = 5;
        ready = true;
        playerObject = GameObject.Find("Hero");
    }
    private void OnMouseDown()
    {
        if (ready && playerObject.GetComponent<HeroManaHandler>().Mana - manaCost >= 0)
        {
            playerObject.GetComponent<HeroManaHandler>().ManaHandler(manaCost);
            coroutine = Active(cooldownSeconds);
            for (int i = 0; i < playerObject.transform.childCount; i++)
            {
                playerObject.transform.GetChild(i).transform.localScale *= scaleIncreaser;
            }
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
    private IEnumerator Active(float time)
    {
        ready = false;
        float counter = time;
        while (true)
        {
            if (counter == 0)
            {
                for (int i = 0; i < playerObject.transform.childCount; i++)
                {
                    playerObject.transform.GetChild(i).transform.localScale *= 1/scaleIncreaser;
                }
                StopCoroutine(coroutine);
                coroutine = Cooldown(cooldownSeconds);
                StartCoroutine(coroutine);
            }
            transform.GetComponentInChildren<Slider>().value = counter;
            counter -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
