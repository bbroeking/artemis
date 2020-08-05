using UnityEngine;
using Pathfinding;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] AIDestinationSetter aIDestination;
    [SerializeField] private Transform[] patrolAnchors;
    private Transform currentAnchor;
    private int currentAnchorIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentAnchorIndex = 0;
        currentAnchor = patrolAnchors[currentAnchorIndex];
        aIDestination.target = currentAnchor;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(this.transform.position, currentAnchor.transform.position);
        Debug.Log(dist.ToString());
        if (dist < 0.2){
            currentAnchorIndex = (currentAnchorIndex + 1) % patrolAnchors.Length;
            currentAnchor = patrolAnchors[currentAnchorIndex];
            aIDestination.target = currentAnchor;
        }
    }
}
