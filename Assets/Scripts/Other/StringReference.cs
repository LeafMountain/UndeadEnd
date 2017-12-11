using System;

[Serializable]
public class StringReference {

	public bool useConstant = false;
	public string constantValue;
	public StringVariable variable;

	public string Value{
		get {
			return useConstant ? constantValue : variable.Value;
		}
		set {
			if(useConstant){
				constantValue = value;
			} else {
				variable.SetValue(value);
			}
		}
	}
}
