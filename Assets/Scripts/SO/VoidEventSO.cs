using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using So;

[CreateAssetMenu(fileName="New void event", menuName="Void/Void event")]
public class VoidEventSO : EventSO<Void>
{
    public void Raise() => RaiseEvent(new Void());
}
