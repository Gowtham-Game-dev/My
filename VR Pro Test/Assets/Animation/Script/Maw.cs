using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Maw : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform Target;
    public float health = 100;
    public Animator animator;
    float timer;

    void Start()
    {
        timer = 0;
        //StartCoroutine(starting());
       

    }
    void Update()
    {
       /* timer += Time.deltaTime;
        if (timer == 5)
        {
            Debug.Log("s");
            agent.enabled = true;
        }
*/

        /* 
          if (timer < 5)
          {
              agent.enabled = false;
              animator.SetBool("Patrolling", false);

          }*/
        if (agent.enabled) 
        {
             agent.SetDestination(Target.transform.position);

             animator.SetBool("Patrolling", true);
            /*  Vector3 directionToTarget =  Target.position- transform.position;
              directionToTarget.y = 0f; // Set the y component to 0 to keep the agent's rotation level

              if (directionToTarget != Vector3.zero)
              {
                  // Rotate the agent to face the target
                  Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
              }*/
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

       /* if (timer > 5)
        {
            agent.enabled = true;
            agent.SetDestination(Target.transform.position);
            animator.SetBool("Patrolling", true);
        }*/
        if (health <= 60)
        {

           // MavGetHIt();
        }
    }
    /*IEnumerator starting()
    {
        yield return new WaitForSeconds(5);
        agent.enabled = true;

    }*/
    public void GetDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
   public void MavGetHIt()
    {
      //  animator.SetBool("InjuryCheck", true);
    }
}
