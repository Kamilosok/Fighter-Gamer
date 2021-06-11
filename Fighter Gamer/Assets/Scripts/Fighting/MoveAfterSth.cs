using UnityEngine;

public class MoveAfterSth : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    void Start()
    {
        ;
    }

    void Update()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 1);
    }
}
