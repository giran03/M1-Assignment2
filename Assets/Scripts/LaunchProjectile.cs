using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_controller : MonoBehaviour
{
    [Header("Configs")]
    public float projectileSpeed;
    public GameObject cannon_ball;

    private void Start()
    {
        InvokeRepeating("LaunchProjectile", 2f, 1f);
    }
    void LaunchProjectile()
    {
        GameObject cannonBall = Instantiate(cannon_ball, transform.position, transform.rotation);
        cannonBall.GetComponent<Rigidbody>().AddForce(10f * projectileSpeed * transform.up, ForceMode.Force);

        Destroy(cannonBall, 2f);
    }
}
