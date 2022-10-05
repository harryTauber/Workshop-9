using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class EnemyController : MonoBehaviour
{

    private MeshRenderer _renderer;
    [SerializeField] private ParticleSystem deathParticles;

    private void Awake()
    {
        this._renderer = gameObject.GetComponent<MeshRenderer>();
    }

    // This method listens to HealthManager "onHealthChanged" events. The actual
    // event listening is set up within the editor interface. This is purely for
    // visuals currently, and takes a fractional value between 0 and 1.
    public void UpdateHealth(float frac)
    {
        this._renderer.material.color = Color.red * frac;
    }

    // Same as above, but listens to onDeath events.
    public void Kill()
    {
        GameObject particles = ObjectPool.SharedInstance.GetPooledObject("Enemy Explosion");
        if (particles != null) {
            particles.transform.position = gameObject.transform.position;
            particles.SetActive(true);
        }
        
    }
}
