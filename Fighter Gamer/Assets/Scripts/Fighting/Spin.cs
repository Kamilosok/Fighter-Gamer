using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speedOfSpin;
    public bool ifSpin;
    private Transform Transformers;
    private void Start()
    {
        Transformers = gameObject.GetComponent<Transform>();
        ifSpin = true;
    }
   private void FixedUpdate()
    {
        Transformers.transform.eulerAngles = new Vector3(0, 0, Transformers.transform.eulerAngles.z + speedOfSpin * Time.fixedDeltaTime);
        if(!ifSpin)
        {
            speedOfSpin -= 5;
            if(speedOfSpin<=0)
            {
                speedOfSpin = 0;
                ifSpin = true;
            }
        }
    }
}
