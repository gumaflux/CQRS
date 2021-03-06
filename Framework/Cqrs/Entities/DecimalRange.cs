﻿using System;

namespace Cqrs.Entities
{
	/// <summary>
	/// A <see cref="Range{TPrimitive}"/> object for collecting a <see cref="decimal"/> lower and upper limit.
	/// </summary>
	public class DecimalRange : Range<decimal>
	{
		/// <summary>
		/// Instantiates and Initialises a new instance of the <see cref="DecimalRange"/> class.
		/// </summary>
		public DecimalRange()
		{
			IsFromInclusive = true;
			IsToInclusive = true;
		}
	}
}