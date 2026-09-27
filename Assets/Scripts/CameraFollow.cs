using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 defaultPosition;

    [SerializeField] private Vector3 offset;

    public Transform targetToFollow;
    public bool isFollowingDart;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.mainCamera = this;
        
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFollowingDart)
        {
            transform.position = defaultPosition;
        }
        else
        {
            transform.position = targetToFollow.position + offset;
        }
        
    }

    public void UpdateTargetToFollow(Transform targetToFollow)
    {
        this.targetToFollow = targetToFollow;
    }
}
