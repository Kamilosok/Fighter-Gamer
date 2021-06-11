using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Ability3 : MonoBehaviour
{
    private GameObject playerObject;
    private IEnumerator coroutine;
    private int cooldownSeconds;
    private float manaCost;
    private bool ready;
    private float speedIncreaser;
    void Start()
    {
        manaCost = 1;
        speedIncreaser = 2;
        ready = true;
        cooldownSeconds = 5;
        playerObject = GameObject.Find("Hero");
        coroutine = Active(cooldownSeconds);
    }
    private void OnMouseDown()
    {
        if (ready && playerObject.GetComponent<HeroManaHandler>().Mana - manaCost >= 0)
        {
            playerObject.GetComponent<HeroManaHandler>().ManaHandler(manaCost);
            coroutine = Active(cooldownSeconds);
            for (int i = 0; i < playerObject.transform.childCount; i++)
            {
                if (playerObject.transform.GetChild(i).GetComponent<Spin>() != null)
                    playerObject.transform.GetChild(i).GetComponent<Spin>().speedOfSpin *= speedIncreaser;
            }
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator Cooldown(float time)
    {
        float counter = -time;
        while(true)
        {
            if(counter==0)
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
                    if (playerObject.transform.GetChild(i).GetComponent<Spin>() != null)
                        playerObject.transform.GetChild(i).GetComponent<Spin>().speedOfSpin *= 1/speedIncreaser;
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
