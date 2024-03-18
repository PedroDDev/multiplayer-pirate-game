using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerDamage _pd;

    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float jumpForce = 35f;

    private bool isJumping = false;
    private bool isFacingRight = true;

    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pd = GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!_pd.isDead)
        {
            //Movimentar
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) _rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            //Pular
            if (!isJumping && moveVertical > 0.1f || moveVertical < -0.1f) _rb.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);

            Flip();
        }
    }

    private void Flip()
    {
        if (isFacingRight && moveHorizontal < -0.1f || !isFacingRight && moveHorizontal > 0.1f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ground")) isJumping = false;
    }

    void OnTriggerExit2D(Collider2D other) => isJumping = true;
}
