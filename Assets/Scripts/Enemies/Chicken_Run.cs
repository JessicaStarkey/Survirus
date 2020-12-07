using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken_Run : StateMachineBehaviour
{
    public float speed = 6;
    Transform player;
    Rigidbody rigidbody;
    Transform enemy;
    
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = animator.GetComponent<Rigidbody>();
        
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Vector3 direction = (player.transform.position - enemy.position);
        direction.y = player.position.y;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;
        enemy.rotation = Quaternion.Slerp(player.rotation, lookRotation, 1);
        Vector3 target = new Vector3(player.position.x, rigidbody.position.y);
        Vector3 newPos = Vector3.MoveTowards(rigidbody.position, target, speed * Time.deltaTime);
        rigidbody.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
