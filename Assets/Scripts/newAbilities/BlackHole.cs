using UnityEngine;

public class BlackHole : MonoBehaviour
{
    float pullStregnt = 3f;
    public float pullDistance;
    private float distanceFromCenter = 1f;

    private float maxPullTimer = 5f;
    private float pullTimer;

    private bool startPulling = true;


    public LayerMask enemyMask;
    void Start()
    {
        maxPullTimer = 5f;

        pullTimer = maxPullTimer;

        startPulling = true;
    }

    void Update()
    {
        if (pullTimer <= maxPullTimer)
        {
            pullTimer -= Time.deltaTime;
            if (startPulling)
            {
                Collider2D[] hitcollider = Physics2D.OverlapCircleAll(transform.position, pullDistance,enemyMask);
                foreach (Collider2D obj in hitcollider)
                {
                    if (Vector3.Distance(obj.transform.position, transform.position) > distanceFromCenter)
                    {
                       
                        
                            obj.GetComponent<Enemy>().enemyState = EnemyState.beingPulled;
                        Vector3 direction = transform.position - obj.transform.position;
                        direction.Normalize();
                        obj.transform.position += direction * pullStregnt * Time.deltaTime;
                    }
                    else if (Vector3.Distance(obj.transform.position, transform.position) <= distanceFromCenter)
                    {

                    }
                    if (pullTimer <= 0)
                    {
                            obj.GetComponent<Enemy>().enemyState = EnemyState.normal;
                    
                        Destroy(this.gameObject);
                    }

                }

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, pullDistance);
    }
}
