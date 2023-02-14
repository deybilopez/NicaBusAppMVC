﻿using NicaBusMVC.Models;

namespace NicaBusMVC
{
    public interface ICommandHandler<T> where T : class
    {
        CommandResult Execute(T command);
    }
}
