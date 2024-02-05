using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 CurrentPoint;
    private Vector3[] wayPoints;

    public float MoveSpeed = 2f;
    private int _currentWaypointIndex;

    private void Start()
    {
        GameObject objFind = FindObjectOfType<WayPointSystem>().gameObject;
        CurrentPoint = objFind.GetComponent<WayPointSystem>().CurrentPosition;
        wayPoints = objFind.GetComponent<WayPointSystem>().Points;
        _currentWaypointIndex = 0;
        CurrentPoint = GetWaypointPosition(_currentWaypointIndex);
    }

    private void Update()
    {
        Movement();

        if (CurrentPointReached())
        {
            UpdatePoint();
        }
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPoint, MoveSpeed * Time.deltaTime);
    }

    private bool CurrentPointReached()
    {
        float distanceToNext = (transform.position - CurrentPoint).magnitude;
        if (distanceToNext < 0.1f)
        {
            return true;
        }

        return false;
    }

    private void UpdatePoint()
    {
        int lastWaypointIndex = wayPoints.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
        {
            _currentWaypointIndex++;
            CurrentPoint = GetWaypointPosition(_currentWaypointIndex);
        }
        
        else
            EndPointReached();
    }

    private void EndPointReached()
    {
        Debug.Log("That's All");
    }

    private Vector3 GetWaypointPosition(int index)
    {
        return wayPoints[index];
    }
}
