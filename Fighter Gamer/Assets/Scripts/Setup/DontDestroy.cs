using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }
}
