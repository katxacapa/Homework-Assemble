using UnityEngine;

public class PenaltyZone : MonoBehaviour
{
    [SerializeField] private int pointsLost = 10;

    private GameFlow _gameFlow;

    private void Start()
    {
        GameObject gameFlowObject = GameObject.Find("GameFlow");

        if (gameFlowObject != null)
        {
            _gameFlow = gameFlowObject.GetComponent<GameFlow>();
        }

        if (_gameFlow == null)
        {
            Debug.LogError("PenaltyZone: Could not find GameFlow!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (_gameFlow == null) return;

        _gameFlow.ScorePoint(-pointsLost);
    }
}

