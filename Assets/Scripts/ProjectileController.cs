using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private int damage;
    [SerializeField] private string tagToDamage;
    [SerializeField] private string explosionTag;
     //[SerializeField] private ParticleSystem collisionParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == this.tagToDamage)
        {
            // Damage object with relevant tag. Note that this assumes the 
            // HealthManager component is attached to the respective object.
            var healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(this.damage);
            
            GameObject particles = ObjectPool.SharedInstance.GetPooledObject(explosionTag);
            if (particles != null) {
                particles.transform.position = gameObject.transform.position;
                particles.transform.rotation =  Quaternion.LookRotation(-this.velocity);
                particles.SetActive(true);
            }
            
            // Destroy self.
            gameObject.SetActive(false);
        }
    }
}

