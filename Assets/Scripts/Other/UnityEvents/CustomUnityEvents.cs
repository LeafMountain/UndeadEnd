using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

[Serializable]
public class UnityVector2Event : UnityEvent<Vector2> { }

[Serializable]
public class UnityFloatEvent : UnityEvent<float> { }

