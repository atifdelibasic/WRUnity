using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Input managment")]
    [SerializeField]
    private InputManagment _inputManagment;
    [Header("Movement components (auto)")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private BoxCollider _collider;

    private float movementSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 4.0f;

	[SerializeField]
    private BulletGenerator _bulletGenerator;
#pragma warning restore 0649

    Vector3 movementDirection = Vector3.zero;
    private bool isGrounded;
    private bool isSliding;
    private float slidingTimeStart;
    private float slidingTimeMax = 1.0f;
    private float jumpingTimeStart;
    private float jumpingTimeMax = 0.7f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
_bulletGenerator = GetComponent<BulletGenerator>();

        _inputManagment.OnAxisPressed += _inputManagment_OnAxisPressed;
        _inputManagment.OnJumpKeyPressed += _inputManagment_OnJumpKeyPressed;
        _inputManagment.OnSlideKeyPressed += _inputManagment_OnSlideKeyPressed;
        _inputManagment.NoAxisPressed += _inputManagment_NoAxisPressed;
	_inputManagment.OnFireKeyPressed += _inputManagment_OnFireKeyPressed;
    }

    private void OnDestroy()
    {
        _inputManagment.OnAxisPressed -= _inputManagment_OnAxisPressed;
        _inputManagment.OnJumpKeyPressed -= _inputManagment_OnJumpKeyPressed;
        _inputManagment.OnSlideKeyPressed -= _inputManagment_OnSlideKeyPressed;
        _inputManagment.NoAxisPressed -= _inputManagment_NoAxisPressed;
	_inputManagment.OnFireKeyPressed -= _inputManagment_OnFireKeyPressed;
    }

    private void Update()
    {
        //Change collider size based on action
        colliderControl();
    }

	private void _inputManagment_OnFireKeyPressed() {
        _bulletGenerator.GenerateBullet();
        }

    private void _inputManagment_NoAxisPressed()
    {
        //When no active axis set idle animation
        idleAnimation();
    }

    private void _inputManagment_OnAxisPressed()
    {
        //Get inputs
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        movementDirection.Set(InputX, 0, InputY);
        setMovement(InputX, InputY);
    }

    private void _inputManagment_OnSlideKeyPressed()
    {
        Slide();
    }

    private void _inputManagment_OnJumpKeyPressed()
    {
        Jump();
    }

    private void setMovement(float InputX, float InputY)
    {
        //Start animations
        _animator.SetFloat("InputY", InputY);
        _animator.SetFloat("InputX", InputX);

        //Rotate rigidbody(player)
        _rigidbody.MoveRotation(Quaternion.LookRotation(movementDirection));

        //Move rigidbody(player)
        movementDirection = movementDirection.normalized * movementSpeed * Time.deltaTime;
        if(isGrounded)
        {
            movementDirection.y = 0;
        }
        _rigidbody.MovePosition(transform.position + movementDirection);

        transform.position = transform.position + movementDirection;
    }

    private void idleAnimation()
    {
        //Set idle animations 
        _animator.SetFloat("InputY", 0);
        _animator.SetFloat("InputX", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation /*| RigidbodyConstraints.FreezePositionY*/;
        }
    }

    private void Jump()
    {
        //Unfreeze Y position to jump
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        if (isGrounded)
        {
            jumpingTimeStart = Time.time;
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    private void Slide()
    {
        if (isGrounded)
        {
            slidingTimeStart = Time.time;
            isSliding = true;
            _rigidbody.AddForce(Vector3.forward, ForceMode.Acceleration);
            _animator.SetTrigger("Slide");
        }
    }

    //Change collider size when sliding
    private void setSlidingColliderOn()
    {
        _collider.center = new Vector3(0, 0.5f, 0);
        _collider.size = new Vector3(1.0f, 1.0f, 2.0f);
    }

    //Change collider size when jumping
    private void setJumpColliderOn()
    {
        _collider.center = new Vector3(0, 1.8f, 0);
        _collider.size = new Vector3(1.0f, 1.5f, 1.0f);
    }

    //Set regular collider size
    private void setRegularColliderOn()
    {
        _collider.center = new Vector3(0, 1.0f, 0);
        _collider.size = new Vector3(1.0f, 2.0f, 1.0f);
    }

    //Control colliders every frame
    private void colliderControl()
    {
        if (isSliding && (Time.time - slidingTimeStart) < slidingTimeMax) setSlidingColliderOn();
        else if (!isGrounded && (Time.time - jumpingTimeStart) < jumpingTimeMax) setJumpColliderOn();
        else
        {
            setRegularColliderOn();
            isSliding = false;
            //isGrounded = true;
        }
    }
}