using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance == null) {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public GameState gameState { get; set; }
    public bool canSwipe { get; set; }

    protected GameManager() {

    }

    void Awake() {
        if (_instance == null) {
            _instance = this;
        }
        else {
            DestroyImmediate(this);
        }
    }

    public void Die() {
            UIManager.instance.SetStatus(Constants.statusDeadTapToStart);
            this.gameState = GameState.Dead;
    }
}
