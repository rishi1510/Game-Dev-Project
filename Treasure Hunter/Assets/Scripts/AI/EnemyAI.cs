using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
   [SerializeField]
   private List<Detector> detectors;

   [SerializeField]
   private List<SteeringBehavior> steeringBehaviors;

   [SerializeField]
   private AIData aiData;

   [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.03f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 2f;

    //Inputs sent from the Enemy AI to the Enemy controller
    public UnityEvent OnAttackPressed;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;

    [SerializeField]
    private Vector2 movementInput;

     [SerializeField]
    private ContextSolver movementDirectionSolver;
    public Animator animator;

    bool following = false;


    private void Start() {
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void PerformDetection() {
        foreach(Detector detector in detectors) {
            detector.Detect(aiData);
        }
    }

    private void Update()
    {
        float speed = 1;
        //Enemy AI movement based on Target availability
        if (aiData.currentTarget != null)
        {
            //Looking at the Target
            //OnPointerInput?.Invoke(aiData.currentTarget.position);
            if (following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            //Target acquisition logic
            aiData.currentTarget = aiData.targets[0];
        }
        //Moving the Agent
        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            //Stopping Logic
            Debug.Log("Stopping");
            animator.SetBool("isRunning", false);
            movementInput = Vector2.zero;
            following = false;
            yield break;
        }
        else
        {
            float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if (distance <= attackDistance)
            {
                //Attack logic
                animator.SetBool("isRunning", false);
                movementInput = Vector2.zero;
                OnAttackPressed?.Invoke();
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                //Chase logic
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviors, aiData);
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }

        }

    }
}
