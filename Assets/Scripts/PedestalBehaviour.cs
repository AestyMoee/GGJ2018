using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalBehaviour : MonoBehaviour {
    
    public int CurrentPosition { get; private set; }

    public OrbBehaviour[] orbs;


    public void MoveLeft()
    {
        if (CurrentPosition > 0)
        {
            CurrentPosition--;
            SetPosition(CurrentPosition);

            for(int i=0;i<orbs.Length;++i)
            {
                orbs[i].MoveLeft();
            }
        }
    }

    public void MoveRight()
    {
        if (CurrentPosition < GameController.Instance.GetClipCutCount() - orbs.Length)
        {
            CurrentPosition++;
            SetPosition(CurrentPosition);

            for (int i = 0; i < orbs.Length; ++i)
            {
                orbs[i].MoveRight();
            }
        }
    }

    public void SetPosition(int idPart)
    {
        CurrentPosition = idPart;

        Vector3 position = transform.localPosition;

        position.x = (GameController.Instance.TrackLenght / GameController.Instance.GetClipCutCount() * idPart + (GameController.Instance.TrackLenght / GameController.Instance.GetClipCutCount()) / 2) - GameController.Instance.TrackLenght / 2;

        transform.localPosition = position;

        for (int i = 0; i < orbs.Length; ++i)
        {
            orbs[i].CurrentPosition = idPart + i;
        }
    }
}
