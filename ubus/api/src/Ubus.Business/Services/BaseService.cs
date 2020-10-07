using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Notifications;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;
using Ubus.Business.Notifications;

namespace Ubus.Business.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly INotifier _notifier;

        public BaseService(IBaseRepository<TEntity> repository, INotifier notifier)
        {
            _repository = repository;
            _notifier = notifier;
        }

        #region Validations

        protected void Notifier(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notifier(error.ErrorMessage);
            }
        }

        protected void Notifier(string msg)
        {
            _notifier.Handle(new NotificationBase(msg));
        }

        protected bool ValidationExecute<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notifier(validator); 
            return false;
        }

        #endregion

        #region Methods
        public virtual async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public virtual async Task Remove(Guid id)
        {
            await _repository.Remove(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        #endregion

    }
}
