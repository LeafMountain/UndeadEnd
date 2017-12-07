public interface IGlobalState {
	void EnterState(GlobalStateMachine stateMachine);
	void ExitState();
	void Update();
}
