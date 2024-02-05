using UnityEngine;

public class WayPointSystem : MonoBehaviour, IWayPointsCoordinate
{
    [SerializeField] private Vector3[] points;

    private Vector3 _currentPosition;

    public Vector3[] Points => points;

    public Vector3 CurrentPosition => _currentPosition;

    private bool gameStart;

    private void Start()
    {
        gameStart = true;
        _currentPosition = transform.position;
    }

    private void OnDrawGizmos()
    {
        if (!gameStart && transform.hasChanged)
        {
            _currentPosition = transform.position;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(points[i] + _currentPosition, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + _currentPosition, points[i + 1] + _currentPosition);
            }
        }
    }
}

public interface IWayPointsCoordinate
{
    public Vector3[] Points { get; }
    public Vector3 CurrentPosition { get; }
}
