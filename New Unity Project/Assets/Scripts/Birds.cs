using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Birds : MonoBehaviour
{
    public enum BirdState { Idle, Thrown, HitSomething}
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D Collider2D;

    public UnityAction OnBirdDestroyed = delegate{};
    public UnityAction<Birds> OnBirdShot = delegate{};

    public BirdState State { get { return _state; } }

    private BirdState _state;
    private float _minVelocity = 0.05f;
    private bool _flagDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        //Mematikan fungsi physics dan collider dari object burung
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        Collider2D.enabled = false;
        _state = BirdState.Idle;
    }

    void FixedUpdate()
    {
        if(_state == BirdState.Idle &&
            Rigidbody2D.velocity.sqrMagnitude >= _minVelocity)
        {
            _state = BirdState.Thrown;
        }

        if((_state == BirdState.Thrown || _state == BirdState.HitSomething) &&
            Rigidbody2D.velocity.sqrMagnitude < _minVelocity &&
            !_flagDestroy)
        {
            //Hancurkan gameobject setelah 2 detik
            //Jika kecepatannya sudah kurang dari batas minimum
            _flagDestroy = true;
            StartCoroutine(DestroyAfter(2));
        }
    }

    private IEnumerator DestroyAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    public void MoveTo(Vector2 target, GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = target;
    }

    public void Shoot(Vector2 velocity, float distance, float speed)
    {
        Collider2D.enabled = true;
        Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody2D.velocity = velocity * speed * distance;
        OnBirdShot(this);
    }

    void OnDestroy()
    {
        if(_state == BirdState.Thrown || _state == BirdState.HitSomething)
            OnBirdDestroyed();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        _state = BirdState.HitSomething;
    }

    public virtual void OnTap()
    {

    }
}
