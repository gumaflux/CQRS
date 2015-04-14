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
using Cqrs.Authentication;
using Cqrs.Services;

namespace MyCompany.MyProject.Domain.Authentication.Services
{
	[GeneratedCode("CQRS UML Code Generator", "1.500.480.367")]
	[ServiceContract(Namespace="http://www.cdmdotnet.com/MyProject/Domain/Authentication/1001/")]
	public partial interface IUserService 
	{

		/// <summary>
		/// Create a new instance of the <see cref="Entities.UserEntity"/>
		/// </summary>
		[OperationContract]
		IServiceResponseWithResultData<Entities.UserEntity> CreateUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest);

		/// <summary>
		/// Update an existing instance of the <see cref="Entities.UserEntity"/>
		/// </summary>
		[OperationContract]
		IServiceResponseWithResultData<Entities.UserEntity> UpdateUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest);

		/// <summary>
		/// Logically delete an existing instance of the <see cref="Entities.UserEntity"/>
		/// </summary>
		[OperationContract]
		IServiceResponse DeleteUser(IServiceRequestWithData<System.Guid, Entities.UserEntity> serviceRequest);
	}
}
