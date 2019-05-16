using UnityEngine;
using UnityEngine.Events;

public class Constraint : MonoBehaviour {

    public UnityEvent OnHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnHit != null)
            OnHit.Invoke();    
    }
}
