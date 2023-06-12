using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    Rigidbody2D rb;
    Vector2 moveDir;
    Quaternion originRot;
    float AnimationAmplitude = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originRot = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    private void FixedUpdate() {
        Move();
    }
    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
    }
    void Move(){
        rb.velocity = moveDir * Speed;
    }
    void GoofyAnimation()
    {

    }
}
