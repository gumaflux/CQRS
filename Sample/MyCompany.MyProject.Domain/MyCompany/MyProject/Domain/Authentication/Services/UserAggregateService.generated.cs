﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#region Copyright
// -----------------------------------------------------------------------
// <copyright company="cdmdotnet Limited">
//     Copyright cdmdotnet Limited. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
#endregion
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Cqrs.Commands;
using Cqrs.Authentication;
using Cqrs.Logging;
using Cqrs.Repositories.Queries;
using Cqrs.Services;
using MyCompany.MyProject.Domain.Authentication.Commands;
using MyCompany.MyProject.Domain.Authentication.Repositories;

namespace MyCompany.MyProject.Domain.Authentication.Services
{
	[GeneratedCode("CQRS UML Code Generator", "1.500.480.367")]
	[DataContract(Namespace="http://www.cdmdotnet.com/MyProject/Domain/Authentication/1001/")]
	public partial class UserService : IUserService
	{
		protected ICommandSender<System.Guid> CommandSender { get; private set; }

		protected IUnitOfWorkService UnitOfWorkService { get; private set; }

		protected IUserRepository UserRepository { get; private set; }

		protected IQueryFactory QueryFactory { get; private set; }

		protected IAuthenticationTokenHelper<System.Guid> AuthenticationTokenHelper { get; set; }

		protected ICorrolationIdHelper CorrolationIdHelper { get; set; }

		public UserService(ICommandSender<System.Guid> commandSender, IUnitOfWorkService unitOfWorkService, IQueryFactory queryFactory, IAuthenticationTokenHelper<System.Guid> authenticationTokenHelper, ICorrolationIdHelper corrolationIdHelper, IUserRepository userRepository)
		{
			CommandSender = commandSender;
			UnitOfWorkService = unitOfWorkService;
			QueryFactory = queryFactory;
			AuthenticationTokenHelper = authenticationTokenHelper;
			CorrolationIdHelper = corrolationIdHelper;
			UserRepository = userRepository;
		}

		/// <summary>
		/// Create a new instance of the <see cref="Entities.UserEntity"/>
		/// </summary>
		[OperationContract]
		public IServiceResponseWithResultData<Entities.UserEntity> CreateUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest)
		{
			AuthenticationTokenHelper.SetAuthenticationToken(serviceRequest.AuthenticationToken);
			UnitOfWorkService.SetCommitter(this);
			Entities.UserEntity item = serviceRequest.Data;
			item.Rsn = Guid.NewGuid();

			var command = new CreateUserCommand(item.Rsn);
			OnCreateUser(serviceRequest, command);
			CommandSender.Send(command);
			OnCreatedUser(serviceRequest, command);

			UnitOfWorkService.Commit(this);
			return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity>(item));
		}

		partial void OnCreateUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest, CreateUserCommand command);

		partial void OnCreatedUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest, CreateUserCommand command);

		/// <summary>
		/// Update an existing instance of the <see cref="Entities.UserEntity"/>
		/// </summary>
		[OperationContract]
		public IServiceResponseWithResultData<Entities.UserEntity> UpdateUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest)
		{
			AuthenticationTokenHelper.SetAuthenticationToken(serviceRequest.AuthenticationToken);
			UnitOfWorkService.SetCommitter(this);
			Entities.UserEntity item = serviceRequest.Data;

			var locatedItem = UserRepository.Load(item.Rsn);
			if (locatedItem == null)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = ServiceResponseStateType.FailedValidation });

			var command = new UpdateUserCommand(item.Rsn);
			ServiceResponseStateType? serviceResponseStateType = null;
			OnUpdateUser(serviceRequest, ref command, locatedItem, ref serviceResponseStateType);
			if (serviceResponseStateType != null && serviceResponseStateType != ServiceResponseStateType.Succeeded)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = serviceResponseStateType.Value });

			CommandSender.Send(command);
			OnUpdatedUser(serviceRequest, ref command, locatedItem, ref serviceResponseStateType);
			if (serviceResponseStateType != null && serviceResponseStateType != ServiceResponseStateType.Succeeded)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = serviceResponseStateType.Value });

			UnitOfWorkService.Commit(this);
			return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity>(item));
		}

		partial void OnUpdateUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest, ref UpdateUserCommand command, Entities.UserEntity locatedItem, ref ServiceResponseStateType? serviceResponseStateType);

		partial void OnUpdatedUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest, ref UpdateUserCommand command, Entities.UserEntity locatedItem, ref ServiceResponseStateType? serviceResponseStateType);

		/// <summary>
		/// Logically delete an existing instance of the <see cref="Entities.UserEntity"/>
		/// </summary>
		[OperationContract]
		public IServiceResponse DeleteUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest)
		{
			AuthenticationTokenHelper.SetAuthenticationToken(serviceRequest.AuthenticationToken);
			UnitOfWorkService.SetCommitter(this);
			Entities.UserEntity item = serviceRequest.Data;

			var locatedItem = UserRepository.Load(item.Rsn, false);
			if (locatedItem == null)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = ServiceResponseStateType.FailedValidation });

			if (locatedItem.IsLogicallyDeleted)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = ServiceResponseStateType.FailedValidation });

			var command = new DeleteUserCommand(item.Rsn);
			ServiceResponseStateType? serviceResponseStateType = null;
			OnDeleteUser(serviceRequest, ref command, locatedItem, ref serviceResponseStateType);
			if (serviceResponseStateType != null && serviceResponseStateType != ServiceResponseStateType.Succeeded)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = serviceResponseStateType.Value });

			CommandSender.Send(command);
			OnDeletedUser(serviceRequest, ref command, locatedItem, ref serviceResponseStateType);
			if (serviceResponseStateType != null && serviceResponseStateType != ServiceResponseStateType.Succeeded)
				return CompleteResponse(new ServiceResponseWithResultData<Entities.UserEntity> { State = serviceResponseStateType.Value });

			UnitOfWorkService.Commit(this);
			return CompleteResponse(new ServiceResponse());
		}

		partial void OnDeleteUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest, ref DeleteUserCommand command, Entities.UserEntity locatedItem, ref ServiceResponseStateType? serviceResponseStateType);

		partial void OnDeletedUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest, ref DeleteUserCommand command, Entities.UserEntity locatedItem, ref ServiceResponseStateType? serviceResponseStateType);

		protected virtual TServiceResponse CompleteResponse<TServiceResponse>(TServiceResponse serviceResponse)
			where TServiceResponse : IServiceResponse
		{
			serviceResponse.CorrolationId = CorrolationIdHelper.GetCorrolationId();
			return serviceResponse;
		}
	}
}
