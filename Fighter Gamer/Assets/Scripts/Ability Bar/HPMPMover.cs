using UnityEngine;
using UnityEngine.UI;

public class HPMPMover : MonoBehaviour
{
    [SerializeField]
    bool ifMP;
    [SerializeField]
    private float minVal;
    [SerializeField]
    private Transform newCanvas;
    private Slider slider;
    private void Start()
    {
        slider = GetComponentInParent<Transform>().GetComponentInParent<Slider>();
    }
    private void Update()
    {
        if (slider.value <= minVal)
        {
            Relocate();
        }
    }
    public void Relocate()
    {
        transform.SetParent(newCanvas, true);
        if (ifMP)
            transform.localPosition = new Vector3(-295f, -131.25f, -1);
        else
            transform.localPosition = new Vector3(-295f, -121.25f, -1);

        enabled = false;
    }    
}
