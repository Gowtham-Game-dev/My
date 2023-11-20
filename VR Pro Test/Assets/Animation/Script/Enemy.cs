using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
   // public NavMeshAgent agent;
    public Transform Target;
    public float health = 1;
    public float maxHealth = 1;
    
    public Animator animator;
    public GameObject[] WizardParticle;
    public Transform[] Particle;
    public bool injuryTriggered=false;
    public GameObject DeathParticle;

    public Image bar;
   
    private float instantiationInterval = 5f;
    private float timer = 0f;

    // public GameObject arrow;
    public  static Enemy Instance;
    private void  Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
        
       
        
       
    }
    void Update()
    {
        // WizardParticle.SetActive(true);
        foreach (GameObject particle in WizardParticle)
        {
            Vector3 targetPosition = Target.position;
            Vector3 particlePosition = particle.transform.position;

           
            Vector3 newPosition = Vector3.MoveTowards(particlePosition, targetPosition, 1 * Time.deltaTime);

           
            particle.transform.position = newPosition;
        }

        timer += Time.deltaTime;

        if (timer >= instantiationInterval)
        {
            InstantiateRandomChild();
            timer = -2.5f;
        }

        if (Target != null)
        {
            Vector3 directionToTarget = Target.position - transform.position;
            directionToTarget.y = 0f; 

            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)) { GetDamage(50); }
    }
    public void GetDamage(float amount)
    {
        Debug.Log("kjk");
        health -=amount;
        bar.fillAmount = health / maxHealth;
        if (health <= 0)
        {

            ChangeTagRecursively(transform);
            animator.SetBool("die", true);
            DeathParticle.SetActive(true);
            // if (animator.GetBool("die")) { DeathParticle.SetActive(true); }
            SpawnEnemy enemy = FindObjectOfType<SpawnEnemy>();
            enemy.spawn();
            Destroy(gameObject, 8);
            Timer ti=FindAnyObjectByType<Timer>();
            ti.score();

        }
    }
    public void InstantiateRandomChild()
    {
        Debug.Log("ghjghg");
        int randomIndex = Random.Range(0, WizardParticle.Length);
        GameObject randomChild = WizardParticle[randomIndex];
        int randomSpawnPointIndex = Random.Range(0, Particle.Length);
        Transform selectedSpawnPoint = Particle[randomSpawnPointIndex];

        Instantiate(randomChild, selectedSpawnPoint.transform.position, selectedSpawnPoint.rotation);
    }
    void ChangeTagRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.tag = "Untagged";
            ChangeTagRecursively(child); 
        }
    }


}
