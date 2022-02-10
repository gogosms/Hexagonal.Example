﻿using System;

namespace Hexagonal.Example.Core.Models
{
	public abstract class EntityBase 
	{
		public Guid Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime ModifiedAt { get; set; }
	}
}
