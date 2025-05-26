using System.Collections;
using UnityEngine;

public class TrapObject : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if(other.TryGetComponent<ITrappable>(out ITrappable pals))
        {
            StartCoroutine(Capture(pals));
        }
    }

    IEnumerator Capture(ITrappable pals)
    {
        while(true) 
        {
            rb.isKinematic = true;
            transform.rotation *= Quaternion.AngleAxis(Time.deltaTime, Vector3.up);

            pals.CaptureAnimation();
            yield return null;
        }
    }
}
