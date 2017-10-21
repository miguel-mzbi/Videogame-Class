using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol{

    private string symbolName;

    public string Name {
        get {
            return this.symbolName;
        }
    }

    public Symbol(string name) {
        this.symbolName = name;
    }
}
