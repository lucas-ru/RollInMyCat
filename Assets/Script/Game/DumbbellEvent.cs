using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbbellEvent : EventArgs
{
    public DumbbellManager Dumbbell { get; private set; }
    
    public DumbbellEvent(DumbbellManager dumbbell)
    {
        Dumbbell = dumbbell;
    }
}
