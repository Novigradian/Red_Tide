using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurretShooting : MonoBehaviour
{
    [SerializeField] private Transform gunPointLeft;
    [SerializeField] private Transform gunPointRight;
    [SerializeField] private GameObject bulletTrail;

    [SerializeField] private float fireRate;
    [SerializeField] private float range;

    [SerializeField] private Animator muzzleFlashAnimatorLeft;
    [SerializeField] private Animator muzzleFlashAnimatorRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //muzzleFlashAnimatorLeft.SetTrigger("Shoot");
        //muzzleFlashAnimatorRight.SetTrigger("Shoot");

        var hitLeft = Physics2D.Raycast(gunPointLeft.position, transform.up);
        var hitRight= Physics2D.Raycast(gunPointRight.position, transform.up);

        var trailLeft = Instantiate(bulletTrail, gunPointLeft.position, transform.rotation);
        var trailRight = Instantiate(bulletTrail, gunPointRight.position, transform.rotation);

        BulletTrail trailScriptLeft = trailLeft.GetComponent<BulletTrail>();
        BulletTrail trailScriptRight = trailRight.GetComponent<BulletTrail>();

        if (hitLeft.collider != null)
        {
            trailScriptLeft.SetEndPosition(hitLeft.point);

        }
        else
        {
            trailScriptLeft.SetEndPosition(gunPointLeft.position + transform.up * range);
        }

        if (hitRight.collider != null)
        {
            trailScriptRight.SetEndPosition(hitRight.point);

        }
        else
        {
            trailScriptRight.SetEndPosition(gunPointRight.position + transform.up * range);
        }
    }
}
