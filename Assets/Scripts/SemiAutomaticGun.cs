using UnityEngine;

public class SemiAutomaticGun : MonoBehaviour
{
    //Various gun info
    public float damage = 40f;
    public float range = 100f;
    public float fireRate = 5f;
    //Camera for raycasting
    public Camera fpsCam;
    //Impact effects & muzzle flash
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    //Weapon timing
    private float nextTimeToFire = 0f;
    //Animation stuff
    public Animator animator;
    public AudioSource firingSound;
    //Ammo
    public float ammo = 25f;
    public float magsize = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && ammo > 0)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        if(Input.GetButtonDown("Reload"))
        {
            Reload();
        }
        void Shoot() 
        {
            animator.SetTrigger("Shoot");
            muzzleFlash.Play();
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
                ammo -= 1f;
            }
            firingSound.Play();
        }
    }
    void Reload()
        {
            animator.SetTrigger("Reload");
            ammo = magsize;
        }
}
