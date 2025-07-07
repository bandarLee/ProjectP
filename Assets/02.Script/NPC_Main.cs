using UnityEngine;
using System.Collections;

public class NPC_Main : MonoBehaviour
{
    public enum NPCState { WalkIn, Turning, Sit, Left }
    NPCState state = NPCState.WalkIn;

    [Header("Way-Points")]
    public Transform startPos, middlePos, endPos;

    [Header("Move")]
    public float moveSpeed = 2.5f;
    public float turnSpeed = 180f;

    [Header("Anim")]
    public Animator animator;

    Transform target;

    void Start()
    {
        if (!startPos || !middlePos || !endPos) { enabled = false; return; }

        transform.position = startPos.position;
        target  = middlePos;
        animator.SetBool("Walk", true);
    }

    void Update()
    {
        switch (state)
        {
            case NPCState.WalkIn:
                ArriveRoutine();
                break;
            case NPCState.Turning:
                break;
        }
    }

    void ArriveRoutine()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, target.position,
            moveSpeed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        dir.y = 0;
        if (dir.sqrMagnitude > 0.001f)
        {
            Quaternion look = Quaternion.LookRotation(dir.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, look,
                turnSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            if (target == middlePos) { target = endPos; return; }

            if (target == endPos)
            {
                state = NPCState.Turning;
                StartCoroutine(TurnLeftThenSit());
            }
        }
    }

    IEnumerator TurnLeftThenSit()
    {
        Quaternion endRot = transform.rotation * Quaternion.Euler(0, -90f, 0);

        while (Quaternion.Angle(transform.rotation, endRot) > 0.5f)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, endRot,
                turnSpeed * Time.deltaTime);
            yield return null;
        }

        ChangeState(NPCState.Sit);
    }

    void ChangeState(NPCState newState)
    {
        state = newState;

        if (newState == NPCState.Sit)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Sit",  true);
        }
    }
}
