using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Birds
{
    [SerializeField]
    public float _boostForce = 100;
    public bool _hasBoost = false;

    public void Boost()
    {
        if(State == BirdState.Thrown && !_hasBoost)
        {
            Rigidbody2D.AddForce(Rigidbody2D.velocity * _boostForce);
            _hasBoost = true;
        }
    }

    public override void OnTap()
    {
        Boost();
    }
}
