[System.Serializable]
public class BoolReference {

	public BoolVariable variable;
	public bool useConstant;
	public bool constantValue;

	public bool Value {
		get { return useConstant ? constantValue : variable.value; }
	}

}