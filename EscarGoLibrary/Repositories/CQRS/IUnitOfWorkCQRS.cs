﻿using System;
using System.Threading.Tasks;

namespace EscarGoLibrary.Repositories.CQRS
{
    public interface IUnitOfWorkCQRS: IDisposable
    {
        Task SaveAsync();
        IRaceRepositoryCQRS RaceRepository { get;  }
        ICompetitorRepositoryCQRS CompetitorRepository { get; }
    }
}