using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class GlobalStateMachine : MonoBehaviour {

    IGlobalState currentState; 

    void Start(){
        DontDestroyOnLoad(this);
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
    }

    public void EnterPlay(){
        ChangeState(new GlobalPlayState());
    }

    public void EnterPause(){
        ChangeState(new GlobalPauseState());
    }

    public void EnterWin(){
        
    }

    public void EnterLose(){

    }
}
