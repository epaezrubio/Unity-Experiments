using System;

namespace Shared
{
	public interface IRaycastTrigger
	{
		event Action onCastRay; 
	}
	
}