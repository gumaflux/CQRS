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
using Cqrs.Events;
using Cqrs.Domain;

namespace MyCompany.MyProject.Domain.Authentication.Events.Handlers
{
	[GeneratedCode("CQRS UML Code Generator", "1.500.480.367")]
	public  partial class UserDeletedEventHandler : IEventHandler<System.Guid, UserDeleted>
	{
		#region Implementation of IEventHandler<in UserDeleted>

		public void Handle(UserDeleted @event)
		{
			OnHandle(@event);
		}

		#endregion

		partial void OnHandle(UserDeleted @event);
	}
}
