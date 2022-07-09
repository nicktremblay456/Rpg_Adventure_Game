using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    #region Variables/Props
    [Header("Player Settings")]
    [SerializeField] private float m_RunSpeed = 10f;
    [SerializeField] private float m_SprintSpeed = 15f;
    [SerializeField] private float m_RunAcceleration = 5f;
    [SerializeField] private float m_TurnSpeed = 10f;
    [SerializeField] private float m_JumpForce = 650f;
    [SerializeField] private float m_RollingForce = 200f;
    [SerializeField] private float m_Gravity = 20f;
    
    [SerializeField] private float m_MaxGroundAngle = 45f;
    [SerializeField] private LayerMask m_WalkGround;

    private PlayerInput m_Input;
    private Rigidbody m_RigidBody;
    private Animator m_Animator;
    private CapsuleCollider m_Collider;

    private PhysicMaterial m_FrictionPhysics, m_MaxFrictionPhysics, m_SlippyPhysics;

    private float m_CurrentSpeed = 0f;
    private float m_RotationAngle;
    private float m_GroundAngle;

    private Quaternion m_TargetRotation = new Quaternion();
    private Vector3 m_Forward = new Vector3();
    private Vector3 m_MoveDirection = new Vector3();
    private Transform m_Camera;

    private RaycastHit m_HitInfo;

    private bool m_IsAttacking = false;
    private bool m_IsSprinting = false;
    private bool m_IsRunning = false;
    //private bool m_IsWalkable = true;
    private bool m_IsDead = false;

    public bool IsGrounded
    {
        get => Physics.SphereCast(transform.position + m_Collider.center, m_Collider.radius, Vector3.down, out m_HitInfo, m_Collider.height * 0.5f, m_WalkGround, QueryTriggerInteraction.Ignore);
    }
    public bool IsDead { get => m_IsDead; }
    public float ColliderHeight
    {
        get => m_Collider.height;
    }
    public Vector3 ColliderCenter
    {
        get => m_Collider.center;
    }
    public Rigidbody GetRigidbody
    {
        get => m_RigidBody;
    }

    private readonly int m_HashGrounded = Animator.StringToHash("Grounded");
    private readonly int m_HashSpeed = Animator.StringToHash("Speed");
    private readonly int m_HashVelocityY = Animator.StringToHash("VelocityY");
    private readonly int m_HashAttackOne = Animator.StringToHash("Attack_1");
    private readonly int m_HashAttackTwo = Animator.StringToHash("Attack_2");
    private readonly int m_HashAttackThree = Animator.StringToHash("Attack_3");
    private readonly int m_HashDrink = Animator.StringToHash("Drink");
    private readonly int m_HashJumpAttack = Animator.StringToHash("JumpAttack");
    private readonly int m_HashDeath = Animator.StringToHash("Death");
    private readonly int m_HashRoll = Animator.StringToHash("Roll");
    #endregion

    #region Mono Methods
    private void OnEnable() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake ()
    {
        Init();
    }

    private void Start ()
    {
        m_Camera = Camera.main.transform;
        //m_HealthBars = HealthBars.Instance;
    }

    private void Update ()
    {
        CalculateDirection();
        CalculateForward();
        CalculateGroundAngle();
        ControlMaterialPhysics();

        if (m_Input.JumpInput)
        {
            Jump();
        }
        
        //if (m_IsSprinting) m_IsSprinting = false;
        //if (m_CurrentSpeed > m_RunSpeed) m_CurrentSpeed = m_RunSpeed;

        HandleMovementAnimation();
        //if (m_ActiveDebug)
        //{
        //    DrawDebugLines();
        //}
    }

    private void FixedUpdate ()
    {
        // Physics
        if (m_Input.MoveInput != Vector2.zero && !m_IsAttacking)
        {
            Rotate();
            SetSpeed();
        }
        else ResetSpeed();

        m_MoveDirection = m_Forward * m_CurrentSpeed;
        m_MoveDirection.y = m_RigidBody.velocity.y;

        if (m_RigidBody.velocity.y != 0)
        {
            m_MoveDirection.y -= m_Gravity * Time.fixedDeltaTime;
        }
        m_RigidBody.velocity = m_MoveDirection;
    }
    #endregion

    #region Controller Movement
    private void Init()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();
        m_Collider = GetComponent<CapsuleCollider>();
        m_Input = GetComponent<PlayerInput>();

        // Slides the character through walls and edges
        m_FrictionPhysics = new PhysicMaterial();
        m_FrictionPhysics.name = "frictionPhysics";
        m_FrictionPhysics.staticFriction = 0.25f;
        m_FrictionPhysics.dynamicFriction = 0.25f;
        m_FrictionPhysics.frictionCombine = PhysicMaterialCombine.Multiply;

        // Prevent the collider from slipping on ramps
        m_MaxFrictionPhysics = new PhysicMaterial();
        m_MaxFrictionPhysics.name = "maxFrictionPhysics";
        m_MaxFrictionPhysics.staticFriction = 1f;
        m_MaxFrictionPhysics.dynamicFriction = 1f;
        m_MaxFrictionPhysics.frictionCombine = PhysicMaterialCombine.Maximum;

        // Air physics
        m_SlippyPhysics = new PhysicMaterial();
        m_SlippyPhysics.name = "slippyPhysics";
        m_SlippyPhysics.staticFriction = 0f;
        m_SlippyPhysics.dynamicFriction = 0f;
        m_SlippyPhysics.frictionCombine = PhysicMaterialCombine.Minimum;
    }

    private void ControlMaterialPhysics()
    {
        m_Collider.material = (IsGrounded && m_GroundAngle < m_MaxGroundAngle) ? m_FrictionPhysics : m_SlippyPhysics;

        if (IsGrounded && m_Input.MoveInput == Vector2.zero) m_Collider.material = m_MaxFrictionPhysics;
        else if (IsGrounded && m_Input.MoveInput != Vector2.zero) m_Collider.material = m_FrictionPhysics;
        else m_Collider.material = m_SlippyPhysics;
    }

    private void HandleMovementAnimation()
    {
        m_Animator.SetFloat(m_HashVelocityY, m_RigidBody.velocity.y);
        m_Animator.SetInteger(m_HashSpeed, (int)m_CurrentSpeed);
        m_Animator.SetBool(m_HashGrounded, IsGrounded);
    }

    private void CalculateDirection ()
    {
        // Calcul l'angle selon l'input
        m_RotationAngle = Mathf.Atan2(m_Input.MoveInput.x, m_Input.MoveInput.y);
        // Transfère l'angle en degré.
        m_RotationAngle *= Mathf.Rad2Deg;
        // Rotation relative a la camera.
        m_RotationAngle += m_Camera.eulerAngles.y;
    }

    private void CalculateForward ()
    {
        // Calculer le forward selon l'angle du sol.
        if (IsGrounded)
        {
            // Retourne le vector "Forward" en considérant la "pente".
            m_Forward = Vector3.Cross(m_HitInfo.normal, -transform.right);
        }
        else m_Forward = transform.forward;
    }

    private void CalculateGroundAngle ()
    {
        // Calcule l'angle du sol, en utilisant sa normal.
        //Debug.Log("Ground Angle: " + m_GroundAngle + " | " + "m_MaxGroundAngle: " + (m_GroundAngle + 90f));
        if (IsGrounded)
        {
            // On détermine l'angle du sol en utilisant la normal et notre forward.            
            m_GroundAngle = Vector3.Angle(m_HitInfo.normal, transform.forward);
        }
        else  m_GroundAngle = 90f;
    }

    private void Rotate ()
    {
        // Convertis notre eulerAngle en quaternion.
        m_TargetRotation = Quaternion.Euler(0f , m_RotationAngle, 0f);
        // TO DO -> Add a check if joystick.x != 0, use a bigger turn speed. This will prevent any unwanted drifting effect. By snapping the rotation.
        transform.rotation = Quaternion.Slerp(transform.rotation, m_TargetRotation, m_TurnSpeed * Time.fixedDeltaTime);
    }

    private void SetSpeed ()
    {
        if (m_GroundAngle < m_MaxGroundAngle + 90f)
        {
            if (m_IsSprinting && m_CurrentSpeed < m_SprintSpeed)
            {
                m_CurrentSpeed += m_SprintSpeed * (m_RunAcceleration * Time.fixedDeltaTime);
            }
            else if (m_CurrentSpeed < m_RunSpeed)
            {
                m_CurrentSpeed += m_RunSpeed * (m_RunAcceleration * Time.fixedDeltaTime);
                if (!m_IsRunning) m_IsRunning = true;
            }
        }
        else ResetSpeed();
    }

    private void Jump ()
    {
        if (IsGrounded)
        {
            m_RigidBody.AddForce(transform.up * m_JumpForce);
        }
    }

    private void ResetSpeed ()
    {
        m_CurrentSpeed = 0f;
        if (m_IsRunning) m_IsRunning = false;
        if (m_IsSprinting) m_IsSprinting = false;
    }

    public void Death ()
    {
        m_Input.ReleaseControl();
        m_Animator.SetTrigger(m_HashDeath);
    }
    #endregion
}