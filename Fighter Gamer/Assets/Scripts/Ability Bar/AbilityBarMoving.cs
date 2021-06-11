using UnityEngine;
using System.Collections;

public class AbilityBarMoving : MonoBehaviour
{
    private Transform abilityBar;
    private IEnumerator coroutine;
    [SerializeField]
    private float moveSpeedRight, moveSpeedLeft;
    private void Start()
    {
        abilityBar = GameObject.Find("Ability_Bar").transform;
        moveSpeedLeft *= 0.06f;
        moveSpeedRight *= 0.06f;
    }
    private void OnMouseEnter()
    {
        if(coroutine!=null)
            StopCoroutine(coroutine);
        coroutine = MoveAndWait1(-8.38f);
        StartCoroutine(coroutine);
    }
    private void OnMouseExit()
    {
        coroutine = Wait4(4);
        StartCoroutine(coroutine);
        coroutine = MoveAndWait2(-10.68f);
        StartCoroutine(coroutine);
    }
    private IEnumerator MoveAndWait1(float targetX)
    {
        while (abilityBar.position.x < targetX)
        {
            abilityBar.SetPositionAndRotation(new Vector3(abilityBar.position.x + moveSpeedRight, abilityBar.position.y, abilityBar.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(coroutine);
    }
    private IEnumerator MoveAndWait2(float targetX)
    {
        while (abilityBar.position.x > targetX)
        {
            abilityBar.SetPositionAndRotation(new Vector3(abilityBar.position.x - moveSpeedLeft, abilityBar.position.y, abilityBar.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(coroutine);
    }
    private IEnumerator Wait4(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
