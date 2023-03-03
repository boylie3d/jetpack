using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMotor : MonoBehaviour
{
  public bool useGravity { get; set; }

  [SerializeField]
  private LayerMask groundLayer;
  [SerializeField]
  private float _moveSpeed = 1f;
  [SerializeField]
  private float _jumpHeight, _jumpTime;

  private Rigidbody2D _rigidbody;

  void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private Vector2 velocityThisFrame = Vector2.zero;

  public void AddVelocityToFrame(Vector2 velocity)
  {
    var vel = velocity;
    velocityThisFrame += vel;
  }

  private void FixedUpdate()
  {
    GroundCheck();

    if (isJumping)
      HandleJump();

    _rigidbody.MovePosition(_rigidbody.position + (velocityThisFrame * Time.fixedDeltaTime));
    velocityThisFrame = Vector2.zero;
  }

  public void Move(Vector2 amount)
  {
    AddVelocityToFrame(amount * _moveSpeed);
  }

  private bool _canClimb = false;
  public bool canClimb
  {
    get { return _canClimb; }
    set
    {
      _canClimb = value;
      useGravity = !_canClimb;
    }
  }

  public void Climb(Vector2 amount)
  {
    if (!canClimb) return;

    AddVelocityToFrame(amount * _moveSpeed);
  }

  private Vector3 groundCheckOffset = new Vector3(0, 0.0625f, 0);
  private Vector2 groundCheckSize = new Vector2(.3125f, 0.1f);
  private bool _isGrounded;

  private void GroundCheck()
  {
    _isGrounded = Physics2D.OverlapBox(transform.position + groundCheckOffset, groundCheckSize, 0, groundLayer);
    if (!_isGrounded && !isJumping && useGravity)
      AddVelocityToFrame(Physics2D.gravity);
  }


  private bool _isJumping;
  private float _jumpTimer;
  public bool isJumping
  {
    get { return _isJumping; }
    set
    {
      _jumpTimer = 0;
      if (_isGrounded)
        _isJumping = value;
      else
        _isJumping = false;
    }
  }

  public void HandleJump()
  {
    velocityThisFrame += new Vector2(0, _jumpHeight);

    _jumpTimer += Time.fixedDeltaTime;
    if (_jumpTimer >= _jumpTime)
      isJumping = false;
  }

  //states
  #region States


  //public bool isJumping
  //{
  //  get
  //  {
  //    return _isJumping;
  //  }
  //  set
  //  {
  //    if (_isJumping != value)
  //    {
  //      _isJumping = value;
  //      //JumpStateChanged(value);
  //    }
  //  }
  //}
  //public bool isGrounded
  //{
  //  get
  //  {
  //    return _isGrounded;
  //  }
  //  set
  //  {
  //    if (_isGrounded != value)
  //    {
  //      _isGrounded = value;
  //      //GroundStateChanged(value);
  //    }
  //  }
  //}
  //public bool isDashing
  //{
  //  get
  //  {
  //    return _isDashing;
  //  }
  //  set
  //  {
  //    if (_isDashing != value)
  //    {
  //      _isDashing = value;
  //      DashStateChanged(value);
  //    }
  //  }
  //}
  //public bool isLeftCheck
  //{
  //  get
  //  {
  //    return _isLeftCheck;
  //  }
  //  set
  //  {
  //    if (_isLeftCheck != value)
  //    {
  //      _isLeftCheck = value;
  //      //GrabStateChanged(value);
  //    }
  //  }
  //}
  //public bool isRightCheck
  //{
  //  get
  //  {
  //    return _isRightCheck;
  //  }
  //  set
  //  {
  //    if (_isRightCheck != value)
  //    {
  //      _isRightCheck = value;
  //      //GrabStateChanged(value);
  //    }
  //  }
  //}
  //public bool isTopCheck
  //{
  //  get
  //  {
  //    return _isTopCheck;
  //  }
  //  set
  //  {
  //    if (_isTopCheck != value)
  //    {
  //      _isTopCheck = value;
  //      //GrabStateChanged(value);
  //    }
  //  }
  //}
  //public bool isAiming
  //{
  //  get
  //  {
  //    return _isAiming;
  //  }
  //  set
  //  {
  //    if (_isAiming != value)
  //    {
  //      _isAiming = value;
  //      //GrabStateChanged(value);
  //    }
  //  }
  //}
  //[TitleGroup("STATES", horizontalLine: true, indent: true, boldTitle: true)]

  //[TitleGroup("STATES")]
  //public FacingDirection facingdirection = FacingDirection.Right;
  //[TitleGroup("STATES")]
  //public GrabDirection grabDirection = GrabDirection.None;
  //[ReadOnly]
  //[ShowInInspector]
  //[TitleGroup("STATES")]
  #endregion
  //Checks
  #region Checks
  private Vector3 leftCheckOffset = new Vector3(-0.25f, 0.5f, 0);
  private Vector2 leftCheckSize = new Vector2(.125f, .5f);
  private Vector3 rightCheckOffset = new Vector3(0.25f, 0.5f, 0);
  private Vector2 rightCheckSize = new Vector2(.125f, .5f);
  private Vector3 topCheckOffset = new Vector3(-0, 1f, 0);
  private Vector2 topCheckSize = new Vector2(.3125f, .125f);
  #endregion

  //private bool CheckForGround()
  //{
  //  return Physics2D.OverlapBox(transform.position + groundCheckOffset, groundCheckSize, 0, groundLayer);
  //if (currentYVelocity <= 0)
  //{
  //  isLeftCheck = Physics2D.OverlapBox(transform.position + leftCheckOffset, leftCheckSize, 0, groundLayer);
  //  isRightCheck = Physics2D.OverlapBox(transform.position + rightCheckOffset, rightCheckOffset, 0, groundLayer);
  //}
  //else
  //{
  //  if (isDashing)
  //  {
  //    isLeftCheck = Physics2D.OverlapBox(transform.position + leftCheckOffset, leftCheckSize, 0, groundLayer);
  //    isRightCheck = Physics2D.OverlapBox(transform.position + rightCheckOffset, rightCheckOffset, 0, groundLayer);
  //    isGrounded = false;
  //  }
  //  else
  //  {
  //    isGrounded = false;
  //    isLeftCheck = false;
  //    isRightCheck = false;
  //  }
  //}
  //isTopCheck = Physics2D.OverlapBox(transform.position + topCheckOffset, topCheckSize, 0, groundLayer);
  //if (isGrounded)
  //{
  //  if (isGrabbing) EndGrab();
  //  groundObject = Physics2D.OverlapBox(transform.position + groundCheckOffset, groundCheckSize, 0, groundLayer).transform;
  //  if (groundObject.GetComponent<Targetable>())
  //  {
  //    if (isDashing)
  //    {
  //      EndDash();
  //      currentXVelocity = 0;
  //    }

  //    if (Input.GetKey(KeyCode.Space))
  //    {
  //      StartJump(jumpVelocity * 1.25f);
  //    }
  //    else
  //    {
  //      StartJump(jumpVelocity * 1.75f);
  //    }
  //    Destroy(groundObject.gameObject);
  //  }
  //}
  //else groundObject = null;
  //if (isLeftCheck)
  //{
  //  if (currentXVelocity < 0) currentXVelocity = 0;
  //  leftObject = Physics2D.OverlapBox(transform.position + leftCheckOffset, leftCheckSize, 0, groundLayer).transform;
  //  if (isDashing && dashDirection.x < 0) EndDash();
  //}
  //else
  //{
  //  if (isGrabbing && grabDirection == GrabDirection.Left) EndGrab();
  //  leftObject = null;
  //}
  //if (isRightCheck)
  //{
  //  if (currentXVelocity > 0) currentXVelocity = 0;
  //  rightObject = Physics2D.OverlapBox(transform.position + rightCheckOffset, rightCheckOffset, 0, groundLayer).transform;
  //  if (isDashing && dashDirection.x > 0) EndDash();
  //}
  //else
  //{
  //  if (isGrabbing && grabDirection == GrabDirection.Right) EndGrab();
  //  rightObject = null;
  //}
  //if (isTopCheck)
  //{
  //  Debug.Log("IS TOP CHECK");
  //  if (isJumping)
  //  {
  //    Debug.Log("ENDING JUMP IN TOP CHECK STATUS");
  //    EndJump();
  //  }
  //  if (isDashing && dashDirection.y > 0)
  //  {
  //    Debug.Log("ENDING JUMP IN TOP CHECK STATUS");
  //    EndDash();
  //  }
  //  if (currentYVelocity > 0) currentYVelocity = 0;
  //}
  //else
  //{
  //}
  //}

  private void OnDrawGizmos()
  {
    //Draw ground check box
    Color boxColor = Color.green;

    if (!_isGrounded)
      boxColor = Color.red;

    boxColor.a = 0.25f;
    Gizmos.color = boxColor;
    Gizmos.DrawCube(transform.position + groundCheckOffset, groundCheckSize);

    ////Draw left check box
    //if (Physics2D.OverlapBox(transform.position + leftCheckOffset, leftCheckSize, 0, groundLayer))
    //{
    //  Color boxColor = Color.green;
    //  boxColor.a = 0.25f;
    //  Gizmos.color = boxColor;
    //  Gizmos.DrawCube(transform.position + leftCheckOffset, new Vector3(leftCheckSize.x, leftCheckSize.y, GameController.pixelSize));
    //}
    //else
    //{
    //  Color boxColor = Color.red;
    //  boxColor.a = 0.25f;
    //  Gizmos.color = boxColor;
    //  Gizmos.DrawCube(transform.position + leftCheckOffset, new Vector3(leftCheckSize.x, leftCheckSize.y, GameController.pixelSize));
    //}
    ////Draw right check box
    //if (Physics2D.OverlapBox(transform.position + rightCheckOffset, rightCheckSize, 0, groundLayer))
    //{
    //  Color boxColor = Color.green;
    //  boxColor.a = 0.25f;
    //  Gizmos.color = boxColor;
    //  Gizmos.DrawCube(transform.position + rightCheckOffset, new Vector3(rightCheckSize.x, rightCheckSize.y, GameController.pixelSize));
    //}
    //else
    //{
    //  Color boxColor = Color.red;
    //  boxColor.a = 0.25f;
    //  Gizmos.color = boxColor;
    //  Gizmos.DrawCube(transform.position + rightCheckOffset, new Vector3(rightCheckSize.x, rightCheckSize.y, GameController.pixelSize));
    //}
    ////Draw right check box
    //if (Physics2D.OverlapBox(transform.position + topCheckOffset, topCheckSize, 0, groundLayer))
    //{
    //  Color boxColor = Color.green;
    //  boxColor.a = 0.25f;
    //  Gizmos.color = boxColor;
    //  Gizmos.DrawCube(transform.position + topCheckOffset, new Vector3(topCheckSize.x, topCheckSize.y, GameController.pixelSize));
    //}
    //else
    //{
    //  Color boxColor = Color.red;
    //  boxColor.a = 0.25f;
    //  Gizmos.color = boxColor;
    //  Gizmos.DrawCube(transform.position + topCheckOffset, new Vector3(topCheckSize.x, topCheckSize.y, GameController.pixelSize));
    //}
  }
}
