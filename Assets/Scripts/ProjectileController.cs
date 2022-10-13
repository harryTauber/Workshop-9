using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private int damage;
    [SerializeField] private string tagToDamage;
    [SerializeField] private string explosionTag;

    private Rigidbody _rigidbody;
     //[SerializeField] private ParticleSystem collisionParticles;
    // Start is called before the first frame update
    void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.velocity = this.velocity;
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

    public void SetVelocity(Vector3 velocity)
    {
        this._rigidbody.velocity = velocity;
    }
}

