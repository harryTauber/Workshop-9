// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem targetParticleSystem;
    // Check if particles are destroyed every update
    private void Update() {
        if (!this.targetParticleSystem.IsAlive()) {
            this.targetParticleSystem.gameObject.SetActive(false);
        }
    }
}