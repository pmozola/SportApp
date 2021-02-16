﻿using System.Threading;
using System.Threading.Tasks;

namespace SportApp.Application
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
