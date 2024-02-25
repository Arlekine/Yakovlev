using System;

namespace HW_1.Task3
{
    public interface IPlayerEventHolder
    {
        event Action<PlayerEvent> Triggered;
    }
}