using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour {

    protected Animator animator;

    //  Public Input Objects
    
    public bool ikActive = false;

    [Header("Hand IK Targets")]
    public Transform leftHandObj = null;
    public Transform rightHandObj = null;
    
    [Space(10)]
    [Header("Hand IK Target Rotation Offsets")]
    // Model hand rotation offsets
    public float xRotate = 0f;
    public float yRotate = 0f;
    public float zRotate = 0f;

    [Header("Feet IK Targets")]
    public Transform leftFootObj = null;
    public Transform rightFootObj = null;
    
    [Space(10)]
    [Header("Feet IK Target Positional Offsets")]
    public float xPos = 0f;
    public float yPos = 0f;
    public float zPos = 0f;


    [Header("References")]
    public GameObject headObj = null;
    public GameObject shoulderObj = null;
    
    [Space(10)]
    [Header("Body Offsets")]
    // Body position offsets (from camera)
    public float xOffset = 0f;
    public float yOffset = 1.6f;
    public float zOffset = 0f;


    // Private Objects
    private Transform head = null;
    private Transform hips = null;
    private Vector3 bodyDiff;
    
    void Awake()
    {
        // Get animator component to set IK targets
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        // Perform appropriate positional transforms to the body based on the head object position.
        if (headObj != null)
        {
            // An offset can be applied depending on the model measurements
            gameObject.transform.position = headObj.transform.position - new Vector3(xOffset, yOffset, zOffset);
        }  
    }
    

    private void LateUpdate()
    {

        Transform right = animator.GetBoneTransform(HumanBodyBones.RightShoulder); 
        Transform left = animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
        

        // Perform feet xz plane adjustment 
        if (shoulderObj != null) 
        {
            rightFootObj.position = new Vector3(headObj.transform.position.x, 0, headObj.transform.position.z ) + new Vector3(xPos, yPos, zPos);
            leftFootObj.position = new Vector3(headObj.transform.position.x, 0, headObj.transform.position.z ) + new Vector3(-xPos, yPos, zPos);

        }
        
        // Shoulder translation for better pointing (This is in place of shoulder IK)
        right.position += new Vector3(0, 0, 0.05f);
        left.position += new Vector3(0,0,0.05f);

    }
    //a callback for calculating IK
    void OnAnimatorIK() 
    {
        if (animator) 
        {
            // if the IK is active, set the position and rotation directly to the goal. Also apply a rotation 
            // offset of the hands depending on requirements 
            if (ikActive)
            {
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation * Quaternion.Euler(xRotate, yRotate, zRotate));
                }

                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null) 
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation * Quaternion.Euler(xRotate, -yRotate, -zRotate));
                }

                if (leftFootObj != null) 
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.rotation); //* Quaternion.Euler(xRotate, -yRotate, -zRotate));
                }
                
                if (rightFootObj != null) 
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.rotation); //* Quaternion.Euler(xRotate, -yRotate, -zRotate));
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else 
            {
                // Hands
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                // Feet
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);

            }
        }
    }
}