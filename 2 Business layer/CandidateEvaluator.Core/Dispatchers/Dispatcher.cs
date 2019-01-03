﻿using CandidateEvaluator.Contract.Commands;
using CandidateEvaluator.Contract.Dispatchers;
using CandidateEvaluator.Contract.Queries;
using System;
using System.Threading.Tasks;

namespace CandidateEvaluator.Core.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public Dispatcher(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public Task<TResult> Query<TResult>(IQuery<TResult> query)
        {
            return _queryDispatcher.Query(query);
        }

        public Task<Guid> Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _commandDispatcher.Send(command);
        }
    }
}
