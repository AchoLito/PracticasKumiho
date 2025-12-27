using System;
using UnityEngine;

public class CanInteractComponent : MonoBehaviour, ICanInteractComponent
{
    public Action interactFunction { get; set; }
}
