using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AState {

    private Dictionary<ASymbol, AState> transition;
    private Type behavior;
    private string name;

    public string Name {
        get {
            return this.name;
        }
    }

    public Type Behavior {
        get {
            return this.behavior;
        }
    }

    public AState(string name, Type behavior) {
        this.name = name;
        this.behavior = behavior;
        this.transition = new Dictionary<ASymbol, AState>();
    }

    public void AddTransition(ASymbol key, AState value) {
        transition.Add(key, value);
    }

    public AState ApplySymbol(ASymbol key) {
        if(transition.ContainsKey(key)) {
            return transition[key];
        }
        return this;
    }
}
