using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField, Range(5,20)]
    private float initialSpeed = 15;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    [SerializeField] private Score score;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        _rb.linearVelocity = SetInitialDirection() * initialSpeed;
    }

    public void StopGame()
    {
        transform.position = Vector3.zero;
        _rb.linearVelocity = Vector3.zero;
    }

    private Vector3 SetInitialDirection()
    {
        Vector3 direction;
        var rand = Random.Range(1, 4);

        switch (rand)
        {
            case 1:
                direction = new Vector3(1, 0.5f);
                break;
            case 2:
                direction = new Vector3(-1, 0.5f);
                break;
            case 3:
                direction = new Vector3(1, -0.5f);
                break;
            case 4:
                direction = new Vector3(-1, -0.5f);
                break;
            default: direction = Vector3.zero;
                break;
        }
        return direction;
    }

    private void OnCollisionEnter(Collision other)
    {
        _audioSource.Play();

        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("AI")) return;

        var bounceAngle = GetBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
        var xDirection = (other.gameObject.CompareTag("Player")) ? 1 : -1;
        var direction = new Vector3(xDirection, bounceAngle);

        _rb.linearVelocity = direction.normalized * initialSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("LeftGoal") && !other.CompareTag("RightGoal")) return;

        if(other.CompareTag("LeftGoal"))
        {
            score.AddAIScore();
        }
        else
        {
            score.AddPlayerScore();
        }
        StopGame();

        if(!score.IsFinished())
        {
            StartGame();
        }



    }

    private float GetBounceAngle(Vector3 ballPosition, Vector3 playerPosition, float playerSizeHeight)
    {
        return (ballPosition.y - playerPosition.y) / (playerSizeHeight * 0.5f);
    }
}
