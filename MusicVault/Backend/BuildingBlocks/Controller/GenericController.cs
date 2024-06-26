﻿using MusicVault.Backend.BuildingBlocks.Observer;
using MusicVault.Backend.BuildingBlocks.Storage;
using System.Collections.Generic;

namespace MusicVault.Backend.BuildingBlocks.Controller;

public abstract class GenericController<T, R> 
    where T: IDAble
    where R: SQLGenericRepository<T> {
    protected readonly R repository;
    private readonly Subject Subject;

    public GenericController(R repository) {
        this.repository = repository;
        Subject = new Subject();
    }

    public void Subscribe(IObserver observer) {
        Subject.Subscribe(observer);
    }

    public void Add(T entity) {
        repository.Add(entity);
        Subject.NotifyObservers();
    }

    public void Update(T entity) {
        repository.Update(entity);
        Subject.NotifyObservers();
    }

    public T? Get(int id) {
        return repository.Get(id);
    }

    public List<T> GetAll() { 
        return repository.GetAll();
    }
}
