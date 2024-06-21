using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _progress;

    [SerializeField] private float speed = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.WithAxis(Axis.Z, -1);
    }

    // Update is called once per frame
    void Update()
    {
        _progress += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _progress);
    }

    public void SetEndPosition(Vector3 endPosition)
    {
        _endPosition = endPosition.WithAxis(Axis.Z, -1);
    }
}
