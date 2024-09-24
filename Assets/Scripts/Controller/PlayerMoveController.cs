using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    void Update()
    {
        float _xDirection = Input.GetAxis("Horizontal");
        float _zDirection = Input.GetAxis("Vertical");
        Vector3 _moveDirection = new Vector3(_xDirection, 0, _zDirection);
        transform.position += _moveDirection * _speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(_moveDirection);
        }
        
    }

    
}
