using UnityEngine;

public class Picture : MonoBehaviour, ITrappable
{
    [SerializeField] private float animSpeed;

    private Vector3 originalScale;
    void Awake()
    {
        originalScale = transform.localScale;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CaptureAnimation()
    {
        transform.localScale = Vector3.Lerp(transform.localScale ,Vector3.zero, Time.deltaTime * animSpeed);
    }


    public int PointValue()
    {
        return 1;

    }
    // Update is called once per frame
    void Update()
    {
       float wobble = Mathf.Sin(Time.time * 20f) *0.1f;
       transform.localScale = new Vector3(wobble, wobble, wobble) + originalScale;
    }
}
