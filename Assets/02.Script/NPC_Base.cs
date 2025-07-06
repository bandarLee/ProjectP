using Unity.VisualScripting;
using UnityEngine;

public class NPC_Base : MonoBehaviour
{
    public enum NPCState
    {
        WalkIn,
        Order,
        Sit,
        Left
    }
    public Animator animator;

    public NPCState state = NPCState.WalkIn;

    public float speed = 5.0f;
    public Transform initialPosition;
    public Transform arrivePosition;





    void Start()
    {
        this.gameObject.transform.position = initialPosition.position;
        animator.Play("Walk");
    }

    void Update()
    {
        if (state != NPCState.WalkIn) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            arrivePosition.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, arrivePosition.position) < 0.05f)
        {
            ChangeState(state, "Arrive", true);
        }
    }
    private void ChangeState(NPCState newState, string animationBool, bool value)
    {
        state = newState;
        animator.SetBool(animationBool, value);
    }
}
