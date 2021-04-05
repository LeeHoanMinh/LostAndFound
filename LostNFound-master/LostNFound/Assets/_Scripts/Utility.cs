using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIL.Library.Utility {
    public enum TouchState
    {
        Start,
        Drag,
        Drop
    }
    public enum Movement
    {
        SwipeLeft,
        SwipeRight,
        SwipeUp,
        SwipeDown,
        DragLeft,
        DragRight,
        DragUp,
        DragDown
    }
    public enum Direction
    {
        Up, 
        Down,
        Left,
        Right
    }
    public enum FamilyMemberType {
        Dad,
        Mom,
        Bro,
        Sis
    }
    public enum FamilyMemberHappyType {
        Gone,
        Angry,
        Sad,
        Normal,
        Good,
        Happy,
    }
    public enum BackgroundType {
        Happy, 
        Normal,
        Sad
    }

    public enum ActivityInteract
    {
        target,
        nontarget,
    }

    public enum ActivityStar
    {
        one = 1,
        two = 2,
        three = 3,
        four = 4,

    }

    public enum ActivityType
    {
        add,
        minus,
        equal,
        multiply,
        swap,
    }

    public enum AffectType
    {
        card,
        time,
        letter,
    }
}
