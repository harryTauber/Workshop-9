// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : HealthObjects
{
    public PlayerController(MeshRenderer _renderer, string deathParticlesTag) :base(_renderer, deathParticlesTag) {}
    [SerializeField] private float speed = 1.0f; 
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;

    private Vector3 _moveDirection;
    private Vector3 _aimDirection;

    private Rigidbody _rigidbody;

    private void Start() {
        this._rigidbody = GetComponent<Rigidbody>();
        this._moveDirection = Vector3.zero;
        this._aimDirection = Vector3.forward;
    }

    private void FixedUpdate() {
        this._rigidbody.position += this._moveDirection * this.speed;
    }

    // Update is called once per frame
    private void Update()
    {
        this._moveDirection = Vector3.right * Input.GetAxis("Horizontal");

        Aim();
        
        // Use the "down" variant to avoid spamming projectiles. Will only get
        // triggered on the frame where the key is initially pressed.
        if (Input.GetMouseButtonDown(0))
        {
            // Write your code to fire a projectile here...
            GameObject projectile = ObjectPool.SharedInstance.GetPooledObject("Player Projectile");
            if (projectile != null) { 
                projectile.transform.position = gameObject.transform.position;
                projectile.transform.rotation = Quaternion.LookRotation(_-aimDirection);
                projectile.SetActive(true);

                
            }
            
        }
    }

    private void Aim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
             var target = ray.GetPoint(hit.distance);
            this._aimDirection = (target - gameObject.transform.position).normalized;
            gameObject.transform.LookAt(hit.point);
        }
    }
}
  