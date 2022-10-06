using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(MeshRenderer))]
public class EnemyController : HealthObjects
{
    public EnemyController(MeshRenderer _renderer, string deathParticlesTag) :base(_renderer, deathParticlesTag) {}
    [SerializeField] private int minIdleTime=5;
    [SerializeField] private int maxIdleTime=12;
    //[SerializeField] private string target;
    private float idleTime;
    
    private void Start() {
        Random rnd = new Random();
        idleTime = rnd.Next(minIdleTime,maxIdleTime);
        StartCoroutine(FireAtPlayer());
    }

    private IEnumerator FireAtPlayer() {
        while (true) {
            yield return new WaitForSeconds(idleTime);
            if(GameObject.Find("Player") == null) {yield break;}
            generateProjectile();
        }
    }

    private void generateProjectile() {
        GameObject projectile = ObjectPool.SharedInstance.GetPooledObject("Enemy Projectile");
        if (projectile != null) { 
            projectile.transform.position = gameObject.transform.position;
            projectile.transform.LookAt(GameObject.Find("Player").transform.position);
            projectile.SetActive(true);
        }
    }


    
}
