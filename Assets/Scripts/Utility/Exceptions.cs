using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingControlException : System.Exception
{
    public MissingControlException(string controlName)
        : base(System.String.Format("Control with name '{0}' not found.", controlName))
    {

    }
}

public class MalformedControlException : System.Exception
{
    public MalformedControlException(string controlName)
        : base(System.String.Format("Control with name '{0}' has malformed structure or may have missing components.", controlName))
    {

    }
}