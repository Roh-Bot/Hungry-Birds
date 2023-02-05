
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    [SerializeField] private float _launchPower=500f;
    private bool _birdwaslaunched;

    private void Awake()
    {
        _initialPosition = transform.position;
        
        
    }
    private void Update()
    {
        if (_birdwaslaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            _timeSittingAround += Time.deltaTime;
        {

        }
        if (transform.position.y > 4 ||
            transform.position.x > 4 ||
            transform.position.y < 4 ||
            transform.position.x < 4)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        Debug.Log(directionToInitialPosition*400);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdwaslaunched = true;

    }
    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPosition;

    }
}