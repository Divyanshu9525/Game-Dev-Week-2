using UnityEngine;

public class OneDAnimatorScript : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acc = 0.1f;
    public float decc = 0.5f;
    float maxRunVel = 6.0f;
    float maxWalkVel = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetLayerWeight(1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = Input.GetKey(KeyCode.W);
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        float currentMaxVelocity = sprint ? maxRunVel : maxWalkVel;

        if(forward && velocity < currentMaxVelocity)
        {
            velocity += Time.deltaTime * acc;
        }
        if(!forward && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * decc;
        }
        if(!forward && velocity < 0.0f)
        {
            velocity = 0.0f;
        }
        if(forward && sprint && velocity > currentMaxVelocity)
        {
            velocity = currentMaxVelocity;
        }
        else if(forward && velocity > currentMaxVelocity)
        {
            velocity -= Time.deltaTime * decc;
            if(velocity > currentMaxVelocity && velocity < currentMaxVelocity + 0.05f)
            {
                velocity = currentMaxVelocity;
            }
        }
        else if(forward && velocity < currentMaxVelocity && velocity > currentMaxVelocity - 0.05f){
            velocity = currentMaxVelocity;
        }
        animator.SetFloat("Velocity", velocity);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Wave");
        }
    }
}
