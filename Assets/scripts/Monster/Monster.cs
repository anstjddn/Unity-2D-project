using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum State { Idle,Trace,Attack,size}
    public float detectRange;
    public float AttackRange;

    public Transform Player;
    private List<State> states;
    private State curstate;
    private void Awake()
    {
        states = new List<State>();
       /* states[(int)State.Idle] = 
        states[(int)State.Trace] 
        states[(int)State.Attack]*/
       



    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
    private void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }



}

public class IdleState : Monster
{
    private Monster monster;
    public IdleState(Monster monster)
    {
        this.monster = monster;
    }

}
public class TraceState : Monster
{

}

public class AttackState : Monster
{

}