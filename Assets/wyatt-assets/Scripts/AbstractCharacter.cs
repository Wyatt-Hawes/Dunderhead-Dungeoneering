using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(clickToMove))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class AbstractCharacter : MonoBehaviour
{
    public bool CameraFollowing = false;
    // You should implement the ability code in here
    public abstract void UseAbility();

    // You should implement the flaw code in here
    public abstract void FlawOccurs();

    // The character should take some damage;
    public abstract void takeDamage(float damage);

    public abstract void onDeath();
}
