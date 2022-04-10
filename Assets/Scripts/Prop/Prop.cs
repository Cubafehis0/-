using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IProp
{
    int GetHashCode();
    void Use(params object[] args);
    void OnRemove(params object[] args);
}