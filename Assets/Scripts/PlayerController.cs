// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class PlayerController : HealthObjects
{
    public PlayerController(MeshRenderer _renderer, string deathParticlesTag) :base(_renderer, deathParticlesTag) {}
    [SerializeField] private float speed = 1.0f; 
    [SerializeField] private GameObject projectilePrefab;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * (this.speed * Time.deltaTime));
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * (this.speed * Time.deltaTime));
        
        // Use the "down" variant to avoid spamming projectiles. Will only get
        // triggered on the frame where the key is initially pressed.
        if (Input.GetMouseButtonDown(0))
        {
            // Write your code to fire a projectile here...
            GameObject projectile = ObjectPool.SharedInstance.GetPooledObject("Player Projectile");
            if (projectile != null) { 
                projectile.transform.position = gameObject.transform.position;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    projectile.transform.LookAt(hit.point);
                }

                projectile.SetActive(true);
            }
            
        }
    }
}
  