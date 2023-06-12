
using UnityEngine;
using UnityEngine.AI;
public class NormalEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform President;
    GunAutoShoot EnemyGun;
    AudioSource EnemyAudioSrc;
    [SerializeField]float EnemySpeed = 45f;
    [SerializeField]float DistanceToPresident;
    [SerializeField]bool isAssassin;
    [SerializeField]bool isBomber;
    //bomber stuff
    [SerializeField]GameObject BoomEffect;
    [SerializeField]float BomberAffectRadius;
    AudioClip BomberSound;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        President = GameObject.FindGameObjectWithTag("President").GetComponent<Transform>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = EnemySpeed;
        if(isAssassin)
        {
            EnemyGun = gameObject.transform.GetChild(0).GetComponent<GunAutoShoot>();
        }
        if(isBomber)
        {
            EnemyAudioSrc = GetComponent<AudioSource>();
            BomberSound = Resources.Load<AudioClip>("explosion");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, President.position) > DistanceToPresident)
        {
            agent.SetDestination(President.position);
        }
        if(Vector2.Distance(transform.position, President.position) <= DistanceToPresident)
        {
            if(isAssassin)
            {
                agent.SetDestination(transform.position);
                EnemyGun.Fire();
            }
            if(isBomber)
            {
                agent.SetDestination(President.position);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(isBomber)
        {
            if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("President") || other.gameObject.CompareTag("Shield"))
            {
                Instantiate(BoomEffect, transform.position, Quaternion.identity);
                EnemyAudioSrc.PlayOneShot(BomberSound);
                Collider2D[] affectedObjects = Physics2D.OverlapCircleAll(transform.position, BomberAffectRadius);
                foreach(Collider2D affectedObject in affectedObjects)
                {
                    if(affectedObject.CompareTag("Player"))
                    {
                        Destroy(affectedObject.gameObject);
                    }
                    if(affectedObject.CompareTag("President"))
                    {
                        Destroy(affectedObject.gameObject);
                    }
                    if(affectedObject.CompareTag("Enemy"))
                    {
                        Destroy(affectedObject.gameObject);
                    }
                    if(affectedObject.CompareTag("Citizen"))
                    {
                        Destroy(affectedObject.gameObject);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DistanceToPresident);
        Gizmos.DrawWireSphere(transform.position, BomberAffectRadius);
    }
}
