using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action<EventID> OnEventEmitted; 
    
    private bool enableResetLevel = true;
    private bool isPaused = false; // Trạng thái pause

    private void EmitEvent(EventID eventID)
    {
        OnEventEmitted?.Invoke(eventID);
    }
    
    public void EmitNextLevelEvent()
    {
        enableResetLevel = true;
        EmitEvent(EventID.OnNextLevel);
    }
    
    public void EmitCompleteLevelEvent()
    {
        enableResetLevel = false;
        EmitEvent(EventID.OnCompleteLevel);
    }

    public void EmitResetLevelEvent()
    {
        if (!enableResetLevel)
        {
            return;
        }
        EmitEvent(EventID.OnResetLevel);
    }
    public void TogglePause()
    {
        if (!isPaused)
        {
            // Gửi sự kiện pause chỉ khi trạng thái không phải là pause
            isPaused = true;
            Time.timeScale = 0f; // Tạm dừng thời gian khi pause
            
        }
        else
        {
            // Gửi sự kiện resume chỉ khi trạng thái là pause
            isPaused = false;
            Time.timeScale = 1f; // Khôi phục thời gian khi resume
            
        }
    }
}





