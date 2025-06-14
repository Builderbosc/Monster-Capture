using UnityEngine;

public class TimeReductionAttacker : MonoBehaviour
{
    [SerializeField] private float timeReduction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void DealDamage(GameObject victim)
    {
        if (victim.GetComponent<TimeReductionReciever>() && victim.layer != gameObject.layer)
        {
            victim.GetComponent<TimeReductionReciever>().TakeTimeReduction(timeReduction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        DealDamage(collision.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        DealDamage(other);
    }
}
