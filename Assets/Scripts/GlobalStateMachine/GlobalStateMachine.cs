using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GlobalStateMachine : MonoBehaviour {

    public Object MenuScene;
    public Object GameScene;    

    IGlobalState currentState;
    bool paused;

    static GlobalStateMachine instance;

    public static GlobalStateMachine GetInstance(){
        return instance;
    }

    void Start(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            DestroyImmediate(this);
        }
    }

    public void ChangeState(IGlobalState newState) {
        if(currentState != null){
            currentState.ExitState();
        }
        currentState = newState; 
        currentState.EnterState(this);
    }

    void Update() {
        if (currentState != null) { 
            currentState.Update();
        }

        if(Input.GetButtonDown("Cancel")){
            if(paused){
                EnterPlay();
            } else {
                EnterPause();
            }
        }
    }

#region State Changers
    public void EnterMenu(){
        ChangeState(new GlobalMenuState());        
    }

    public void EnterPlay(){
        ChangeState(new GlobalPlayState());
        paused = false;
    }

    public void EnterPause(){
        ChangeState(new GlobalPauseState());
        paused = true;
    }

    public void EnterWin(){
        ChangeState(new GlobalWinState());        
    }

    public void EnterLose(){
        ChangeState(new GlobalLoseState());
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void PlayGame(){
        Debug.Log("Trying to start play");        
        ChangeState(new GlobalStartState());
    }
#endregion
    
}
