[System.Serializable]
public class IntReference {

	public IntVariable variable;
	public bool useConstant;
	public int constantValue;

	public int Value {
		get { return useConstant ? constantValue : variable.value; }
	}

}