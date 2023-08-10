using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    //Various gun info
    public float damage = 25f;
    public float range = 0.01f;
    public float fireRate = 5f;
    //Camera for raycasting
    public Camera fpsCam;
    //Impact effects & muzzle flash
    public GameObject impactEffect;
    public float impactForce = 30f;
    //Weapon timing
    private float nextTimeToFire = 0f;
    //Animation stuff
    public Animator animator;
    public AudioSource firingSound;
    //Ammo
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Attack();
        }
        if(Input.GetButtonDown("Fire2") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            AltAttack();
        }
        void Attack() 
        {
            animator.SetTrigger("Attack");
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if(target != null) 
                {
                    target.TakeDamage(damage);
                }
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            firingSound.Play();
        }
        void AltAttack() 
        {
            animator.SetTrigger("AltAttack");
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if(target != null) 
                {
                    target.TakeDamage(damage * 2);
                }
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            firingSound.Play();
            Debug.DrawLine(fpsCam.transform.position, hit.point, Color.green, 1f);
        }
    }
}
