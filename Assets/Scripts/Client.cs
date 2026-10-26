using UnityEngine;
using UnityEngine.AI;

public class Client : Character
{
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;

    public enum ClientState { give_order, waiting_order, leaving }
    public ClientState currentState = ClientState.give_order;

    private Transform counterSpot;
    private Transform waitingSpot;
    private Transform leftSpot;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    protected override void FixedUpdate()
    {
    }

    public void InitializeClient(Data_Character data, Transform counter, Transform waiting, Transform leaving)
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        agent.speed = data.movementSpeed;
        spriteRenderer.sprite = data.characterSprite;

        counterSpot = counter;
        waitingSpot = waiting;
        leftSpot = leaving;

        GoToGiveOrder();
    }

    public void GoToGiveOrder()
    {
        currentState = ClientState.give_order;
        if (agent != null && counterSpot != null) agent.SetDestination(counterSpot.position);
    }

    public void WaitOrder()
    {
        currentState = ClientState.waiting_order;
        if (agent != null && waitingSpot != null) agent.SetDestination(waitingSpot.position);
    }

    public void LeavingShop()
    {
        currentState = ClientState.leaving;
        if (agent != null && leftSpot != null) agent.SetDestination(leftSpot.position);
    }
}