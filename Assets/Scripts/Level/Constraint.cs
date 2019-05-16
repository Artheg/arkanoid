using UnityEngine;
using UnityEngine.Events;

public class Constraint : MonoBehaviour {

    public UnityEvent OnHit;
    public UnityEvent OnTriggerHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnHit != null)
            OnHit.Invoke();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (OnTriggerHit != null)
            OnTriggerHit.Invoke();    
    }
}
