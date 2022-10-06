using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObjects : MonoBehaviour
{
    private MeshRenderer _renderer;
    [SerializeField] private string deathParticlesTag;

    public HealthObjects(MeshRenderer _renderer, string deathParticlesTag) {
        this._renderer = _renderer;
        this.deathParticlesTag = deathParticlesTag;
    }

    private void Awake()
    {
        this._renderer = gameObject.GetComponent<MeshRenderer>();
    }

    // This method listens to HealthManager "onHealthChanged" events. The actual
    // event listening is set up within the editor interface. This is purely for
    // visuals currently, and takes a fractional value between 0 and 1.
    public void UpdateHealth(float frac)
    {
        this._renderer.material.color *= frac;
    }

    // Same as above, but listens to onDeath events.
    public void Kill()
    {
        GameObject particles = ObjectPool.SharedInstance.GetPooledObject(deathParticlesTag);
        if (particles != null) {
            particles.transform.position = gameObject.transform.position;
            particles.SetActive(true);
        }
    }
        
}
