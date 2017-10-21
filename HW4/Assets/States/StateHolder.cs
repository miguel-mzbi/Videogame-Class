using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHolder{

    private Dictionary<Symbol, StateHolder> transitions;
    private string stateName;

    public string StateName {
        get {
            return this.stateName;
        }
    }

    public StateHolder(string name) {
        this.stateName = name;
        this.transitions = new Dictionary<Symbol, StateHolder>();
    }

    public void AddTransition(Symbol key, StateHolder value) {
        transitions.Add(key, value);
    }

    public StateHolder ApplySymbol(Symbol key) {
        if (transitions.ContainsKey(key)) {
            return transitions[key];
        }
        return this;
    }
}
